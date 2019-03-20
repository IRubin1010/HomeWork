package il.co.meir_itzik.gettaxi1.model.datasource;

import java.util.ArrayList;
import java.util.List;

import il.co.meir_itzik.gettaxi1.model.entities.Passenger;
import il.co.meir_itzik.gettaxi1.model.entities.Travel;

public class ListDB implements DataSource{
    private List<Passenger> passengerList;
    private List<Travel> travelList;

    public ListDB(){
        passengerList = new ArrayList<>();
        travelList = new ArrayList<>();
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
    public Boolean isPassengerExist(String fName, String lName, String email) {
        for (Passenger p: passengerList) {
            if(p.getFirstName().equals(fName) && p.getLastName().equals(lName) && p.getEmail().equals(email)) return true;
        }
        return false;
    }

    @Override
    public Boolean isTravelExist(Travel travel) {
        return travelList.contains(travel);
    }
}
