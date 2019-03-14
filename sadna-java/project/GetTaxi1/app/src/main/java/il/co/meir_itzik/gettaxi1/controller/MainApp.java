package il.co.meir_itzik.gettaxi1.controller;

import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import il.co.meir_itzik.gettaxi1.R;

public class NoRegistrationOrder extends AppCompatActivity {



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order_without_login);
        if (savedInstanceState == null) {
            PassengerDetailsNoRegistration f1= new PassengerDetailsNoRegistration();
            FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
            fragmentTransaction.add(R.id.fragment_container, f1);
            fragmentTransaction.commit();

        }
    }
}

