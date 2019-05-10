package il.co.meir_itzik.gettaxi2.controller;


import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.Paint;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.AppCompatEditText;
import android.view.KeyEvent;
import android.view.View;
import android.view.WindowManager;
import android.view.inputmethod.EditorInfo;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.TextView;
import android.widget.Toast;

import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi2.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi2.model.entities.Driver;
import il.co.meir_itzik.gettaxi2.model.utils.SharedPreferencesService;
import il.co.meir_itzik.gettaxi2.model.utils.Validation;

public class LoginActivity extends AppCompatActivity {

    // UI references.
    private AppCompatEditText mEmailET;
    private AppCompatEditText mPasswordET;
    private View mProgressView;
    private TextView mRegisterTextView;
    private Button mSignInButton;
    private CheckBox mRememberMeCB;
    private SharedPreferencesService prefs;
    private DataSource DB = BackendFactory.getDatasource();

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        prefs = new SharedPreferencesService(this);
        if (prefs.isLoggedIn()) {
            Intent main = new Intent(LoginActivity.this, MainActivity.class);
            main.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(main);
        }

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        // Set up the login form.
        mRegisterTextView = findViewById(R.id.register_link);
        mRegisterTextView.setPaintFlags(mRegisterTextView.getPaintFlags() | Paint.UNDERLINE_TEXT_FLAG);
        mRegisterTextView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent register = new Intent(LoginActivity.this, RegisterActivity.class);
                startActivity(register);
            }
        });
        mEmailET = findViewById(R.id.email_edit_text);

        mPasswordET = findViewById(R.id.password_edit_text);
        mPasswordET.setOnEditorActionListener(new TextView.OnEditorActionListener() {
            @Override
            public boolean onEditorAction(TextView textView, int id, KeyEvent keyEvent) {
                if (id == EditorInfo.IME_ACTION_DONE || id == EditorInfo.IME_NULL) {
                    attemptLogin();
                    return true;
                }
                return false;
            }
        });

        mSignInButton = findViewById(R.id.sign_in_btn);
        mSignInButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                attemptLogin();
            }
        });

        mProgressView = findViewById(R.id.progress_bar);
        mRememberMeCB = findViewById(R.id.remember_check_box);
    }

    private void attemptLogin() {

        // Reset errors.
        mEmailET.setError(null);
        mPasswordET.setError(null);

        // Store values at the time of the login attempt.
        final String email = mEmailET.getText().toString();
        final String password = mPasswordET.getText().toString();

        boolean cancel = false;
        View focusView = null;

        if (Validation.isPasswordEmpty(password)) {
            mPasswordET.setError(getString(R.string.error_field_required));
            focusView = mPasswordET;
            cancel = true;
        } else if (!Validation.isPasswordValid(password)) {
            mPasswordET.setError(getString(R.string.error_invalid_password));
            focusView = mPasswordET;
            cancel = true;
        }

        // Check for a valid email address.
        if (Validation.isEmailEmpty(email)) {
            mEmailET.setError(getString(R.string.error_field_required));
            focusView = mEmailET;
            cancel = true;
        } else if (!Validation.isEmailValid(email)) {
            mEmailET.setError(getString(R.string.error_invalid_email));
            focusView = mEmailET;
            cancel = true;
        }

        if (cancel) {
            focusView.requestFocus();
        } else {
            DB.isDriverExistByEmailAndPassword(email, password, new DataSource.RunAction<Boolean>() {
                Intent intent = null;
                boolean isExist = false;

                @Override
                public void onPreExecute() {
                    View view = getCurrentFocus();
                    if (view != null) {
                        InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
                        imm.hideSoftInputFromWindow(view.getWindowToken(), 0);
                    }
                    mProgressView.setVisibility(View.VISIBLE);
                    getWindow().setFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE,
                            WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                }

                @Override
                public void onSuccess(Boolean exist) {
                    if (!exist) {
                        new AlertDialog.Builder(LoginActivity.this, R.style.CustomDialog)
                                .setMessage("incorrect Email or Password")
                                .setPositiveButton(android.R.string.ok, new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog, int which) {
                                        dialog.cancel();
                                    }
                                })
                                .show();
                    } else {
                        isExist = true;
                        DB.getDriverByEmailAndPassword(email, password, new DataSource.RunAction<Driver>() {
                            @Override
                            public void onPreExecute() {

                            }

                            @Override
                            public void onSuccess(Driver driver) {
                                if (mRememberMeCB.isChecked()) {
                                    prefs.setLoggedIn(true);
                                    prefs.putDriver(driver);
                                }
                                intent = new Intent(LoginActivity.this, MainActivity.class);
                                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                            }

                            @Override
                            public void onFailure(Driver obj, Exception e) {
                                Toast toast = Toast.makeText(LoginActivity.this, "failed to get driver from FireBase" + e.getMessage(), Toast.LENGTH_SHORT);
                                TextView v = toast.getView().findViewById(android.R.id.message);
                                v.setTextColor(Color.RED);
                                toast.show();
                            }

                            @Override
                            public void onPostExecute() {
                                mProgressView.setVisibility(View.INVISIBLE);
                                clearFields();
                                getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                                if (intent != null)
                                    startActivity(intent);
                            }
                        });
                    }
                }

                @Override
                public void onFailure(Boolean exist, Exception e) {
                    Toast toast = Toast.makeText(LoginActivity.this, "failed to connect to FireBase" + e.getMessage(), Toast.LENGTH_SHORT);
                    TextView v = toast.getView().findViewById(android.R.id.message);
                    v.setTextColor(Color.RED);
                    toast.show();
                }

                @Override
                public void onPostExecute() {
                    if (!isExist) {
                        mProgressView.setVisibility(View.INVISIBLE);
                        clearFields();
                        getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                    }
                }
            });
        }
    }

    private void clearFields() {
        mEmailET.setText("");
        mPasswordET.setText("");
    }

    @Override
    protected void onResume() {
        super.onResume();
    }
}

