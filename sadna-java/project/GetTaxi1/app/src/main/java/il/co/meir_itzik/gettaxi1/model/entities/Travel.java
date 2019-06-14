package il.co.meir_itzik.gettaxi1.model.entities;

import java.sql.Timestamp;
import java.text.SimpleDateFormat;
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
    private String comment;
    private Driver driver;
    private String price;
    private String timestamp;

    public Travel(String source, String destination, Date start, Status status, Passenger passenger, String comment) {
        this.source = source;
        this.destination = destination;
        this.start = start;
        this.status = status;
        this.passenger = passenger;
        this.comment = comment;
        this.driver = null;
        this.price = null;
        this.timestamp = null;
    }

    public Travel(){

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

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }

    public Driver getDriver() {
        return driver;
    }

    public void setDriver(Driver driver) {
        this.driver = driver;
    }

    public String getPrice() {
        return price;
    }

    public void setPrice(String price) {
        this.price = price;
    }

    public String getTimestamp() {
        return timestamp;
    }

    public void setTimestamp(String timestamp) {
        this.timestamp = timestamp;
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

    public String getKey(){
        return getSource() + "-" + getDestination() +"-" + new SimpleDateFormat("dd:MM:yyyy-HH:mm").format(getStart().getTime());
    }

    public String getTravelsKey(){
        return getPassenger().getKey() + "-" + getSource() + "-" + getDestination() +"-" + new SimpleDateFormat("dd:MM:yyyy-HH:mm").format(getStart().getTime());
    }
}
