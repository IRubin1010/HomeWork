package il.co.meir_itzik.gettaxi1.model.datasource;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.entities.Travel;

public class ListDB implements DataSource{
    private ArrayList<Passenger> passengerList;
    private ArrayList<Travel> travelList;

    public ListDB(){
        passengerList = new ArrayList<>();
        travelList = new ArrayList<>();
        travelList.add(new Travel("aaa","aaa", new Date(), Travel.Status.OPEN));
        travelList.add(new Travel("bbb","bbb", new Date(), Travel.Status.OPEN));
        travelList.add(new Travel("ccc","ccc", new Date(), Travel.Status.OPEN));
        travelList.add(new Travel("ddd","ddd", new Date(), Travel.Status.OPEN));
        travelList.add(new Travel("eee","eee", new Date(), Travel.Status.OPEN));
        travelList.add(new Travel("fff","fff", new Date(), Travel.Status.OPEN));
        travelList.add(new Travel("ggg","ggg", new Date(), Travel.Status.OPEN));
        travelList.add(new Travel("hhh","hhh", new Date(), Travel.Status.OPEN));
        travelList.add(new Travel("iii","iii", new Date(), Travel.Status.OPEN));
        travelList.add(new Travel("jjj","jjj", new Date(), Travel.Status.OPEN));
    }

    @Override
    public Boolean addTravel(Travel travel) {
        travelList.add(travel);
        return true;
    }

    @Override
    public Boolean addPassenger(Passenger passenger) {
        passengerList.add(passenger);
        return true;
    }

    @Override
    public Boolean isPassengerExist(Passenger passenger) {
        return passengerList.contains(passenger);
    }

    @Override
    public Passenger isPassengerExist(String fName, String lName, String email) {
        for (Passenger p: passengerList) {
            if(p.getFirstName().equals(fName) && p.getLastName().equals(lName) && p.getEmail().equals(email)) return p;
        }
        return null;
    }

    @Override
    public Boolean isTravelExist(Travel travel) {
        return travelList.contains(travel);
    }

    @Override
    public ArrayList<Travel> getTravels() {
        return travelList;
    }
}
