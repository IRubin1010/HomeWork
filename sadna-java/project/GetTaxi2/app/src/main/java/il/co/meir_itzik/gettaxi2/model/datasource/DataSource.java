package il.co.meir_itzik.gettaxi2.model.datasource;

import java.util.ArrayList;

import il.co.meir_itzik.gettaxi2.model.entities.Driver;
import il.co.meir_itzik.gettaxi2.model.entities.Travel;

public interface DataSource {
    interface RunAction<T>{
        void onPreExecute();
        void onSuccess(T obj);
        void onFailure(T obj, Exception e);
        void onPostExecute();
    }

    void getDriver(String key, RunAction<Driver> action);

    void addDriver(Driver driver, RunAction<Driver> action);

    void getOpenTravels(RunAction<ArrayList<Travel>> action);

    void getMyTravels(Driver driver, RunAction<ArrayList<Travel>> action);

    void updateTravel(Travel travel, RunAction<Travel> action);
}
