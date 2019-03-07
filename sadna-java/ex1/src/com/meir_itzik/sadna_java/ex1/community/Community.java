package com.meir_itzik.sadna_java.ex1.community;

import com.meir_itzik.sadna_java.ex1.enums.Volunteering;

import java.util.*;

public class Community {

    public List<CommunityMember> communityMembers;

    /**
     * default constructor
     */
    public Community() {
        this.communityMembers = new ArrayList<>();
    }

    /**
     * adds a community member
     * @param communityMember member
     */
    public void addCommunityMember(CommunityMember communityMember){
        communityMembers.add(communityMember);
    }

    /**
     * calculate the total tax can be receive from the community in a month
     * @return the total tax
     */
    public int monthlyTotalComunityTax(){
        int totalTax = 0;
        for (CommunityMember member: communityMembers) {
            totalTax += member.monthlyCommunityTax();
        }
        return totalTax;
    }

    /**
     * request for Gemach for a member
     * @param communityMember member
     * @return the amount the member can get from Gemach
     */
    public float gemachRequest(CommunityMember communityMember){
        int maxAmountFromGemach = communityMember.maxAmountFromGemach();
        float gemachUtilizedAmount = communityMember.getAmountGemachUtilization();
        return maxAmountFromGemach - gemachUtilizedAmount;
    }

    /**
     * calculate the hours of volunteering of the community
     * @return list of the hours sorted by the kind of the volunteering
     */
    public List<Integer> communityVolunteerHours(){
        Map<Volunteering, Integer> volunteerHours = new HashMap<>();
        volunteerHours.put(Volunteering.SPIRITUAL, 0);
        volunteerHours.put(Volunteering.PHYSICAL, 0);
        volunteerHours.put(Volunteering.MUSICAL, 0);
        for (CommunityMember member: communityMembers) {
            switch (member.getVolunteering()){
                case SPIRITUAL:
                    volunteerHours.put(Volunteering.SPIRITUAL, volunteerHours.get(Volunteering.SPIRITUAL) + member.recommendedMonthlyVolunteerHours());
                    break;
                case PHYSICAL:
                    volunteerHours.put(Volunteering.PHYSICAL, volunteerHours.get(Volunteering.PHYSICAL) + member.recommendedMonthlyVolunteerHours());
                    break;
                case MUSICAL:
                    volunteerHours.put(Volunteering.MUSICAL, volunteerHours.get(Volunteering.MUSICAL) + member.recommendedMonthlyVolunteerHours());
                    break;
            }
        }
        return new ArrayList<>(volunteerHours.values());
    }
}
