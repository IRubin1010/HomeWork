package il.co.meir_itzik.gettaxi1.model.datasource;

import android.support.annotation.NonNull;

import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.Query;
import com.google.firebase.database.ValueEventListener;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Collections;

import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.entities.Travel;

public class FireBase implements DataSource{

    private FirebaseDatabase database = FirebaseDatabase.getInstance();
    private DatabaseReference travelsByPassengers = database.getReference("TravelsByPassengers");
    private DatabaseReference passengers = database.getReference("Passengers");
    private DatabaseReference travels = database.getReference("Travels");

    @Override
    public void addTravel(final Travel travel, final RunAction<Travel> action) {
        action.onPreExecute();
        DatabaseReference pasTravels = travelsByPassengers.child(travel.getPassenger().getKey());
        final String key = travel.getKey();
        travel.setTimestamp(new Timestamp(System.currentTimeMillis()));
        pasTravels.child(key).setValue(travel).addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {
                travels.child(travel.getTravelsKey()).setValue(travel).addOnSuccessListener(new OnSuccessListener<Void>() {
                    @Override
                    public void onSuccess(Void aVoid) {
                        action.onSuccess(travel);
                        action.onPostExecute();
                    }
                }).addOnFailureListener(new OnFailureListener() {
                    @Override
                    public void onFailure(@NonNull Exception e) {
                        action.onFailure(travel, e);
                        action.onPostExecute();
                    }
                });

            }
        }).addOnFailureListener(new OnFailureListener() {
            @Override
            public void onFailure(@NonNull Exception e) {
                action.onFailure(travel, e);
                action.onPostExecute();
            }
        });
    }

    @Override
    public void addPassenger(final Passenger passenger, final RunAction<Passenger> action) {
        action.onPreExecute();
        String key = passenger.getKey();
        passengers.child(key).setValue(passenger).addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {
                action.onSuccess(passenger);
                action.onPostExecute();
            }
        }).addOnFailureListener(new OnFailureListener() {
            @Override
            public void onFailure(@NonNull Exception e) {
                action.onFailure(passenger, e);
                action.onPostExecute();
            }
        });
    }

    @Override
    public void getPassenger(String key, final RunAction<Passenger> action) {
        action.onPreExecute();
        passengers.child(key).addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                Passenger p = dataSnapshot.getValue(Passenger.class);
                action.onSuccess(p);
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
    public void getTravels(Passenger passenger, final RunAction<ArrayList<Travel>> action) {
        action.onPreExecute();
        //Query query = travelsByPassengers.orderByChild("passenger/email").equalTo(passenger.getEmail());
        Query query = travelsByPassengers.child(passenger.getKey()).orderByChild("start/time").limitToLast(10);

        query.addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                ArrayList<Travel> l = new ArrayList<>();
                for (DataSnapshot snapshot: dataSnapshot.getChildren()) {
                    Travel t = snapshot.getValue(Travel.class);
                    l.add(t);
                }
                Collections.reverse(l);
                action.onSuccess(l);
                action.onPostExecute();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {
                action.onFailure(null, new Exception(databaseError.getMessage()));
                action.onPostExecute();
            }
        });
    }
}
