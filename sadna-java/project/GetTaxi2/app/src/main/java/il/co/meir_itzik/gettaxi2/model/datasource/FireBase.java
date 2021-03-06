package il.co.meir_itzik.gettaxi2.model.datasource;

import android.content.Intent;
import android.support.annotation.NonNull;

import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.sql.Timestamp;
import java.util.ArrayList;

import il.co.meir_itzik.gettaxi2.model.Authentication.Firebase;
import il.co.meir_itzik.gettaxi2.model.entities.Driver;
import il.co.meir_itzik.gettaxi2.model.entities.Travel;
import il.co.meir_itzik.gettaxi2.utils.TravelCheckService;

public class FireBase implements DataSource {

    FirebaseDatabase database = FirebaseDatabase.getInstance();
    DatabaseReference drivers = database.getReference("Drivers");
    DatabaseReference travels = database.getReference("Travels");
    DatabaseReference pasTravels = database.getReference("TravelsByPassengers");

    @Override
    public void getDriver(String key, final RunAction<Driver> action){
        action.onPreExecute();
        drivers.child(key).addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                action.onSuccess(dataSnapshot.getValue(Driver.class));
                action.onPostExecute();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {
                action.onFailure(null, new Exception(databaseError.getMessage()));
                action.onPostExecute();
            }
        });
    }

    @Override
    public void addDriver(final Driver driver, final RunAction<Driver> action) {
        action.onPreExecute();
        drivers.child(driver.getKey()).setValue(driver).addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {
                action.onSuccess(driver);
                action.onPostExecute();
            }
        }).addOnFailureListener(new OnFailureListener() {
            @Override
            public void onFailure(@NonNull Exception e) {
                action.onFailure(driver, e);
                action.onPostExecute();
            }
        });
    }

    @Override
    public void getOpenTravels(final RunAction<ArrayList<Travel>> action) {
        action.onPreExecute();
        travels.orderByChild("status").equalTo(Travel.Status.OPEN.toString()).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                ArrayList<Travel> travelsList = new ArrayList<>();
                for (DataSnapshot item: dataSnapshot.getChildren()){
                    travelsList.add(item.getValue(Travel.class));
                }
                action.onSuccess(travelsList);
                action.onPostExecute();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {
                action.onFailure(null, new Exception(databaseError.getMessage()));
                action.onPostExecute();
            }
        });
    }

    @Override
    public void updateTravel(final Travel travel, final RunAction<Travel> action) {
        action.onPreExecute();
        travels.child(travel.getTravelsKey()).setValue(travel).addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {
                pasTravels.child(travel.getPassenger().getKey()).child(travel.getKey()).setValue(travel).addOnSuccessListener(new OnSuccessListener<Void>() {
                    @Override
                    public void onSuccess(Void aVoid) {
                        action.onSuccess(travel);
                        action.onPostExecute();
                    }
                }).addOnFailureListener(new OnFailureListener() {
                    @Override
                    public void onFailure(@NonNull Exception e) {
                        action.onFailure(travel, new Exception(e.getMessage()));
                        action.onPostExecute();
                    }
                });
            }
        }).addOnFailureListener(new OnFailureListener() {
            @Override
            public void onFailure(@NonNull Exception e) {
                action.onFailure(travel, new Exception(e.getMessage()));
                action.onPostExecute();
            }
        });
    }

    @Override
    public void getMyTravels(final Driver driver, final RunAction<ArrayList<Travel>> action) {
        action.onPreExecute();
        travels.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                ArrayList<Travel> travelsList = new ArrayList<>();
                for (DataSnapshot item: dataSnapshot.getChildren()){
                    Travel travel = item.getValue(Travel.class);
                    if(travel.getDriver() != null){
                        if(travel.getStatus() != Travel.Status.OPEN && travel.getDriver().getEmail().equals(driver.getEmail())){

                            travelsList.add(travel);
                        }
                    }
                }
                action.onSuccess(travelsList);
                action.onPostExecute();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {
                action.onFailure(null, new Exception(databaseError.getMessage()));
                action.onPostExecute();
            }
        });
    }

    @Override
    public void getTravelsByTimestamp(Timestamp from, final RunAction<ArrayList<Travel>> action) {
        action.onPreExecute();
        travels.orderByChild("timestamp").startAt(Long.toString(from.getTime())).addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                ArrayList<Travel> travels = new ArrayList<>();
                for(DataSnapshot ds : dataSnapshot.getChildren()) {
                    travels.add(ds.getValue(Travel.class));
                }
                action.onSuccess(travels);
                action.onPostExecute();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {
                action.onFailure(null, databaseError.toException());
                action.onPostExecute();
            }
        });
    }
}
