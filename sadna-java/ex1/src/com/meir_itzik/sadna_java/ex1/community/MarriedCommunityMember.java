package com.meir_itzik.sadna_java.ex1.community;

import com.meir_itzik.sadna_java.ex1.enums.Gender;
import com.meir_itzik.sadna_java.ex1.enums.Volunteering;
import com.meir_itzik.sadna_java.ex1.exceptions.CommunityException;

import java.util.Date;

public class MarriedCommunityMember extends CommunityMember {
    private int partnerID;
    private int numOfKidsUnder18;

    public MarriedCommunityMember(int ID, Gender gender, String name, String address, Date birthday, float numOfToraHours, float numOfWorkHours, float salary, float amountGemachUtilization, Volunteering volunteering, int partnerID, int numOfKidsUnder18) throws CommunityException {
        super(ID, gender, name, address, birthday, numOfToraHours, numOfWorkHours, salary, amountGemachUtilization, volunteering);
        this.partnerID = partnerID;
        this.numOfKidsUnder18 = numOfKidsUnder18;
    }

    public int getPartnerID() {
        return partnerID;
    }

    public void setPartnerID(int partnerID) {
        this.partnerID = partnerID;
    }

    public int getNumOfKidsUnder18() {
        return numOfKidsUnder18;
    }

    public void setNumOfKidsUnder18(int numOfKidsUnder18) {
        this.numOfKidsUnder18 = numOfKidsUnder18;
    }

    /**
     * @return the community tax that community member should pay
     */
    @Override
    public int monthlyCommunityTax() {
        float numOfToraHours = this.getNumOfToraHours();
        if(numOfToraHours > 8) return 0;
        int memberTax = this.baseCommunityTax();
        int assumption = this.getNumOfKidsUnder18() * 25;
        return assumption > memberTax ? 0 : memberTax - assumption;
    }

    /**
     * @return the max money amount the member could get from "Gemach"
     */
    @Override
    public int maxAmountFromGemach() {
        int baseGemachAmount;
        Volunteering memberVolunteering = this.getVolunteering();
        if(memberVolunteering == Volunteering.SPIRITUAL) baseGemachAmount = 20000;
        else baseGemachAmount = 17000;
        int memberGemachAmount = baseGemachAmount;
        for(int i = numOfKidsUnder18; i > 0; i++){
            memberGemachAmount += 1000;
        }
        return memberGemachAmount;
    }

    /**
     * @return the recommended hours that community member should volunteer
     */
    @Override
    public int recommendedMonthlyVolunteerHours() {
        Gender memberGender = this.getGender();
        if(memberGender == Gender.MALE) return 25;
        return 15;
    }
}
