package il.co.meir_itzik.gettaxi2.controller.fragments;

import android.annotation.SuppressLint;
import android.content.ClipData;
import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.v4.app.Fragment;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.SearchView;
import android.support.v7.widget.helper.ItemTouchHelper;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.EditorInfo;
import android.widget.ActionMenuView;
import android.widget.ActionMenuView.OnMenuItemClickListener;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.model.entities.Driver;
import il.co.meir_itzik.gettaxi2.utils.LocationService;
import il.co.meir_itzik.gettaxi2.utils.SharedPreferencesService;
import il.co.meir_itzik.gettaxi2.utils.travelList.TravelListCaller;
import il.co.meir_itzik.gettaxi2.utils.travelList.onListItemClickListener;
import il.co.meir_itzik.gettaxi2.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi2.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi2.model.entities.Travel;
import il.co.meir_itzik.gettaxi2.utils.swipeContoller.SwipeController;
import il.co.meir_itzik.gettaxi2.utils.swipeContoller.SwipeControllerActions;
import il.co.meir_itzik.gettaxi2.utils.travelList.TravelItemRecyclerViewAdapter;


public class OpenTravelsFragment extends Fragment implements LocationService.onLocationChangedListener {

    private int mColumnCount = 1;
    private DataSource DB = BackendFactory.getDatasource();
    private RecyclerView recyclerView;
    private TravelItemRecyclerViewAdapter adapter;

    private onListItemClickListener mListener;

    private SharedPreferencesService prefs;

    private Driver driver;

    private LocationService locationService;

    private View view;

    public OpenTravelsFragment() {
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @SuppressLint("ResourceType")
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_open_travels, container, false);

        locationService = new LocationService(getContext(),this);

        setHasOptionsMenu(true);
        // Set the adapter
        if (view instanceof RecyclerView) {
            this.view = view;
            if(locationService.checkPermissions()){
                initView();
            }else{
                locationService.askPermissions();
            }
        }
        return view;
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
        inflater.inflate(R.menu.filter_menu, menu);

        MenuItem searchItem = menu.findItem(R.id.action_search);
        SearchView searchView = (android.support.v7.widget.SearchView) searchItem.getActionView();

        searchView.setImeOptions(EditorInfo.IME_ACTION_DONE);

        searchView.setQueryHint("insert distance");

        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                adapter.getFilter().filter(newText);
                return false;
            }
        });
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

    @Override
    public void onLocationChanged() {
        recyclerView.setAdapter(adapter);
        adapter.notifyDataSetChanged();
    }

    private void initView(){
        Context context = view.getContext();

        prefs = new SharedPreferencesService(getActivity());
        driver = prefs.getDriver();
        recyclerView = (RecyclerView) view;
        if (mColumnCount <= 1) {
            recyclerView.setLayoutManager(new LinearLayoutManager(context));
        } else {
            recyclerView.setLayoutManager(new GridLayoutManager(context, mColumnCount));
        }

        DB.getOpenTravels(new DataSource.RunAction<ArrayList<Travel>>() {
            @Override
            public void onPreExecute() {

            }

            @Override
            public void onSuccess(ArrayList<Travel> travels) {

                adapter = new TravelItemRecyclerViewAdapter(travels, mListener, TravelListCaller.OPEN_TRAVELS, locationService);
                recyclerView.setAdapter(adapter);
                final SwipeController swipeController = new SwipeController(SwipeController.CallerFragment.OPEN_TRAVELS ,new SwipeControllerActions() {
                    @Override
                    public void onLeftClicked(int position) {
                        Travel travel = adapter.mValues.get(position);
                        travel.setDriver(driver);
                        travel.setStatus(Travel.Status.IN_PROGRESS);
                        DB.updateTravel(travel, new DataSource.RunAction<Travel>() {
                            @Override
                            public void onPreExecute() {

                            }

                            @Override
                            public void onSuccess(Travel obj) {
                                Toast toast = Toast.makeText(getActivity(), "Travel accepted successfully", Toast.LENGTH_SHORT);
                                TextView v = toast.getView().findViewById(android.R.id.message);
                                v.setTextColor(Color.GREEN);
                                toast.show();
                            }

                            @Override
                            public void onFailure(Travel obj, Exception e) {
                                Toast toast = Toast.makeText(getActivity(), "failed to accept travel", Toast.LENGTH_SHORT);
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

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        if(locationService.checkPermissions())
            initView();
    }
}
