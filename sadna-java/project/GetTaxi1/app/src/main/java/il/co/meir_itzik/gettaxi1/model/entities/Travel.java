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

    public Travel(String source, String destination, Date start, Status status, Passenger passenger) {
        this.source = source;
        this.destination = destination;
        this.start = start;
        this.status = status;
        this.passenger = passenger;
    }
}
