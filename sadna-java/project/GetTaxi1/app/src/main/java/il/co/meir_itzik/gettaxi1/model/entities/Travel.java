package il.co.meir_itzik.gettaxi1.model.entities;

import java.util.Date;

public class Travel {
    public enum Status{
        OPEN,
        IN_PROGRESS,
        FINISH
    }
    private String source;
    private String destination;
    private Date start;
    private Date end;
    private Status status;
    private Passenger passenger;

    public Travel(String source, String destination, Date start, Status status, Passenger passenger) {
        this.source = source;
        this.destination = destination;
        this.start = start;
        this.status = status;
        this.passenger = passenger;
    }

    public String getSource() {
        return source;
    }

    public void setSource(String source) {
        this.source = source;
    }

    public String getDestination() {
        return destination;
    }

    public void setDestination(String destination) {
        this.destination = destination;
    }

    public Date getStart() {
        return start;
    }

    public void setStart(Date start) {
        this.start = start;
    }

    public Date getEnd() {
        return end;
    }

    public void setEnd(Date end) {
        this.end = end;
    }

    public Status getStatus() {
        return status;
    }

    public void setStatus(Status status) {
        this.status = status;
    }

    public Passenger getPassenger() {
        return passenger;
    }

    public void setPassenger(Passenger passenger) {
        this.passenger = passenger;
    }

    @Override
    public boolean equals(Object obj) {
        if(!(obj instanceof Travel))return false;
        Travel t = (Travel)obj;
        return source.equals(t.getSource())
                && destination.equals(t.getDestination())
                && start.equals(t.getStart())
                && passenger.equals(t.getPassenger());
    }
}
