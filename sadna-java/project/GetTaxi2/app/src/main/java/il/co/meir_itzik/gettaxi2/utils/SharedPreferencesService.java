package il.co.meir_itzik.gettaxi2.utils;

import android.content.Context;
import android.content.SharedPreferences;
import android.preference.PreferenceManager;

import com.google.gson.Gson;

import il.co.meir_itzik.gettaxi2.model.entities.Driver;

public class SharedPreferencesService {
    private SharedPreferences prefs;
    Gson gson = new Gson();

    public SharedPreferencesService(Context context) {
        this.prefs = PreferenceManager.getDefaultSharedPreferences(context);
    }

    public void setLoggedIn(boolean loggedIn){
        this.prefs.edit().putBoolean("loggedIn",loggedIn).apply();
    }

    public boolean isLoggedIn(){
        return this.prefs.getBoolean("loggedIn",false);
    }

    public void putDriver(Driver driver){
        String driverJson = gson.toJson(driver);
        this.prefs.edit().putString("driver", driverJson).apply();
    }

    public Driver getDriver(){
        String driverStr = this.prefs.getString("driver","");
        Driver driver = gson.fromJson(driverStr, Driver.class);
        return  driver;
    }

    public void deleteDriver(){
        this.prefs.edit().remove("driver").apply();
    }

}
