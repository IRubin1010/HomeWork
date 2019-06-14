package il.co.meir_itzik.gettaxi2.controller.fragments;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.model.entities.Driver;
import il.co.meir_itzik.gettaxi2.utils.SharedPreferencesService;


public class DashboardFragment extends Fragment {

    private SharedPreferencesService prefs;
    public DashboardFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_dashboard, container, false);

        prefs = new SharedPreferencesService(getContext());
        Driver driver = prefs.getDriver();

        TextView nameTV = view.findViewById(R.id.name_text_view);
        nameTV.setText("hello " + driver.getFirstName() + " " + driver.getLastName());
        return view;
    }

}
