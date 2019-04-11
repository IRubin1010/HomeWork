package il.co.meir_itzik.gettaxi1.controller;


import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.os.Bundle;
import android.preference.PreferenceManager;
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

import com.google.gson.Gson;

import il.co.meir_itzik.gettaxi1.R;
import il.co.meir_itzik.gettaxi1.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi1.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.utils.Validation;

public class RegistrationDetailsFragment extends Fragment {

    EditText idView, phoneNumberView, creditCardView;
    String firstName, lastName, id, email, phoneNumber, creditCard;
    View focusView = null, progressView;
    Button registerBtn, cancelBtn;
    DataSource DB = BackendFactory.getDatasource();
    Passenger passenger;
    SharedPreferences prefs;

    public RegistrationDetailsFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_registration_details, container, false);

        prefs = PreferenceManager.getDefaultSharedPreferences(getActivity());

        firstName = getArguments().getString("fName");
        lastName = getArguments().getString("lName");
        email = getArguments().getString("email");

        progressView = getActivity().findViewById(R.id.progress);

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

    private void register() {
        initEditTextErrors();
        getData();
        if (isDataValid()) {
            passenger = new Passenger(firstName, lastName, id, email, phoneNumber, creditCard);

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
                    Gson gson = new Gson();
                    String pasJson = gson.toJson(passenger);
                    prefs.edit().putString("passenger", pasJson).apply();
                    prefs.edit().putBoolean("loggedIn", true).apply();
                    progressView.setVisibility(View.INVISIBLE);

                    Toast toast = Toast.makeText(getContext(), "registered successfully", Toast.LENGTH_SHORT);
                    TextView v = toast.getView().findViewById(android.R.id.message);
                    v.setTextColor(Color.GREEN);
                    toast.show();

                    getActivity().getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                    Intent registered = new Intent(getActivity(), RegisteredActivity.class);
                    registered.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                    startActivity(registered);
                }

                @Override
                public void onFailure(Passenger obj, Exception e) {
                    Toast toast = Toast.makeText(getContext(), "failed to get registration details" + e.getMessage(), Toast.LENGTH_SHORT);
                    TextView v = toast.getView().findViewById(android.R.id.message);
                    v.setTextColor(Color.RED);
                    toast.show();
                }

                @Override
                public void onPostExecute() {

                }
            });
        } else {
            focusView.requestFocus();
        }
    }

    private void emptyFields() {
        idView.setText("");
        phoneNumberView.setText("");
        creditCardView.setText("");
    }

    private void initEditTextErrors() {
        setError(idView, null);
        setError(phoneNumberView, null);
        setError(creditCardView, null);
    }

    private void setError(EditText view, String error) {
        view.setError(error);
    }

    private void getData() {
        id = idView.getText().toString();
        phoneNumber = phoneNumberView.getText().toString();
        creditCard = creditCardView.getText().toString();
    }

    private Boolean isDataValid() {
        boolean isValid = true;
        if (Validation.isIdEmpty(id)) {
            setError(idView, getString(R.string.error_field_required));
            focusView = idView;
            isValid = false;
        } else if (!Validation.isCreditCardValid(id)) {
            setError(idView, getString(R.string.error_invalid_id));
            focusView = idView;
            isValid = false;
        }
        if (Validation.isPhoneNumberEmpty(phoneNumber)) {
            setError(phoneNumberView, getString(R.string.error_field_required));
            focusView = phoneNumberView;
            isValid = false;
        } else if (!Validation.isPhoneNumberValid(phoneNumber)) {
            setError(phoneNumberView, getString(R.string.error_invalid_phone_number));
            focusView = phoneNumberView;
            isValid = false;
        }
        if (Validation.isCreditCardEmpty(creditCard)) {
            setError(creditCardView, getString(R.string.error_field_required));
            focusView = creditCardView;
            isValid = false;
        } else if (!Validation.isCreditCardValid(creditCard)) {
            setError(creditCardView, getString(R.string.error_invalid_credit_card));
            focusView = creditCardView;
            isValid = false;
        }
        return isValid;
    }


}
