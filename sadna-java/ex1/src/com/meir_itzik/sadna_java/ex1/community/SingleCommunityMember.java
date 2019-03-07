package com.meir_itzik.sadna_java.ex1.community;

import com.meir_itzik.sadna_java.ex1.enums.Gender;
import com.meir_itzik.sadna_java.ex1.enums.Volunteering;
import com.meir_itzik.sadna_java.ex1.exceptions.CommunityException;

import java.util.Date;


public class SingleCommunityMember extends CommunityMember {
    private int educationYears;

    public SingleCommunityMember(int ID, Gender gender, String name, String address, Date birthday, float numOfToraHours, float numOfWorkHours, float salary, float amountGemachUtilization, Volunteering volunteering, int educationYears) throws CommunityException {
        super(ID, gender, name, address, birthday, numOfToraHours, numOfWorkHours, salary, amountGemachUtilization, volunteering);
        this.educationYears = educationYears;
    }

    public int getEducationYears() {
        return educationYears;
    }

    public void setEducationYears(int educationYears) {
        this.educationYears = educationYears;
    }

    /**
     * @return the community tax that community member should pay
     */
    @Override
    public int monthlyCommunityTax() {
        float numOfToraHours = this.getNumOfToraHours();
        if(numOfToraHours > 100) return 0;
        return this.baseCommunityTax();
    }

    /**
     * @return the max money amount the member could get from "Gemach"
     */
    @Override
    public int maxAmountFromGemach() {
        return 0;
    }

    /**
     * @return the recommended hours that community member should volunteer
     */
    @Override
    public int recommendedMonthlyVolunteerHours() {
        Gender memberGender = this.getGender();
        if(memberGender == Gender.MALE) return 30;
        return 20;
    }

    @Override
    public String toString(){
        return super.toString() + "\nEducationYears: " +educationYears;
    }
}
