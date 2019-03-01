import java.util.Date;

public abstract class CommunityMember implements CommunityRightsAndObligations {
        private int ID;
        private Jender jender;
        private String name;
        private String address;
        private Date birthDay;
        private float numOfToraHours;
        private float numOfWorkHours;
        private float amountGemachUtilization;
        private Volunteering volunteering;

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public Jender getJender() {
        return jender;
    }

    public void setJender(Jender jender) {
        this.jender = jender;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public Date getBirthDay() {
        return birthDay;
    }

    public void setBirthDay(Date birthDay) {
        this.birthDay = birthDay;
    }

    public float getNumOfToraHours() {
        return numOfToraHours;
    }

    public void setNumOfToraHours(float numOfToraHours) {
        this.numOfToraHours = numOfToraHours;
    }

    public float getNumOfWorkHours() {
        return numOfWorkHours;
    }

    public void setNumOfWorkHours(float numOfWorkHours) {
        this.numOfWorkHours = numOfWorkHours;
    }

    public float getAmountGemachUtilization() {
        return amountGemachUtilization;
    }

    public void setAmountGemachUtilization(float amountGemachUtilization) {
        this.amountGemachUtilization = amountGemachUtilization;
    }

    public Volunteering getVolunteering() {
        return volunteering;
    }

    public void setVolunteering(Volunteering volunteering) {
        this.volunteering = volunteering;
    }
}


