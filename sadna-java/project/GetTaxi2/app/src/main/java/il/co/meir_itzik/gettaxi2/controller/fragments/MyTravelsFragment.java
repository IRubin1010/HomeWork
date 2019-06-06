package il.co.meir_itzik.gettaxi2.controller.fragments;


import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.helper.ItemTouchHelper;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.model.entities.Driver;
import il.co.meir_itzik.gettaxi2.utils.SharedPreferencesService;
import il.co.meir_itzik.gettaxi2.utils.travelList.TravelListCaller;
import il.co.meir_itzik.gettaxi2.utils.travelList.onListItemClickListener;
import il.co.meir_itzik.gettaxi2.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi2.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi2.model.entities.Travel;
import il.co.meir_itzik.gettaxi2.utils.travelList.TravelItemRecyclerViewAdapter;
import il.co.meir_itzik.gettaxi2.utils.swipeContoller.SwipeController;
import il.co.meir_itzik.gettaxi2.utils.swipeContoller.SwipeControllerActions;


/**
 * A simple {@link Fragment} subclass.
 */
public class MyTravelsFragment extends Fragment {

    private int mColumnCount = 1;
    private DataSource DB = BackendFactory.getDatasource();
    private RecyclerView recyclerView;

    private onListItemClickListener mListener;

    private SharedPreferencesService prefs;

    private Driver driver;

    public MyTravelsFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_open_travels, container, false);

        // Set the adapter
        if (view instanceof RecyclerView) {
            Context context = view.getContext();

            prefs = new SharedPreferencesService(getActivity());
            driver = prefs.getDriver();

            recyclerView = (RecyclerView) view;
            if (mColumnCount <= 1) {
                recyclerView.setLayoutManager(new LinearLayoutManager(context));
            } else {
                recyclerView.setLayoutManager(new GridLayoutManager(context, mColumnCount));
            }

            DB.getMyTravels(driver, new DataSource.RunAction<ArrayList<Travel>>() {
                @Override
                public void onPreExecute() {

                }

                @Override
                public void onSuccess(ArrayList<Travel> travels) {

                    final TravelItemRecyclerViewAdapter adapter = new TravelItemRecyclerViewAdapter(travels, mListener, TravelListCaller.MY_TRAVELS);
                    recyclerView.setAdapter(adapter);
                    final SwipeController swipeController = new SwipeController(SwipeController.CallerFragment.MY_TRAVELS ,new SwipeControllerActions() {
                        @Override
                        public void onLeftClicked(int position) {
                            Travel travel = adapter.mValues.get(position);
                            travel.setStatus(Travel.Status.FINISH);
                            DB.updateTravel(travel, new DataSource.RunAction<Travel>() {
                                @Override
                                public void onPreExecute() {

                                }

                                @Override
                                public void onSuccess(Travel obj) {
                                    Toast toast = Toast.makeText(getActivity(), "Travel finished successfully", Toast.LENGTH_SHORT);
                                    TextView v = toast.getView().findViewById(android.R.id.message);
                                    v.setTextColor(Color.GREEN);
                                    toast.show();
                                }

                                @Override
                                public void onFailure(Travel obj, Exception e) {
                                    Toast toast = Toast.makeText(getActivity(), "failed to finish travel", Toast.LENGTH_SHORT);
                                    TextView v = toast.getView().findViewById(android.R.id.message);
                                    v.setTextColor(Color.RED);
                                    toast.show();
                                }

                                @Override
                                public void onPostExecute() {

                                }
                            });
                        }
                    }, getActivity());

                    ItemTouchHelper itemTouchhelper = new ItemTouchHelper(swipeController);
                    itemTouchhelper.attachToRecyclerView(recyclerView);

                    recyclerView.addItemDecoration(new RecyclerView.ItemDecoration() {
                        @Override
                        public void onDraw(Canvas c, RecyclerView parent, RecyclerView.State state) {
                            swipeController.onDraw(c);
                        }
                    });
                }

                @Override
                public void onFailure(ArrayList<Travel> obj, Exception e) {
                    Toast toast = Toast.makeText(getActivity(), "failed to get travels from FireBase: " + e.getMessage(), Toast.LENGTH_SHORT);
                    TextView v = toast.getView().findViewById(android.R.id.message);
                    v.setTextColor(Color.RED);
                    toast.show();
                }

                @Override
                public void onPostExecute() {

                }
            });


        }
        return view;
    }


    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof onListItemClickListener) {
            mListener = (onListItemClickListener) context;
        } else {
            throw new RuntimeException(context.toString()
                    + " must implement onListItemClickListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }

}
