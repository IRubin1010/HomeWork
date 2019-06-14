package il.co.meir_itzik.gettaxi2.controller;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.AppCompatEditText;
import android.view.KeyEvent;
import android.view.View;
import android.view.WindowManager;
import android.view.inputmethod.EditorInfo;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.auth.FirebaseUser;

import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.model.Authentication.AuthService;
import il.co.meir_itzik.gettaxi2.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi2.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi2.model.entities.Driver;
import il.co.meir_itzik.gettaxi2.utils.SharedPreferencesService;
import il.co.meir_itzik.gettaxi2.utils.Validation;

public class AdditionalDetailsActivity extends AppCompatActivity {

    private AppCompatEditText mIdET, mPhoneNumberET, mCreditCardET;
    private String firstName, lastName, id, email, phoneNumber, creditCard;
    private boolean remember;
    private View mProgressView, focusView = null;
    private Button mFinishBtn;
    private SharedPreferencesService prefs;
    private DataSource DB = BackendFactory.getDatasource();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_additional_details);

        prefs = new SharedPreferencesService(this);

        firstName = getIntent().getStringExtra("firstName");
        lastName = getIntent().getStringExtra("lastName");
        email = getIntent().getStringExtra("email");
        remember = getIntent().getBooleanExtra("remember", false);

        mIdET = findViewById(R.id.id);
        mPhoneNumberET = findViewById(R.id.phone_number);
        mCreditCardET = findViewById(R.id.credit_card);

        mCreditCardET.setOnEditorActionListener(new TextView.OnEditorActionListener() {
            @Override
            public boolean onEditorAction(TextView textView, int id, KeyEvent keyEvent) {
                if (id == EditorInfo.IME_ACTION_DONE || id == EditorInfo.IME_NULL) {
                    addDetails();
                    return true;
                }
                return false;
            }
        });

        mProgressView = findViewById(R.id.progress_bar);

        mFinishBtn = findViewById(R.id.finish);

        mFinishBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                addDetails();
            }
        });
    }

    private void clearFields() {
        mIdET.setText("");
        mPhoneNumberET.setText("");
        mCreditCardET.setText("");
    }

    private void addDetails() {
        id = mIdET.getText().toString();
        phoneNumber = mPhoneNumberET.getText().toString();
        creditCard = mCreditCardET.getText().toString();


        if (isDataValid()) {

            final Driver driver = new Driver(firstName, lastName, email, id, phoneNumber, creditCard, null);

            View view = getCurrentFocus();
            if (view != null) {
                InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
                imm.hideSoftInputFromWindow(view.getWindowToken(), 0);
            }
            mProgressView.setVisibility(View.VISIBLE);
            getWindow().setFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE,
                    WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
            DB.addDriver(driver, new DataSource.RunAction<Driver>() {
                @Override
                public void onPreExecute() {

                }

                @Override
                public void onSuccess(final Driver driver) {
                    new AlertDialog.Builder(AdditionalDetailsActivity.this, R.style.CustomDialog)
                            .setMessage("driver " + driver.getFirstName() + " " + driver.getLastName() + "\nsuccessfully registered")
                            .setPositiveButton(android.R.string.ok, new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int which) {
                                    dialog.cancel();
                                    mProgressView.setVisibility(View.INVISIBLE);
                                    clearFields();
                                    getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                                    if(remember){
                                        prefs.setLoggedIn(true);
                                    }
                                    prefs.putDriver(driver);
                                    prefs.setGoogleLoggedIn(true);
                                    Intent main = new Intent(AdditionalDetailsActivity.this, MainActivity.class);
                                    main.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                    startActivity(main);
                                }
                            })
                            .show();
                }

                @Override
                public void onFailure(Driver obj, Exception e) {
                    Toast toast = Toast.makeText(AdditionalDetailsActivity.this, "failed to add driver to FireBase" + e.getMessage(), Toast.LENGTH_SHORT);
                    TextView v = toast.getView().findViewById(android.R.id.message);
                    v.setTextColor(Color.RED);
                    toast.show();
                }

                @Override
                public void onPostExecute() {
                    mProgressView.setVisibility(View.INVISIBLE);
                    clearFields();
                    getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                }
            });

        } else {
            focusView.requestFocus();
        }
    }

    private boolean isDataValid() {
        initFieldsErrors();
        boolean isValid = true;
        if (Validation.isIdEmpty(id)) {
            setError(mIdET, getString(R.string.error_field_required));
            focusView = mIdET;
            isValid = false;
        } else if (!Validation.isIdValid(id)) {
            setError(mIdET, getString(R.string.error_invalid_id));
            focusView = mIdET;
            isValid = false;
        }
        if (Validation.isPhoneNumberEmpty(phoneNumber)) {
            setError(mPhoneNumberET, getString(R.string.error_field_required));
            focusView = mPhoneNumberET;
            isValid = false;
        } else if (!Validation.isPhoneNumberValid(phoneNumber)) {
            setError(mPhoneNumberET, getString(R.string.error_invalid_phone_number));
            focusView = mPhoneNumberET;
            isValid = false;
        }
        if (Validation.isCreditCardEmpty(creditCard)) {
            setError(mCreditCardET, getString(R.string.error_field_required));
            focusView = mCreditCardET;
            isValid = false;
        } else if (!Validation.isCreditCardValid(creditCard)) {
            setError(mCreditCardET, getString(R.string.error_invalid_credit_card));
            focusView = mCreditCardET;
            isValid = false;
        }
        return isValid;
    }

    private void initFieldsErrors() {
        setError(mIdET, null);
        setError(mPhoneNumberET, null);
        setError(mCreditCardET, null);
    }

    private void setError(EditText ET, String error) {
        ET.setError(error);
    }

    @Override
    public void onBackPressed() {
    }
}
