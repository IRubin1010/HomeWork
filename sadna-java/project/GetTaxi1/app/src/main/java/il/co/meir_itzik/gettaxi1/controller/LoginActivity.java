package il.co.meir_itzik.gettaxi1.controller;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.preference.PreferenceManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.Gson;

import il.co.meir_itzik.gettaxi1.R;

import il.co.meir_itzik.gettaxi1.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi1.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.utils.Validation;

public class LoginActivity extends AppCompatActivity {

    private EditText mFirstNameView, mLastNameView, mEmailView;
    private View mProgressView;
    private DataSource DB = BackendFactory.getDatasource();
    private SharedPreferences prefs;
    private Button mEmailSignInBtn, mNoRegistrationBtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        // check if the user is already logged in
        prefs = PreferenceManager.getDefaultSharedPreferences(this);
        boolean isLogeIn = prefs.getBoolean("loggedIn",false);
        if(isLogeIn){
            Intent registeredActivity = new Intent(this, RegisteredActivity.class);
            registeredActivity.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(registeredActivity);
        }

        // if the user is not logged in
        super.onCreate(savedInstanceState);
        getWindow().setBackgroundDrawableResource(R.drawable.taxi);
        setContentView(R.layout.activity_login);

        // Set up the login form.
        mFirstNameView = findViewById(R.id.first_name);
        mLastNameView = findViewById(R.id.last_name);
        mEmailView = findViewById(R.id.email);

        mEmailSignInBtn = findViewById(R.id.email_sign_in_btn);
        mEmailSignInBtn.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                attemptLogin();
            }
        });

        mNoRegistrationBtn = findViewById(R.id.no_registration_btn);
        mNoRegistrationBtn.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent appBasic = new Intent(LoginActivity.this, AppBasicActivity.class);
                appBasic.putExtra("fragment","noRegister");
                startActivity(appBasic);
            }
        });

        mProgressView = findViewById(R.id.progress);
    }

    private void attemptLogin() {

        // Reset errors.
        mFirstNameView.setError(null);
        mLastNameView.setError(null);
        mEmailView.setError(null);

        // Store values at the time of the login attempt.
        final String firstName = mFirstNameView.getText().toString();
        final String lastName = mLastNameView.getText().toString();
        final String email = mEmailView.getText().toString();

        boolean cancel = false;
        View focusView = null;

        if(Validation.isFirstNameEmpty(firstName)){
            mFirstNameView.setError(getString(R.string.error_field_required));
            focusView = mFirstNameView;
            cancel = true;
        }

        if(Validation.isLastNameEmpty(lastName)){
            mLastNameView.setError(getString(R.string.error_field_required));
            focusView = mLastNameView;
            cancel = true;
        }

        // Check for a valid email address.
        if (Validation.isEmailEmpty(email)) {
            mEmailView.setError(getString(R.string.error_field_required));
            focusView = mEmailView;
            cancel = true;
        } else if (!Validation.isEmailValid(email)) {
            mEmailView.setError(getString(R.string.error_invalid_email));
            focusView = mEmailView;
            cancel = true;
        }

        if (cancel) {
            focusView.requestFocus();
        } else {
            // run DB action to check if the user exist or a new user

            DB.getPassenger(email, new DataSource.RunAction<Passenger>() {
                Intent i = null;
                @Override
                public void onPreExecute() {
                    View view = getCurrentFocus();
                    if (view != null) {
                        InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
                        imm.hideSoftInputFromWindow(view.getWindowToken(), 0);
                    }
                    mProgressView.setVisibility(View.VISIBLE);
                    getWindow().setFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE,
                            WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                }

                @Override
                public void onSuccess(Passenger passenger) {
                    if(passenger == null){
                        i = new Intent(LoginActivity.this, AppBasicActivity.class);
                        i.putExtra("fragment","Registration");
                        i.putExtra("fName", firstName);
                        i.putExtra("lName", lastName);
                        i.putExtra("email", email);
                    }
                    else{
                        Gson gson = new Gson();
                        String pasJson = gson.toJson(passenger);
                        prefs.edit().putString("passenger", pasJson).apply();
                        prefs.edit().putBoolean("loggedIn",true).apply();

                        i = new Intent(LoginActivity.this, RegisteredActivity.class);
                        i.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                    }
                }

                @Override
                public void onFailure(Passenger obj, Exception e) {
                    Toast toast = Toast.makeText(LoginActivity.this, "failed to get login details" + e.getMessage(), Toast.LENGTH_SHORT);
                    TextView v = toast.getView().findViewById(android.R.id.message);
                    v.setTextColor(Color.RED);
                    toast.show();
                }

                @Override
                public void onPostExecute() {
                    mProgressView.setVisibility(View.INVISIBLE);
                    getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                    startActivity(i);
                }
            });







//            new RunDbActionAsync(new RunDbActionAsync.AsyncRunner() {
//
//                @Override
//                public void onPreExecute() {
//                    // lock the screen and show progress bar until finish
//                    View view = getCurrentFocus();
//                    if (view != null) {
//                        InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
//                        imm.hideSoftInputFromWindow(view.getWindowToken(), 0);
//                    }
//                    mProgressView.setVisibility(View.VISIBLE);
//                    getWindow().setFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE,
//                            WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
//                }
//
//                @Override
//                public Void doInBackground() {
//                    passenger = DB.isPassengerExist(firstName, lastName, email, null);
//                    try {
//                        Thread.sleep(1000);
//                    } catch (InterruptedException e) {
//                        e.printStackTrace();
//                    }
//                    return null;
//                }
//
//                @Override
//                public void onPostExecute() {
//                    // unlock screen and hide progress bar
//                    mProgressView.setVisibility(View.INVISIBLE);
//                    getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
//
//                    // new user
//                    if(passenger == null){
//                        Intent appBasic = new Intent(LoginActivity.this, AppBasicActivity.class);
//                        appBasic.putExtra("fragment","Registration");
//                        appBasic.putExtra("fName", firstName);
//                        appBasic.putExtra("lName", lastName);
//                        appBasic.putExtra("email", email);
//                        startActivity(appBasic);
//                    }
//                    else{
//                        Gson gson = new Gson();
//                        String pasJson = gson.toJson(passenger);
//                        prefs.edit().putString("passenger", pasJson).apply();
//                        prefs.edit().putBoolean("loggedIn",true).apply();
//
//                        Intent registered = new Intent(LoginActivity.this, RegisteredActivity.class);
//                        registered.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
//                        startActivity(registered);
//                    }
//                }
//            }).execute();
        }
    }

}

