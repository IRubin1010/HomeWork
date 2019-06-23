package il.co.meir_itzik.gettaxi1.model.entities;

import android.location.Location;
import android.support.v4.app.Fragment;

import com.google.android.gms.maps.model.LatLng;

import java.sql.Timestamp;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Travel {
    public enum Status{
        OPEN,
        IN_PROGRESS,
        FINISH
    }

    private AddressLocation source;
    private AddressLocation destination;
    private Date start;
    private Date end;
    private Status status;
    private Passenger passenger;
    private String comment;
    private Driver driver;
    private float price;
    private String timestamp;

    public Travel(AddressLocation source, AddressLocation destination, Date start, Status status, Passenger passenger, String comment) {
        this.source = source;
        this.destination = destination;
        this.start = start;
        this.status = status;
        this.passenger = passenger;
        this.comment = comment;
        this.driver = null;
        this.timestamp = null;
        Location from = new Location("from");
        from.setLatitude(source.getLatitude());
        from.setLongitude(source.getLongitude());
        Location to = new Location("to");
        to.setLatitude(destination.getLatitude());
        to.setLongitude(destination.getLongitude());
        price = from.distanceTo(to) / 1000 * 20;
    }

    public Travel(){

    }

    public AddressLocation getSource() {
        return source;
    }

    public void setSource(AddressLocation source) {
        this.source = source;
    }

    public AddressLocation getDestination() {
        return destination;
    }

    public void setDestination(AddressLocation destination) {
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

    public float getPrice() {
        return price;
    }

    public void setPrice(float price) {
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
        return getSource().getAddress() + "-" + getDestination().getAddress() +"-" + new SimpleDateFormat("dd:MM:yyyy-HH:mm").format(getStart().getTime());
    }

    public String getTravelsKey(){
        return getPassenger().getKey() + "-" + getSource().getAddress() + "-" + getDestination().getAddress() +"-" + new SimpleDateFormat("dd:MM:yyyy-HH:mm").format(getStart().getTime());
    }
}
