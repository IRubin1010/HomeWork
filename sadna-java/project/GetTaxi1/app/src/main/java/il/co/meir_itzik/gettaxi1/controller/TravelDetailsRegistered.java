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
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import java.util.Calendar;
import java.util.TimeZone;

import il.co.meir_itzik.gettaxi1.R;
import il.co.meir_itzik.gettaxi1.model.backend.RunDbActionAsync;
import il.co.meir_itzik.gettaxi1.model.entities.Travel;
import il.co.meir_itzik.gettaxi1.model.utils.Validation;


public class TravelDetailsRegistered extends Fragment {

    EditText fromView, destinationView, timeView, commentView;
    String from, destination, time = "",  comment, date;
    int hour, minute;
    Button orderBtn;
    View focusView = null, progressView;
    TextView clearTimeView;

    public TravelDetailsRegistered(){

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view =  inflater.inflate(R.layout.fragment_travel_details_registered, container, false);

        progressView = getActivity().findViewById(R.id.order_progress);

        fromView = view.findViewById(R.id.from);
        destinationView = view.findViewById(R.id.destination);
        commentView = view.findViewById(R.id.comment);
        clearTimeView = view.findViewById(R.id.clear_time);

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
                        clearTimeView.setVisibility(View.VISIBLE);
                    }
                }, hour, minute, true);//Yes 24 hour time
                timePicker.setTitle("Select Time");
                timePicker.show();

            }
        });

        clearTimeView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(time.equals("")){
                    clearTimeView.setVisibility(View.INVISIBLE);
                }
                else{
                    timeView.setText("");
                    time = "";
                    clearTimeView.setVisibility(View.INVISIBLE);
                }
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
        commentView.setText("");
    }

    private void orderTravel(){

        fromView.setError(null);
        destinationView.setError(null);

        from = fromView.getText().toString();
        destination = destinationView.getText().toString();
        comment = commentView.getText().toString();

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
            //travel = new Travel(from, destination, c.getTime(), Travel.Status.OPEN, passenger);

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
//                    if(!DB.isPassengerExist(passenger)) DB.addPassenger(passenger);
//                    if(DB.isTravelExist(travel)) return null; // TODO add toast to say the travel already exist
//                    DB.addTravel(travel);
//                    try {
//                        Thread.sleep(3000);
//                    } catch (InterruptedException e) {
//                        e.printStackTrace();
//                    }
                    return null;
                }

                @Override
                public void onPostExecute() {
                    progressView.setVisibility(View.INVISIBLE);
                    emptyFields();
                    Toast.makeText(getActivity().getApplicationContext(), "your order has been accepted", Toast.LENGTH_SHORT).show();
                    getActivity().getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                    getFragmentManager().popBackStack();
                }
            }).execute();
        }

    }

}
