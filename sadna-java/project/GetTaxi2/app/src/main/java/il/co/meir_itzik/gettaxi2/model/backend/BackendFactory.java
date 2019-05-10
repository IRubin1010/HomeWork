package il.co.meir_itzik.gettaxi2.model.backend;

import il.co.meir_itzik.gettaxi2.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi2.model.datasource.FireBase;

public class BackendFactory {
    public static DataSource getDatasource(){
        return new FireBase();
    }
}
