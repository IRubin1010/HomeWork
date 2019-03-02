import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
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

    public List<Integer> communityVolunteerHours(){
        List<CommunityMember> sortedMembersList = communityMembers.stream().sorted(Comparator.comparing(CommunityMember::getVolunteering)).collect(Collectors.toList());
        List<Integer> volunteerHours = new ArrayList<>();
        for (CommunityMember member: sortedMembersList) {
            volunteerHours.add(member.recommendedMonthlyVolunteerHours());
        }
        return volunteerHours;
    }
}
