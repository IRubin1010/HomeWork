package il.co.meir_itzik.gettaxi1.controller;

import android.app.Activity;
import android.content.Intent;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.FragmentActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;

import com.google.android.gms.common.api.Status;
import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.android.libraries.places.api.Places;
import com.google.android.libraries.places.widget.AutocompleteSupportFragment;

import com.google.android.libraries.places.api.model.Place;
import com.google.android.libraries.places.widget.listener.PlaceSelectionListener;

import java.util.Arrays;
import java.util.List;
import java.util.Locale;

import il.co.meir_itzik.gettaxi1.R;
import il.co.meir_itzik.gettaxi1.model.utils.LocationPermissionsService;

public class MapsActivity extends FragmentActivity implements OnMapReadyCallback {

    private GoogleMap mMap;
    private Marker marker;
    private String locationStr;
    private EditText autoCompleteEditText;
    private Location currentLocation = null;
    private LatLng defaultLocation = new LatLng(32.090968, 34.822695);
    private boolean isLocationFromSearch = false;
    private Geocoder geocoder;
    private List<Address> addresses;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_maps);

        geocoder = new Geocoder(this, Locale.getDefault());

        if (!Places.isInitialized()) {
            Places.initialize(getApplicationContext(), "AIzaSyD1Waf5AOF_qr63TM5mjmuOlE33BsGN7UM");
        }

        AutocompleteSupportFragment autocompleteFragment = (AutocompleteSupportFragment)
                getSupportFragmentManager().findFragmentById(R.id.autocomplete_fragment);

        // Specify the types of place data to return.
        autocompleteFragment.setPlaceFields(Arrays.asList(Place.Field.ID, Place.Field.NAME, Place.Field.LAT_LNG, Place.Field.ADDRESS));
        autoCompleteEditText = autocompleteFragment.getView().findViewById(R.id.places_autocomplete_search_input);

        // Set up a PlaceSelectionListener to handle the response.
        autocompleteFragment.setOnPlaceSelectedListener(new PlaceSelectionListener() {
            @Override
            public void onPlaceSelected(Place place) {
                MoveToLocation(place.getLatLng());
                isLocationFromSearch = true;
            }

            @Override
            public void onError(Status status) {
                locationStr = null;
            }


        });

        FloatingActionButton setLocation = findViewById(R.id.select_location);
        setLocation.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String add = autoCompleteEditText.getText().toString();
                if (add.equals("") && isLocationFromSearch) locationStr = null;
                Intent returnIntent = new Intent();
                returnIntent.putExtra("location", locationStr);
                setResult(Activity.RESULT_OK, returnIntent);
                finish();
            }
        });
        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager()
                .findFragmentById(R.id.map);
        mapFragment.getMapAsync(this);
    }

    @Override
    public void onMapReady(final GoogleMap googleMap) {
        Log.i("maps", "map ready");
        mMap = googleMap;

        if (LocationPermissionsService.checkLocationPermission(this) && LocationPermissionsService.isLocationEnabled(this)) {
            mMap.setMyLocationEnabled(true);
            mMap.getUiSettings().setMyLocationButtonEnabled(true);
            getDeviceLocation();
        } else {
            mMap.setMyLocationEnabled(false);
            mMap.getUiSettings().setMyLocationButtonEnabled(false);

            MoveToLocation(defaultLocation);
        }

        mMap.setOnMyLocationButtonClickListener(new GoogleMap.OnMyLocationButtonClickListener() {
            @Override
            public boolean onMyLocationButtonClick() {
                getDeviceLocation();
                autoCompleteEditText.setText("");
                isLocationFromSearch = false;
                return true;
            }
        });
    }

    private void getDeviceLocation() {
        FusedLocationProviderClient mFusedLocationProviderClient = LocationServices.getFusedLocationProviderClient(this);
        try {
            Task locationResult = mFusedLocationProviderClient.getLastLocation();
            locationResult.addOnCompleteListener(this, new OnCompleteListener() {
                @Override
                public void onComplete(Task task) {
                    if (task.isSuccessful()) {
                        currentLocation = (Location) task.getResult();
                        if (currentLocation != null) {
                            MoveToLocation(currentLocation);
                        } else {
                            MoveToLocation(defaultLocation);
                        }

                    } else {
                        MoveToLocation(defaultLocation);
                    }
                }
            });
        } catch (SecurityException e) {
            Log.e("Exception: %s", e.getMessage());
        }
    }

    private void MoveToLocation(Location location) {
        MoveToLocation(new LatLng(location.getLatitude(), location.getLongitude()));
    }

    private void MoveToLocation(LatLng location) {
        if (marker != null) {
            marker.remove();
        }
        marker = mMap.addMarker(new MarkerOptions().position(location));
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(location, 18));
        locationStr = getAddress(location);
        autoCompleteEditText.setHint(locationStr);
    }

    private String getAddress(LatLng location) {
        try {
            addresses = geocoder.getFromLocation(location.latitude, location.longitude, 1);
            String address = addresses.get(0).getAddressLine(0);
            return address;
        } catch (Exception e) {
            return null;
        }
    }
}
