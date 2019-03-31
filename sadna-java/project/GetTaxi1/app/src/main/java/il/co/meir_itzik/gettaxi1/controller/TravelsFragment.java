package il.co.meir_itzik.gettaxi1.controller;

import static java.lang.Math.min;

import android.content.SharedPreferences;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.List;

import il.co.meir_itzik.gettaxi1.R;
import il.co.meir_itzik.gettaxi1.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi1.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.entities.Travel;
import il.co.meir_itzik.gettaxi1.model.utils.TravelListAdapter;

public class TravelsFragment extends Fragment {

    DataSource DB = BackendFactory.getDatasource();
    SharedPreferences prefs;
    Passenger passenger;

    public TravelsFragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view =  inflater.inflate(R.layout.fragment_travels, container, false);

        final ListView listView = view.findViewById(R.id.travels_lst);

        prefs = PreferenceManager.getDefaultSharedPreferences(getActivity());
        String passengerStr = prefs.getString("passenger","");
        Gson gson = new Gson();
        passenger = gson.fromJson(passengerStr, Passenger.class);

        DB.getTravels(passenger, new DataSource.RunAction<ArrayList<Travel>>() {
            @Override
            public void onPreExecute() {

            }

            @Override
            public void onSuccess(ArrayList<Travel> obj) {
                ArrayList<Travel> travelsToRepresent = new ArrayList<>(obj.subList(0, min(obj.size(), 10)));

                TravelListAdapter adapter = new TravelListAdapter(getActivity(), R.layout.travel_list_item,travelsToRepresent);

                listView.setAdapter(adapter);
            }

            @Override
            public void onFailure(ArrayList<Travel> obj, Exception e) {

            }

            @Override
            public void onPostExecute() {

            }
        });

        //TODO add listener when add travel to display the new

        return view;
    }
}
