package il.co.meir_itzik.gettaxi2.controller;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.model.Authentication.AuthService;
import il.co.meir_itzik.gettaxi2.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi2.model.utils.SharedPreferencesService;

public class SplashScreen extends AppCompatActivity {

    AuthService AS = BackendFactory.getAuthService();
    private SharedPreferencesService prefs;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_splash_screen);

        prefs = new SharedPreferencesService(this);

        if(AS.isLoggedIn() && prefs.isLoggedIn()){
            Intent main = new Intent(SplashScreen.this, MainActivity.class);
            main.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(main);
        }else{
            Intent main = new Intent(SplashScreen.this, LoginActivity.class);
            main.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(main);
        }

    }
}
