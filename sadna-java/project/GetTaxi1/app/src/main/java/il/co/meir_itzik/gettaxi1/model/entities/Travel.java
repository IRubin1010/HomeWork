package il.co.meir_itzik.gettaxi1.model.entities;

import java.util.Date;

public class Travel {
    public enum Status{
        OPEN,
        IN_PROGRESS,
        FINISH
    }
    String source;
    String destination;
    Date start;
    Date end;
    Status status;
    Passenger passenger;

}
