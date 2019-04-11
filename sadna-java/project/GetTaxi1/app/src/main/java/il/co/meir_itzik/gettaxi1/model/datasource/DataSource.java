package il.co.meir_itzik.gettaxi1.model.datasource;

import java.util.ArrayList;

import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.entities.Travel;

public interface DataSource{

    interface RunAction<T>{
        void onPreExecute();
        void onSuccess(T obj);
        void onFailure(T obj, Exception e);
        void onPostExecute();
        //String a = "failure";
    }

    void addTravel(Travel travel, RunAction<Travel> action);
    void addPassenger(Passenger passenger, RunAction<Passenger> action);
    void getPassenger(String key, RunAction<Passenger> action);
    void getTravels(Passenger passenger, RunAction<ArrayList<Travel>> action);

}
