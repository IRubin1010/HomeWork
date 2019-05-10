package il.co.meir_itzik.gettaxi2.controller;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import com.google.firebase.FirebaseApp;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;

import il.co.meir_itzik.gettaxi2.R;

public class MainActivity extends AppCompatActivity {
    //FirebaseApp.initializeApp(this);
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        blabla();



    }

    public void blabla(){
        FirebaseApp.initializeApp(this);
        FirebaseDatabase database = FirebaseDatabase.getInstance();
        DatabaseReference myRef = database.getReference("meir");
        myRef.setValue("Hello, World!");
    }
}
