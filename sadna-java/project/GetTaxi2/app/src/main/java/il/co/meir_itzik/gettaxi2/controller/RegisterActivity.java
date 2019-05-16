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
import il.co.meir_itzik.gettaxi2.model.utils.SharedPreferencesService;
import il.co.meir_itzik.gettaxi2.model.utils.Validation;

public class RegisterActivity extends AppCompatActivity {

    private AppCompatEditText mFitNameET, mLastNameET, mIdET, mEmailET, mPhoneNumberET, mCreditCardET, mPasswordET;
    String firstName, lastName, id, email, phoneNumber, creditCard, password;
    private View mProgressView, focusView = null;
    private Button mRegisterBtn, mCancelBtn;
    private SharedPreferencesService prefs;
    private DataSource DB = BackendFactory.getDatasource();
    private AuthService AS = BackendFactory.getAuthService();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        prefs = new SharedPreferencesService(this);

        mFitNameET = findViewById(R.id.first_name);
        mLastNameET = findViewById(R.id.last_name);
        mIdET = findViewById(R.id.id);
        mEmailET = findViewById(R.id.email);
        mPhoneNumberET = findViewById(R.id.phone_number);
        mCreditCardET = findViewById(R.id.credit_card);
        mPasswordET = findViewById(R.id.password);

        mPasswordET.setOnEditorActionListener(new TextView.OnEditorActionListener() {
            @Override
            public boolean onEditorAction(TextView textView, int id, KeyEvent keyEvent) {
                if (id == EditorInfo.IME_ACTION_DONE || id == EditorInfo.IME_NULL) {
                    register();
                    return true;
                }
                return false;
            }
        });

        mProgressView = findViewById(R.id.progress_bar);

        mRegisterBtn = findViewById(R.id.register_btn);
        mRegisterBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                register();
            }
        });

        mCancelBtn = findViewById(R.id.cancel_btn);
        mCancelBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                clearFields();
                finish();
            }
        });
    }

    private void clearFields(){
        mFitNameET.setText("");
        mLastNameET.setText("");
        mIdET.setText("");
        mEmailET.setText("");
        mPhoneNumberET.setText("");
        mCreditCardET.setText("");
        mPasswordET.setText("");
    }

    private void register(){
        firstName = mFitNameET.getText().toString();
        lastName = mLastNameET.getText().toString();
        id = mIdET.getText().toString();
        email = mEmailET.getText().toString();
        phoneNumber = mPhoneNumberET.getText().toString();
        creditCard = mCreditCardET.getText().toString();
        password = mPasswordET.getText().toString();


        if(isDataValid()){

            final Driver driver = new Driver(firstName, lastName, email, id, phoneNumber, creditCard, password);

            View view = getCurrentFocus();
            if (view != null) {
                InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
                imm.hideSoftInputFromWindow(view.getWindowToken(), 0);
            }
            mProgressView.setVisibility(View.VISIBLE);
            getWindow().setFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE,
                    WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);

            AS.registerUserWithEmailAndPassword(email, password, new AuthService.RunAction<FirebaseUser>() {
                @Override
                public void onSuccess(FirebaseUser obj) {
                    DB.addDriver(driver, new DataSource.RunAction<Driver>() {
                        @Override
                        public void onPreExecute() {

                        }

                        @Override
                        public void onSuccess(final Driver driver) {
                            new AlertDialog.Builder(RegisterActivity.this, R.style.CustomDialog)
                                    .setMessage("driver " + driver.getFirstName() + " " + driver.getLastName() + "\nsuccessfully registered")
                                    .setPositiveButton(android.R.string.ok, new DialogInterface.OnClickListener() {
                                        @Override
                                        public void onClick(DialogInterface dialog, int which) {
                                            dialog.cancel();
                                            mProgressView.setVisibility(View.INVISIBLE);
                                            clearFields();
                                            getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                                            //prefs.setLoggedIn(true);
                                            prefs.putDriver(driver);
                                            Intent main = new Intent(RegisterActivity.this, MainActivity.class);
                                            main.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                            startActivity(main);
                                        }
                                    })
                                    .show();
                        }

                        @Override
                        public void onFailure(Driver obj, Exception e) {
                            Toast toast = Toast.makeText(RegisterActivity.this, "failed to add driver to FireBase" + e.getMessage(), Toast.LENGTH_SHORT);
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
                }

                @Override
                public void onFailure(FirebaseUser obj, String e) {
                    Toast toast = Toast.makeText(RegisterActivity.this, "failed to add driver to FireBase" + e, Toast.LENGTH_SHORT);
                    TextView v = toast.getView().findViewById(android.R.id.message);
                    v.setTextColor(Color.RED);
                    toast.show();
                    mProgressView.setVisibility(View.INVISIBLE);
                    getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                }
            });

        }else{
            focusView.requestFocus();
        }
    }

    private boolean isDataValid(){
        initFieldsErrors();
        boolean isValid = true;
        if(Validation.isFirstNameEmpty(firstName)){
            setError(mFitNameET, getString(R.string.error_field_required));
            focusView = mFitNameET;
            isValid = false;
        }
        if(Validation.isLastNameEmpty(lastName)){
            setError(mLastNameET, getString(R.string.error_field_required));
            focusView = mLastNameET;
            isValid = false;
        }
        if(Validation.isIdEmpty(id)){
            setError(mIdET, getString(R.string.error_field_required));
            focusView = mIdET;
            isValid = false;
        }else if(!Validation.isIdValid(id)){
            setError(mIdET, getString(R.string.error_invalid_id));
            focusView = mIdET;
            isValid = false;
        }
        if(Validation.isPhoneNumberEmpty(phoneNumber)){
            setError(mPhoneNumberET, getString(R.string.error_field_required));
            focusView = mPhoneNumberET;
            isValid = false;
        }else if(!Validation.isPhoneNumberValid(phoneNumber)){
            setError(mPhoneNumberET, getString(R.string.error_invalid_phone_number));
            focusView = mPhoneNumberET;
            isValid = false;
        }
        if(Validation.isEmailEmpty(email)){
            setError(mEmailET, getString(R.string.error_field_required));
            focusView = mEmailET;
            isValid = false;
        }else if(!Validation.isEmailValid(email)){
            setError(mEmailET, getString(R.string.error_invalid_email));
            focusView = mEmailET;
            isValid = false;
        }
        if(Validation.isCreditCardEmpty(creditCard)){
            setError(mCreditCardET, getString(R.string.error_field_required));
            focusView = mCreditCardET;
            isValid = false;
        }else if(!Validation.isCreditCardValid(creditCard)){
            setError(mCreditCardET, getString(R.string.error_invalid_credit_card));
            focusView = mCreditCardET;
            isValid = false;
        }
        if (Validation.isPasswordEmpty(password)) {
            mPasswordET.setError(getString(R.string.error_field_required));
            focusView = mPasswordET;
            isValid = false;
        } else if (!Validation.isPasswordValid(password)) {
            mPasswordET.setError(getString(R.string.error_invalid_password));
            focusView = mPasswordET;
            isValid = false;
        }
        return isValid;
    }

    private void initFieldsErrors(){
        setError(mFitNameET, null);
        setError(mLastNameET, null);
        setError(mIdET, null);
        setError(mEmailET, null);
        setError(mPhoneNumberET, null);
        setError(mCreditCardET, null);
        setError(mPasswordET, null);
    }

    private void setError(EditText ET, String error){
        ET.setError(error);
    }
}
