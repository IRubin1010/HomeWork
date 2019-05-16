package il.co.meir_itzik.gettaxi2.model.backend;

import il.co.meir_itzik.gettaxi2.model.Authentication.AuthService;
import il.co.meir_itzik.gettaxi2.model.Authentication.Firebase;
import il.co.meir_itzik.gettaxi2.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi2.model.datasource.FireBase;

public class BackendFactory {
    public static DataSource getDatasource(){
        return new FireBase();
    }

    public static AuthService getAuthService(){
        return new Firebase();
    }
}
