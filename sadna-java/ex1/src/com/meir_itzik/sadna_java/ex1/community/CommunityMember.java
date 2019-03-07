package com.meir_itzik.sadna_java.ex1.community;

import com.meir_itzik.sadna_java.ex1.enums.Gender;
import com.meir_itzik.sadna_java.ex1.enums.Volunteering;
import com.meir_itzik.sadna_java.ex1.exceptions.CommunityException;

import java.util.Date;

public abstract class CommunityMember implements CommunityRightsAndObligations {
    private int ID;
    private Gender gender;
    private String name;
    private String address;
    private Date birthday;
    private float numOfToraHours;
    private float numOfWorkHours;
    private float salary;
    private float amountGemachUtilization;
    private Volunteering volunteering;
    static final int TOTAL_HOURS = 112;

    public CommunityMember(int ID, Gender gender, String name, String address, Date birthday, float numOfToraHours, float numOfWorkHours, float salary, float amountGemachUtilization, Volunteering volunteering) throws CommunityException {
        float numOfBusyHours = numOfToraHours + numOfWorkHours;
        if(numOfBusyHours != TOTAL_HOURS) throw new CommunityException("number of busy hours is not two thirds of the week hours");
        this.ID = ID;
        this.gender = gender;
        this.name = name;
        this.address = address;
        this.birthday = birthday;
        this.numOfToraHours = numOfToraHours;
        this.numOfWorkHours = numOfWorkHours;
        this.salary = salary;
        this.amountGemachUtilization = amountGemachUtilization;
        this.volunteering = volunteering;
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public Gender getGender() {
        return gender;
    }

    public void setGender(Gender gender) {
        this.gender = gender;
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

    public Date getBirthday() {
        return birthday;
    }

    public void setBirthday(Date birthday) {
        this.birthday = birthday;
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

    public float getSalary() {
        return salary;
    }

    public void setSalary(float salary) {
        this.salary = salary;
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

    public int baseCommunityTax(){
        if(salary > 10000) return 1000;
        return 500;
    }

    @Override
    public String toString(){
        return "\n\nName: " + this.name + "\nGender: " + gender + "\nID: " + ID + "\nAddress: " + address + "\nBirthday" + birthday +"\nNum of tora hours: " + numOfToraHours +"\nNum of work hours: " + numOfWorkHours + "\nSalary: " + salary + "\nAmount gemach utilization: " + amountGemachUtilization +"\nVolunteering: " +volunteering;
    }

}


