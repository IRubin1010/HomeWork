package il.co.meir_itzik.gettaxi1.model.datasource;

import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.entities.Travel;

public interface DataSource {
    Boolean addTravel(Travel travel);
    Boolean addPassenger(Passenger passenger);
}