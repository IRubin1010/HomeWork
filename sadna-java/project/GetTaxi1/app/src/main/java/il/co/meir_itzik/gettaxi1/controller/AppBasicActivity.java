package il.co.meir_itzik.gettaxi1.controller;

import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import il.co.meir_itzik.gettaxi1.R;

public class AppBasicActivity extends AppCompatActivity {



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_app_basic);

        // set fragment
        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        if (savedInstanceState == null) {
            String fragment = getIntent().getExtras().getString("fragment");
            switch (fragment){
                case "Registration":
                    // get passenger basic details
                    String firstName = getIntent().getExtras().getString("fName");
                    String lastName = getIntent().getExtras().getString("lName");
                    String email = getIntent().getExtras().getString("email");

                    // put details in bundle to pass them to next fragment
                    Bundle b = new Bundle();
                    b.putString("fName", firstName);
                    b.putString("lName", lastName);
                    b.putString("email", email);
                    RegistrationDetailsFragment f1= new RegistrationDetailsFragment();
                    f1.setArguments(b);
                    fragmentTransaction.add(R.id.fragment_container, f1);
                    fragmentTransaction.commit();
                    break;
                    // default is order without registration
                    default:
                        PassengerDetailsNotRegisteredFragment f2= new PassengerDetailsNotRegisteredFragment();
                        fragmentTransaction.add(R.id.fragment_container, f2);
                        fragmentTransaction.commit();
            }
        }
    }
}

