package il.co.meir_itzik.gettaxi1.controller;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;

import il.co.meir_itzik.gettaxi1.R;
import il.co.meir_itzik.gettaxi1.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi1.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.utils.Validation;


public class PassengerDetailsNoRegistration extends Fragment {

    EditText firstNameView, lastNameView, idView, phoneNumberView, emailView, creditCardView;
    String firstName, lastName, id, phoneNumber, email, creditCard;
    View focusView = null;
    Button nextBtn, cancelBtn;
    DataSource DB = BackendFactory.getDatasource();

    public PassengerDetailsNoRegistration() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_passenger_details_no_registration, container, false);
        firstNameView = view.findViewById(R.id.first_name);
        lastNameView = view.findViewById(R.id.last_name);
        idView = view.findViewById(R.id.id);
        phoneNumberView = view.findViewById(R.id.phone_number);
        emailView = view.findViewById(R.id.email);
        creditCardView = view.findViewById(R.id.credit_card);
        nextBtn = view.findViewById(R.id.order);
        cancelBtn = view.findViewById(R.id.cancel);
//        detailsView = view.findViewById(R.id.details_form);
//        progressView = getActivity().findViewById(R.id.order_progress);

        cancelBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                emptyFields();
            }
        });

        nextBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                sendOrder();
            }
        });
        return view;
    }

    public void emptyFields(){
        firstNameView.setText("");
        lastNameView.setText("");
        idView.setText("");
        phoneNumberView.setText("");
        emailView.setText("");
        creditCardView.setText("");
    }

    private void sendOrder(){
        initEditTextErrors();
        getData();
        if(isDataValid()){
            Passenger passenger = new Passenger(firstName, lastName, id, email, phoneNumber, creditCard);
//            DB.addPassenger(passenger);
            Fragment travelFragment = new TravelDetailsNoRegistration();
            Bundle b = new Bundle();
            b.putSerializable("passenger", passenger);
            travelFragment.setArguments(b);
            getActivity().getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, travelFragment).addToBackStack(null).commit();
        }else {
            focusView.requestFocus();
        }
    }

    private void initEditTextErrors(){
        setError(firstNameView, null);
        setError(lastNameView, null);
        setError(idView, null);
        setError(phoneNumberView, null);
        setError(emailView, null);
        setError(creditCardView, null);
    }

    private void setError(EditText view, String error){
        view.setError(error);
    }

    private void getData(){
        firstName = firstNameView.getText().toString();
        lastName = lastNameView.getText().toString();
        id = idView.getText().toString();
        phoneNumber = phoneNumberView.getText().toString();
        email = emailView.getText().toString();
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
        if(Validation.isEmailEmpty(email)){
            setError(emailView, getString(R.string.error_field_required));
            focusView = emailView;
            isValid = false;
        }else if(!Validation.isEmailValid(email)){
            setError(emailView, getString(R.string.error_invalid_email));
            focusView = emailView;
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
