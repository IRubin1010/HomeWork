package il.co.meir_itzik.gettaxi1.controller;

import android.content.Context;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.EditText;
import android.widget.Toast;

import java.util.Date;
import java.util.Timer;
import java.util.TimerTask;

import il.co.meir_itzik.gettaxi1.R;
import il.co.meir_itzik.gettaxi1.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi1.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.entities.Travel;
import il.co.meir_itzik.gettaxi1.model.utils.Validation;

public class NoRegistrationOrder extends AppCompatActivity {

    EditText firstNameView, lastNameView, phoneNumberView, emailView, fromView, destinationView, creditCardView;
    String firstName, lastName, phoneNumber, email, from, destination, creditCard;
    View focusView = null, orderView, progressView;
    DataSource DB = BackendFactory.getDatasource();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order_without_login);
        firstNameView = findViewById(R.id.first_name);
        lastNameView = findViewById(R.id.last_name);
        phoneNumberView = findViewById(R.id.phone_number);
        emailView = findViewById(R.id.email);
        fromView = findViewById(R.id.from);
        destinationView = findViewById(R.id.destination);
        creditCardView = findViewById(R.id.credit_card);
        orderView = findViewById(R.id.order_form);
        progressView = findViewById(R.id.order_progress);
    }


    public void btnCancelClick(View view) {
        emptyFields();
    }

    private void emptyFields(){
        firstNameView.setText("");
        lastNameView.setText("");
        phoneNumberView.setText("");
        emailView.setText("");
        fromView.setText("");
        destinationView.setText("");
        creditCardView.setText("");
    }

    public void btnSendClick(View view) {
        sendOrder();
    }

    private void sendOrder(){
        initEditTextErrors();
        getData();
        if(isDataValid()){
            /**
             * this code is just for display the progress bar for 2 seconds
             */
            View view = this.getCurrentFocus();
            if (view != null) {
                InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
                imm.hideSoftInputFromWindow(view.getWindowToken(), 0);
            }
            progressView.setVisibility(View.VISIBLE);
            // make user the user cannot touch the screen
            getWindow().setFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE,
                    WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
            Passenger passenger = new Passenger(firstName, lastName,email, phoneNumber, creditCard);
            DB.addPassenger(passenger);
            Travel travel = new Travel(from, destination, new Date(), Travel.Status.OPEN, passenger);
            DB.addTravel(travel);
            long delayInMillis = 2000;
            Timer timer = new Timer();
            timer.schedule(new TimerTask() {
                @Override
                public void run() {
                    NoRegistrationOrder.this.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            progressView.setVisibility(View.INVISIBLE);
                            emptyFields();
                            Toast.makeText(getApplicationContext(), "your order has been accepted", Toast.LENGTH_SHORT).show();
                        }
                    });
                }
            }, delayInMillis);
            // release the screen
            getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
            /**
             * end
             */

        }else {
            focusView.requestFocus();
        }
    }

    private void initEditTextErrors(){
        setError(firstNameView, null);
        setError(lastNameView, null);
        setError(phoneNumberView, null);
        setError(emailView, null);
        setError(fromView, null);
        setError(destinationView, null);
        setError(creditCardView, null);
    }

    private void setError(EditText view, String error){
        view.setError(error);
    }

    private void getData(){
        firstName = firstNameView.getText().toString();
        lastName = lastNameView.getText().toString();
        phoneNumber = phoneNumberView.getText().toString();
        email = emailView.getText().toString();
        from = fromView.getText().toString();
        destination = destinationView.getText().toString();
        creditCard = creditCardView.getText().toString();
    }

    private Boolean isDataValid(){
        boolean isValid = true;
        if(Validation.isFirstNameEmpty(firstName)){
            setError(firstNameView, getString(R.string.error_field_required));
            focusView = firstNameView;
            isValid = false;
        }
        if(Validation.isLastNameEmpty(lastName)){
            setError(lastNameView, getString(R.string.error_field_required));
            focusView = lastNameView;
            isValid = false;
        }
        if(Validation.isPhoneNumberEmpty(phoneNumber)){
            setError(phoneNumberView, getString(R.string.error_field_required));
            focusView = phoneNumberView;
            isValid = false;
        }else if(!Validation.isPhoneNumberValid(phoneNumber)){
            setError(phoneNumberView, getString(R.string.error_invalid_phone_number));
            focusView = phoneNumberView;
            isValid = false;
        }
        if(Validation.isEmailEmpty(email)){
            setError(emailView, getString(R.string.error_field_required));
            focusView = emailView;
            isValid = false;
        }else if(!Validation.isEmailValid(email)){
            setError(emailView, getString(R.string.error_invalid_email));
            focusView = emailView;
            isValid = false;
        }
        if(Validation.isFromAddressEmpty(from)){
            setError(fromView, getString(R.string.error_field_required));
            focusView = fromView;
            isValid = false;
        }
        if(Validation.isDestinationAddressEmpty(destination)){
            setError(destinationView, getString(R.string.error_field_required));
            focusView = destinationView;
            isValid = false;
        }
        if(Validation.isCreditCardEmpty(creditCard)){
            setError(creditCardView, getString(R.string.error_field_required));
            focusView = creditCardView;
            isValid = false;
        }else if(!Validation.isCreditCardValid(creditCard)){
            setError(creditCardView, getString(R.string.error_invalid_credit_card));
            focusView = creditCardView;
            isValid = false;
        }
        return isValid;
    }
}

