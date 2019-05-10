package il.co.meir_itzik.gettaxi2.model.datasource;

import il.co.meir_itzik.gettaxi2.model.entities.Driver;

public interface DataSource {
    interface RunAction<T>{
        void onPreExecute();
        void onSuccess(T obj);
        void onFailure(T obj, Exception e);
        void onPostExecute();
    }

    void isDriverExist(Driver driver, RunAction<Boolean> action);

    void isDriverExistByEmailAndPassword(String email, String password, RunAction<Boolean> action);

    void getDriverByEmailAndPassword(String email, String password, RunAction<Driver> action);

    void addDriver(Driver driver, RunAction<Driver> action);
}
