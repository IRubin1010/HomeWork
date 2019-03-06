import com.meir_itzik.sadna_java.ex1.community.Community;
import com.meir_itzik.sadna_java.ex1.community.SingleCommunityMember;
import com.meir_itzik.sadna_java.ex1.enums.Gender;
import com.meir_itzik.sadna_java.ex1.enums.Volunteering;
import com.meir_itzik.sadna_java.ex1.exceptions.CommunityException;

import java.util.Date;

public class Main {

    public static void main(String[] args){
        Community com = new Community();
        try {
            com.addCommunityMember(new SingleCommunityMember(1, Gender.MALE, "a", "b",new Date(), 110, 2,100,50, Volunteering.SPIRITUAL, 5));
            System.out.println("add");
        }catch (CommunityException ex){

        }
    }
}