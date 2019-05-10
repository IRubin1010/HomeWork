package il.co.meir_itzik.gettaxi2.model.entities;

import java.io.Serializable;

public class Passenger implements Serializable {
    private String firstName;
    private String lastName;
    private String id;
    private String email;
    private String phoneNumber;
    private String CreditNumber;

    public Passenger(String firstName, String lastName, String id, String email, String phoneNumber, String creditNumber) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.id = id;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.CreditNumber = creditNumber;
    }

    public Passenger(){

    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public String getCreditNumber() {
        return CreditNumber;
    }

    public void setCreditNumber(String creditNumber) {
        CreditNumber = creditNumber;
    }

    @Override
    public boolean equals(Object obj) {
        if(!(obj instanceof Passenger)) return false;
        Passenger p = (Passenger)obj;
        return p.getFirstName().equals(firstName)
                && p.getLastName().equals(lastName)
                && p.getId().equals(id);
    }
}
