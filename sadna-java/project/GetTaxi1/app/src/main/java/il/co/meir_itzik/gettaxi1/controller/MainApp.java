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
        if (savedInstanceState == null) {
            String fragment = getIntent().getExtras().getString("fragment");
            switch (fragment){
                case "":
                    break;
                    default:
                        PassengerDetailsNoRegistration f1= new PassengerDetailsNoRegistration();
                        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                        fragmentTransaction.add(R.id.fragment_container, f1);
                        fragmentTransaction.commit();
            }
        }
    }
}

