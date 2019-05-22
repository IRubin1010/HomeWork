package il.co.meir_itzik.gettaxi2.model.datasource;

import android.support.annotation.NonNull;

import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;

import il.co.meir_itzik.gettaxi2.model.entities.Driver;
import il.co.meir_itzik.gettaxi2.model.entities.Travel;

public class FireBase implements DataSource {

    FirebaseDatabase database = FirebaseDatabase.getInstance();
    DatabaseReference drivers = database.getReference("Drivers");
    DatabaseReference travels = database.getReference("Travels");

    @Override
    public void isDriverExist(Driver driver, final RunAction<Boolean> action) {
        isDriverExistByKey(driver.getKey(), action);
    }

    @Override
    public void isDriverExistByEmailAndPassword(String email, String password, final RunAction<Boolean> action) {
        isDriverExistByKey(email + "-" + password, action);
    }

    private void isDriverExistByKey(String key, final RunAction<Boolean> action){
        action.onPreExecute();
        drivers.child(key).addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                action.onSuccess(dataSnapshot.exists());
                action.onPostExecute();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {
                action.onFailure(null, new Exception(databaseError.getMessage()));
                action.onPostExecute();
            }
        });
    }

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
    public void updateTravelStatus(final Travel travel, Travel.Status status, final RunAction<Travel> action) {
        action.onPreExecute();
        travels.child(travel.getPassenger().getEmail().replace('.','|') +'-' + travel.getKey()).child("status").setValue(status).addOnSuccessListener(new OnSuccessListener<Void>() {
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
}
