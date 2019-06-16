package il.co.meir_itzik.gettaxi2.utils;

import android.Manifest;
import android.app.Activity;
import android.content.Context;
import android.content.pm.PackageManager;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.support.v4.app.ActivityCompat;

import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.tasks.OnSuccessListener;

import il.co.meir_itzik.gettaxi2.utils.travelList.onListItemClickListener;

public class LocationService implements LocationListener {

    private Location driverLocation = null;

    LocationManager locManager;
    FusedLocationProviderClient mFusedLocationProviderClient;

    onLocationChangedListener listener;

    public LocationService(Context context, Activity activity){


        locManager = (LocationManager)context.getSystemService(Context.LOCATION_SERVICE);
        mFusedLocationProviderClient = LocationServices.getFusedLocationProviderClient(activity);

        boolean permissionsGranted = ActivityCompat.checkSelfPermission(context, Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED
                && ActivityCompat.checkSelfPermission(context, Manifest.permission.ACCESS_COARSE_LOCATION) == PackageManager.PERMISSION_GRANTED
                && ActivityCompat.checkSelfPermission(context, Manifest.permission.INTERNET) == PackageManager.PERMISSION_GRANTED;

        if(!permissionsGranted){
            ActivityCompat.requestPermissions(
                    activity,
                    new String[]{Manifest.permission.ACCESS_COARSE_LOCATION, Manifest.permission.ACCESS_FINE_LOCATION,Manifest.permission.INTERNET,},
                    100);
        }

        boolean locationEnabled = locManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER) && locManager.isProviderEnabled(LocationManager.GPS_PROVIDER);

        if(locationEnabled){

            mFusedLocationProviderClient.getLastLocation().addOnSuccessListener(activity, new OnSuccessListener<Location>() {
                @Override
                public void onSuccess(Location location) {
                    driverLocation = location;
                }
            });
        }
    }

    @Override
    public void onLocationChanged(Location location) {
        driverLocation = location;
        listener.onLocationChanged();
    }

    @Override
    public void onStatusChanged(String provider, int status, Bundle extras) {

    }

    @Override
    public void onProviderEnabled(String provider) {

    }

    @Override
    public void onProviderDisabled(String provider) {

    }

    public Location getLocation(){
        return driverLocation;
    }

    public interface onLocationChangedListener{
        void onLocationChanged();
    }

}
