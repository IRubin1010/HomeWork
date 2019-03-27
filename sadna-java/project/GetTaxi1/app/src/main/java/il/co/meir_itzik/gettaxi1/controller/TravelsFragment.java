package il.co.meir_itzik.gettaxi1.controller;

import static java.lang.Math.min;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;

import il.co.meir_itzik.gettaxi1.R;
import il.co.meir_itzik.gettaxi1.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi1.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi1.model.entities.Travel;
import il.co.meir_itzik.gettaxi1.model.utils.TravelListAdapter;

public class TravelsFragment extends Fragment {

    DataSource DB = BackendFactory.getDatasource();

    public TravelsFragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view =  inflater.inflate(R.layout.fragment_travels, container, false);

        ListView listView = view.findViewById(R.id.travels_lst);

        ArrayList<Travel> travelList = DB.getTravels();

        ArrayList<Travel> travelsToRepresent = new ArrayList<>(travelList.subList(0, min(travelList.size(), 10)));

        TravelListAdapter adapter = new TravelListAdapter(getActivity(), R.layout.travel_list_item,travelsToRepresent);

        listView.setAdapter(adapter);

        //TODO add listener when add travel to display the new

        return view;
    }
}
