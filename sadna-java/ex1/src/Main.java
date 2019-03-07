import com.meir_itzik.sadna_java.ex1.community.Community;
import com.meir_itzik.sadna_java.ex1.community.MarriedCommunityMember;
import com.meir_itzik.sadna_java.ex1.community.SingleCommunityMember;
import com.meir_itzik.sadna_java.ex1.enums.Gender;
import com.meir_itzik.sadna_java.ex1.enums.Volunteering;
import com.meir_itzik.sadna_java.ex1.exceptions.CommunityException;

import java.util.Date;

public class Main {

    public static void main(String[] args) {
        Community community = new Community();

        try {
            community.addCommunityMember(new SingleCommunityMember(1, Gender.MALE, "Mosh", "Ovadie6", new Date(4 / 7 / 91), 110, 2, 100, 50, Volunteering.SPIRITUAL, 5));
            //community.addCommunityMember(new SingleCommunityMember(2, Gender.MALE, "David", "Manchem17", new Date(4 / 7 / 2000), 90, 2, 100, 50, Volunteering.SPIRITUAL, 5));
            community.addCommunityMember(new SingleCommunityMember(3, Gender.FEMALE, "Lea", "Ovadie6", new Date(4 / 7 / 2012), 5, 107, 100, 100, Volunteering.MUSICAL, 10));
            community.addCommunityMember(new SingleCommunityMember(4, Gender.FEMALE, "Breacha", "Ovadie6", new Date(4 / 7 / 2013), 10, 102, 100, 0, Volunteering.PHYSICAL, 12));
            community.addCommunityMember(new MarriedCommunityMember(5, Gender.MALE, "Yoni", "sokolov17", new Date(4 / 7 / 1990), 90, 22, 1000, 100, Volunteering.MUSICAL, 6,3));
            community.addCommunityMember(new MarriedCommunityMember(6, Gender.FEMALE, "Breacha", "sokolov17", new Date(4 / 7 / 1993), 10, 102, 100, 0, Volunteering.PHYSICAL, 5,3));
            System.out.println(community.communityMembers);
        } catch (CommunityException ex) {
            System.out.println(ex.getMessage());
        }
        System.out.println("the total tex that can get from all the community is: "+community.monthlyTotalComunityTax());
        System.out.println("The amount of the approved loan for " + community.communityMembers.get(3).getName() + " is: " + community.gemachRequest(community.communityMembers.get(3)));
        System.out.println(community.communityVolunteerHours());
        community.communityMembers.get(3).setAmountGemachUtilization(10000);
        System.out.println("The amount of the approved loan for " + community.communityMembers.get(3).getName() + " is: " + community.gemachRequest(community.communityMembers.get(3)));
        community.communityMembers.get(3).setVolunteering(Volunteering.PHYSICAL);
        System.out.println(community.communityVolunteerHours());

    }
}
