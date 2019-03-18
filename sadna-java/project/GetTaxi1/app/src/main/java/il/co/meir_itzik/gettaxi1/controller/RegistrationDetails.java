package il.co.meir_itzik.gettaxi1.controller;


import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import il.co.meir_itzik.gettaxi1.R;
import il.co.meir_itzik.gettaxi1.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi1.model.backend.RunDbActionAsync;
import il.co.meir_itzik.gettaxi1.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.utils.Validation;

public class RegistrationDetails extends Fragment {

    EditText idView, phoneNumberView, creditCardView;
    String firstName, lastName, id, email, phoneNumber, creditCard;
    View focusView = null, progressView;
    Button registerBtn, cancelBtn;
    DataSource DB = BackendFactory.getDatasource();
    Passenger passenger;

    public RegistrationDetails() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_registration_details, container, false);

        firstName = getArguments().getString("fName");
        lastName = getArguments().getString("lName");
        email = getArguments().getString("email");

        progressView = getActivity().findViewById(R.id.order_progress);

        idView = view.findViewById(R.id.id);
        phoneNumberView = view.findViewById(R.id.phone_number);
        creditCardView = view.findViewById(R.id.credit_card);
        registerBtn = view.findViewById(R.id.register);
        cancelBtn = view.findViewById(R.id.cancel);

        cancelBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                emptyFields();
            }
        });

        registerBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                register();
            }
        });
        return view;

    }

    private void register(){
        initEditTextErrors();
        getData();
        if(isDataValid()){
            passenger = new Passenger(firstName, lastName, id, email, phoneNumber, creditCard);
            new RunDbActionAsync(new RunDbActionAsync.AsyncRunner() {

                @Override
                public void onPreExecute() {
                    View view = getActivity().getCurrentFocus();
                    if (view != null) {
                        InputMethodManager imm = (InputMethodManager) getActivity().getSystemService(Context.INPUT_METHOD_SERVICE);
                        imm.hideSoftInputFromWindow(view.getWindowToken(), 0);
                    }
                    getActivity().getWindow().setFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE,
                            WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                    progressView.setVisibility(View.VISIBLE);
                }

                @Override
                public Void doInBackground() {
                    // make that the user cannot touch the screen
                    if(!DB.isPassengerExist(passenger)) DB.addPassenger(passenger);
                    try {
                        Thread.sleep(3000);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    return null;
                }

                @Override
                public void onPostExecute() {
                    progressView.setVisibility(View.INVISIBLE);
                    emptyFields();
                    Toast.makeText(getActivity().getApplicationContext(), "accept", Toast.LENGTH_SHORT).show();
                    getActivity().getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                    // TODO after registration save passenger to SP and go to user order page
                }
            }).execute();
        }else {
            focusView.requestFocus();
        }
    }

    private void emptyFields(){
        idView.setText("");
        phoneNumberView.setText("");
        creditCardView.setText("");
    }

    private void initEditTextErrors(){
        setError(idView, null);
        setError(phoneNumberView, null);
        setError(creditCardView, null);
    }

    private void setError(EditText view, String error){
        view.setError(error);
    }

    private void getData(){
        id = idView.getText().toString();
        phoneNumber = phoneNumberView.getText().toString();
        creditCard = creditCardView.getText().toString();
    }

    private Boolean isDataValid(){
        boolean isValid = true;
        if(Validation.isIdEmpty(id)){
            setError(idView, getString(R.string.error_field_required));
            focusView = idView;
            isValid = false;
        }else if(!Validation.isCreditCardValid(id)){
            setError(idView, getString(R.string.error_invalid_id));
            focusView = idView;
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
