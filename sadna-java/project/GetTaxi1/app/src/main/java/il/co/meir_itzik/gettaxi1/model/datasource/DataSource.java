package il.co.meir_itzik.gettaxi1.model.datasource;

import android.os.AsyncTask;

import java.util.ArrayList;

import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.entities.Travel;

public interface DataSource{
    Boolean addTravel(Travel travel);
    Boolean addPassenger(Passenger passenger);
    Boolean isPassengerExist(Passenger passenger);
    Passenger isPassengerExist(String fName, String lName, String email);
    Boolean isTravelExist(Travel travel);
    ArrayList<Travel> getTravels();

}
