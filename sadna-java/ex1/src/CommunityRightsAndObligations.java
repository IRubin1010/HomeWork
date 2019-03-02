public interface CommunityRightsAndObligations {
    /**
     * @return the community tax that community member should pay
     */
    int monthlyCommunityTax();

    /**
     * @return the max money amount the member could get from "Gemach"
     */
    int maxAmountFromGemach();

    /**
     * @return the recommended hours that community member should volunteer
     */
    int recommendedMonthlyVolunteerHours();
}
