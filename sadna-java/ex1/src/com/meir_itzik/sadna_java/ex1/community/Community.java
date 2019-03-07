package com.meir_itzik.sadna_java.ex1.community;

import com.meir_itzik.sadna_java.ex1.enums.Volunteering;

import java.lang.reflect.Array;
import java.util.*;
import java.util.stream.Collectors;

public class Community {

    public List<CommunityMember> communityMembers;

    public Community() {
        this.communityMembers = new ArrayList<>();
    }

    public void addCommunityMember(CommunityMember communityMember){
        communityMembers.add(communityMember);
    }

    public int monthlyTotalComunityTax(){
        int totalTax = 0;
        for (CommunityMember member: communityMembers) {
            totalTax += member.monthlyCommunityTax();
        }
        return totalTax;
    }

    public float gemachRequest(CommunityMember communityMember){
        int maxAmountFromGemach = communityMember.maxAmountFromGemach();
        float gemachUtilizedAmount = communityMember.getAmountGemachUtilization();
        return maxAmountFromGemach - gemachUtilizedAmount;
    }

    //TODO itzik I can remove the i vairable?
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
