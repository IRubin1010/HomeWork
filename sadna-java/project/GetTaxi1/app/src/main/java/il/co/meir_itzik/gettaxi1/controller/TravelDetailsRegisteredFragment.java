package il.co.meir_itzik.gettaxi1.controller;

import android.app.TimePickerDialog;
import android.content.Context;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.os.Bundle;
import android.preference.PreferenceManager;
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

import com.google.gson.Gson;

import java.util.Calendar;
import java.util.TimeZone;

import il.co.meir_itzik.gettaxi1.R;
import il.co.meir_itzik.gettaxi1.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi1.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.entities.Travel;
import il.co.meir_itzik.gettaxi1.model.utils.Validation;


public class TravelDetailsRegisteredFragment extends Fragment {

    EditText fromView, destinationView, timeView, commentView;
    String from, destination, time = "",  comment, date;
    int hour, minute;
    Button orderBtn;
    View focusView = null, progressView;
    TextView clearTimeView;
    DataSource DB = BackendFactory.getDatasource();
    Passenger passenger;
    SharedPreferences prefs;
    Travel travel;
    boolean isTimeSelected = false;

    public TravelDetailsRegisteredFragment(){

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view =  inflater.inflate(R.layout.fragment_travel_details_registered, container, false);

        prefs = PreferenceManager.getDefaultSharedPreferences(getActivity());
        String passengerStr = prefs.getString("passenger","");
        Gson gson = new Gson();
        passenger = gson.fromJson(passengerStr, Passenger.class);

        progressView = getActivity().findViewById(R.id.progress);

        fromView = view.findViewById(R.id.from);
        destinationView = view.findViewById(R.id.destination);
        commentView = view.findViewById(R.id.comment);

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
                        isTimeSelected = true;
                        hour = selectedHour;
                        minute = selectedMinute;
                        clearTimeView.setVisibility(View.VISIBLE);
                    }
                }, hour, minute, true);//Yes 24 hour time
                timePicker.setTitle("Select Time");
                timePicker.show();

            }
        });

        clearTimeView = view.findViewById(R.id.clear_time);
        clearTimeView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(!time.equals("")){
                    timeView.setText("");
                    time = "";
                }
                clearTimeView.setVisibility(View.INVISIBLE);
                isTimeSelected = false;
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
            Calendar c = Calendar.getInstance(TimeZone.getTimeZone("Asia/Jerusalem"));
            if(isTimeSelected){
                c.set(Calendar.HOUR_OF_DAY, hour);
                c.set(Calendar.MINUTE, minute);
                if(date.equals("tomorrow")){
                    c.set(Calendar.DAY_OF_MONTH, c.get(Calendar.DAY_OF_MONTH) + 1);
                }
            }
            travel = new Travel(from, destination, c.getTime(), Travel.Status.OPEN, passenger);
            //TODO add comment to travel

            DB.addTravel(travel, new DataSource.RunAction<Travel>() {
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
                public void onSuccess(Travel obj) {
                    Toast toast = Toast.makeText(getContext(), "your order has been accepted", Toast.LENGTH_SHORT);
                    TextView v = toast.getView().findViewById(android.R.id.message);
                    v.setTextColor(Color.GREEN);
                    toast.show();
                }

                @Override
                public void onFailure(Travel obj, Exception e) {
                    Toast toast = Toast.makeText(getContext(), "failed to get Travel details" + e.getMessage(), Toast.LENGTH_SHORT);
                    TextView v = toast.getView().findViewById(android.R.id.message);
                    v.setTextColor(Color.RED);
                    toast.show();
                }

                @Override
                public void onPostExecute() {
                    progressView.setVisibility(View.INVISIBLE);
                    emptyFields();
                    getActivity().getWindow().clearFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE);
                }
            });
        }

    }

}
