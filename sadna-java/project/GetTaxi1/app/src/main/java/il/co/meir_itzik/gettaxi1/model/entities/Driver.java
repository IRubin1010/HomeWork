package il.co.meir_itzik.gettaxi1.model.entities;

public class Driver {
    private String firstName;
    private String lastName;
    private String email;
    private String ID;
    private String phoneNumber;
    private String CreditNumber;

    public Driver(String firstName, String lastName, String email, String ID, String phoneNumber, String creditNumber) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.ID = ID;
        this.phoneNumber = phoneNumber;
        CreditNumber = creditNumber;
    }

    public Driver(String firstName, String lastName, String email){
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
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

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getID() {
        return ID;
    }

    public void setID(String ID) {
        this.ID = ID;
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
}
