package il.co.meir_itzik.gettaxi2.controller;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import com.google.firebase.FirebaseApp;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;

import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.model.Authentication.AuthService;
import il.co.meir_itzik.gettaxi2.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi2.model.utils.SharedPreferencesService;

public class MainActivity extends AppCompatActivity {
    AuthService AS = BackendFactory.getAuthService();
    SharedPreferencesService prefs;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        prefs = new SharedPreferencesService(this);

        Button logoutBtn = findViewById(R.id.button_logout);
        logoutBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                AS.logout();
                prefs.setLoggedIn(false);
                prefs.deleteDriver();
                Intent login = new Intent(MainActivity.this, LoginActivity.class);
                startActivity(login);
            }
        });

    }
}
