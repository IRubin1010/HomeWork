package il.co.meir_itzik.gettaxi1.controller;

import android.app.TimePickerDialog;
import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.text.InputType;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TimePicker;
import android.widget.Toast;

import java.util.Calendar;
import java.util.TimeZone;
import java.util.Timer;
import java.util.TimerTask;

import il.co.meir_itzik.gettaxi1.R;
import il.co.meir_itzik.gettaxi1.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi1.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.entities.Travel;
import il.co.meir_itzik.gettaxi1.model.utils.Validation;


public class TravelDetailsNoRegistration extends Fragment {

    EditText fromView, destinationView, timeView;
    String from, destination, time,  comment, date;
    int hour, minute;
    Button orderBtn, cancelBtn;
    View focusView = null, progressView;
    Passenger passenger;
    DataSource DB = BackendFactory.getDatasource();


    public TravelDetailsNoRegistration() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view =  inflater.inflate(R.layout.fragment_travel_details_no_registration, container, false);

        passenger = (Passenger)getArguments().getSerializable("passenger");

        progressView = getActivity().findViewById(R.id.order_progress);

        fromView = view.findViewById(R.id.from);
        destinationView = view.findViewById(R.id.destination);

        timeView = view.findViewById(R.id.time);
        timeView.setInputType(InputType.TYPE_NULL);
        timeView.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                Calendar currentTime = Calendar.getInstance(TimeZone.getTimeZone("Asia/Jerusalem"));
                hour = currentTime.get(Calendar.HOUR_OF_DAY);
                minute = currentTime.get(Calendar.MINUTE);
                TimePickerDialog timePicker;
                timePicker = new TimePickerDialog(getContext(), new TimePickerDialog.OnTimeSetListener() {
                    @Override
                    public void onTimeSet(TimePicker timePicker, int selectedHour, int selectedMinute) {
                        String chosenMinute, chosenHour;
                        if(selectedMinute < 10) chosenMinute = "0" + selectedMinute;
                        else chosenMinute = Integer.toString(selectedMinute);
                        if(selectedHour < 10) chosenHour = "0" + selectedHour;
                        else chosenHour = Integer.toString(selectedHour);
                        if(selectedHour < hour || (selectedHour == hour && selectedMinute < minute)) date = "tomorrow";
                        else date = "today";
                        time = date + " at " + chosenHour + ":" + chosenMinute;
                        timeView.setText(time);
                    }
                }, hour, minute, true);//Yes 24 hour time
                timePicker.setTitle("Select Time");
                timePicker.show();

            }
        });

        cancelBtn = view.findViewById(R.id.cancel);
        cancelBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                emptyFields();
                getFragmentManager().popBackStack();
            }
        });

        orderBtn = view.findViewById(R.id.order);
        orderBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                orderTravel();
            }
        });

        return view;
    }

    private void emptyFields(){
        fromView.setText("");
        destinationView.setText("");
        timeView.setText("");
    }

    private void orderTravel(){

        fromView.setError(null);
        destinationView.setError(null);

        from = fromView.getText().toString();
        destination = destinationView.getText().toString();

        Boolean cancel = false;

        if(Validation.isFromAddressEmpty(from)){
            fromView.setError(getString(R.string.error_field_required));
            focusView = fromView;
            cancel = true;
        }

        if(Validation.isDestinationAddressEmpty(destination)){
            destinationView.setError(getString(R.string.error_field_required));
            focusView = destinationView;
            cancel = true;
        }

        if(cancel){
            focusView.requestFocus();
        }else{
            Calendar c = Calendar.getInstance();
            c.set(Calendar.HOUR, hour);
            c.set(Calendar.MINUTE, minute);
            Travel travel = new Travel(from, destination, c.getTime(), Travel.Status.OPEN, passenger);
            View view = getActivity().getCurrentFocus();
            if (view != null) {
                InputMethodManager imm = (InputMethodManager)getActivity().getSystemService(Context.INPUT_METHOD_SERVICE);
                imm.hideSoftInputFromWindow(view.getWindowToken(), 0);
            }
            progressView.setVisibility(View.VISIBLE);
            // make user the user cannot touch the screen
            getActivity().getWindow().setFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE,
                    WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
            DB.addPassenger(passenger);
            DB.addTravel(travel);
            long delayInMillis = 2000;
            Timer timer = new Timer();
            timer.schedule(new TimerTask() {
                @Override
                public void run() {
                    getActivity().runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            progressView.setVisibility(View.INVISIBLE);
                            emptyFields();
                            Toast.makeText(getActivity().getApplicationContext(), "your order has been accepted", Toast.LENGTH_SHORT).show();
                        }
                    });
                }
            }, delayInMillis);
            // release the screen
            getActivity().getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
            /**
             * end
             */
        }

    }
}
