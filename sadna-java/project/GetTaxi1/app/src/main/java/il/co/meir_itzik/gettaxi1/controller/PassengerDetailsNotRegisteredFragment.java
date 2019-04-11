package il.co.meir_itzik.gettaxi1.controller;


import android.content.Context;
import android.graphics.Color;
import android.graphics.Paint;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import il.co.meir_itzik.gettaxi1.R;
import il.co.meir_itzik.gettaxi1.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi1.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.utils.Validation;


public class PassengerDetailsNotRegisteredFragment extends Fragment {

    EditText firstNameView, lastNameView, idView, phoneNumberView, emailView, creditCardView;
    String firstName, lastName, id, phoneNumber, email, creditCard;
    View focusView = null, progressView;
    Button nextBtn, cancelBtn;
    DataSource DB = BackendFactory.getDatasource();

    public PassengerDetailsNotRegisteredFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_passenger_details_not_registered, container, false);

        firstNameView = view.findViewById(R.id.first_name);
        lastNameView = view.findViewById(R.id.last_name);
        idView = view.findViewById(R.id.id);
        phoneNumberView = view.findViewById(R.id.phone_number);
        emailView = view.findViewById(R.id.email);
        creditCardView = view.findViewById(R.id.credit_card);
        nextBtn = view.findViewById(R.id.next);
        cancelBtn = view.findViewById(R.id.cancel);

        progressView = getActivity().findViewById(R.id.progress);

        cancelBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                emptyFields();
            }
        });

        nextBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                nextClick();
            }
        });
        return view;
    }

    private void emptyFields(){
        firstNameView.setText("");
        lastNameView.setText("");
        idView.setText("");
        phoneNumberView.setText("");
        emailView.setText("");
        creditCardView.setText("");
    }

    private void nextClick(){
        initEditTextErrors();
        getData();
        if(isDataValid()){

            final Passenger passenger = new Passenger(firstName, lastName, id, email, phoneNumber, creditCard);

            DB.addPassenger(passenger, new DataSource.RunAction<Passenger>() {
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
                public void onSuccess(Passenger obj) {

                }

                @Override
                public void onFailure(Passenger obj, Exception e) {
                    Toast toast = Toast.makeText(getContext(), "failed to get passenger details" + e.getMessage(), Toast.LENGTH_SHORT);
                    TextView v = toast.getView().findViewById(android.R.id.message);
                    v.setTextColor(Color.RED);
                    toast.show();
                }

                @Override
                public void onPostExecute() {
                    progressView.setVisibility(View.INVISIBLE);
                    emptyFields();
                    getActivity().getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                    Fragment travelFragment = new TravelDetailsNotRegisteredFragment();
                    Bundle b = new Bundle();
                    b.putSerializable("passenger", passenger);
                    travelFragment.setArguments(b);
                    getActivity().getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, travelFragment).addToBackStack(null).commit();
                }
            });

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
        }else if(!Validation.isIdValid(id)){
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
