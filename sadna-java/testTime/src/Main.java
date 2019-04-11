import java.util.Calendar;
import java.util.TimeZone;

public class Main {

    public static void main(String[] args) {

        Calendar c = Calendar.getInstance();
        c.setTimeZone(TimeZone.getTimeZone("GMT+03"));


        System.out.println(c.get(Calendar.HOUR_OF_DAY));
        System.out.println(c.getTime());
    }
}
