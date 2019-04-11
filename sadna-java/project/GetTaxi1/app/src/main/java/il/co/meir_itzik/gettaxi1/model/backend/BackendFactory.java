package il.co.meir_itzik.gettaxi1.model.backend;

import il.co.meir_itzik.gettaxi1.model.datasource.FireBase;
import il.co.meir_itzik.gettaxi1.model.datasource.DataSource;

public class BackendFactory {
    public static DataSource getDatasource(){
        return new FireBase();
    }
}
