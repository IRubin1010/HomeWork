package il.co.meir_itzik.gettaxi1.model.utils;

public class Validation {

    public static boolean isFirstNameEmpty(String firstName) {
        return firstName != null && firstName.isEmpty();
    }

    public static boolean isLastNameEmpty(String lastName) {
        return lastName != null && lastName.isEmpty();
    }

    public static boolean isEmailEmpty(String email) {
        return email != null && email.isEmpty();
    }

    public static boolean isEmailValid(String email) {
        return email != null && email.contains("@");
    }

    public static boolean isPhoneNumberEmpty(String phoneNumber) {
        return phoneNumber != null && phoneNumber.isEmpty();
    }

    public static boolean isPhoneNumberValid(String phoneNumber) {
        return phoneNumber != null && (phoneNumber.length() == 10 || phoneNumber.length() == 9);
    }

    public static boolean isFromAddressEmpty(String fromAddress) {
        return fromAddress != null && fromAddress.isEmpty();
    }

    public static boolean isDestinationAddressEmpty(String destinationAddress) {
        return destinationAddress != null && destinationAddress.isEmpty();
    }

    public static boolean isCreditCardEmpty(String creditCard) {
        return creditCard != null && creditCard.isEmpty();
    }

    public static boolean isCreditCardValid(String creditCard) {
        return creditCard != null && (creditCard.length() == 12 || creditCard.length() == 9);
    }


}
