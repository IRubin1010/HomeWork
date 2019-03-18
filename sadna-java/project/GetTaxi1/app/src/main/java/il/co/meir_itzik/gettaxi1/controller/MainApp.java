package il.co.meir_itzik.gettaxi1.controller;

import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import il.co.meir_itzik.gettaxi1.R;

public class MainApp extends AppCompatActivity {



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_app);
        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        if (savedInstanceState == null) {
            String fragment = getIntent().getExtras().getString("fragment");
            switch (fragment){
                case "Registration":
                    String firstName = getIntent().getExtras().getString("fName");
                    String lastName = getIntent().getExtras().getString("lName");
                    String email = getIntent().getExtras().getString("email");
                    Bundle b = new Bundle();
                    b.putString("fName", firstName);
                    b.putString("lName", lastName);
                    b.putString("email", email);
                    RegistrationDetails f1= new RegistrationDetails();
                    f1.setArguments(b);
                    fragmentTransaction.add(R.id.fragment_container, f1);
                    fragmentTransaction.commit();
                    break;
                    default:
                        PassengerDetailsNoRegistration f2= new PassengerDetailsNoRegistration();
                        fragmentTransaction.add(R.id.fragment_container, f2);
                        fragmentTransaction.commit();
            }
        }
    }
}

