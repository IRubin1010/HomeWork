package il.co.meir_itzik.gettaxi2.controller;

import android.app.ActivityManager;
import android.app.NotificationManager;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.view.View;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.Gson;

import il.co.meir_itzik.gettaxi2.controller.fragments.MyTravelsFragment;
import il.co.meir_itzik.gettaxi2.model.entities.Travel;
import il.co.meir_itzik.gettaxi2.utils.BottomSheetDialog;
import il.co.meir_itzik.gettaxi2.controller.fragments.OpenTravelsFragment;
import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.controller.fragments.DashboardFragment;
import il.co.meir_itzik.gettaxi2.model.Authentication.AuthService;
import il.co.meir_itzik.gettaxi2.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi2.model.entities.Driver;
import il.co.meir_itzik.gettaxi2.utils.SharedPreferencesService;
import il.co.meir_itzik.gettaxi2.utils.TravelBroadcastReceiver;
import il.co.meir_itzik.gettaxi2.utils.TravelCheckService;
import il.co.meir_itzik.gettaxi2.utils.travelList.TravelListCaller;
import il.co.meir_itzik.gettaxi2.utils.travelList.onListItemClickListener;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener, onListItemClickListener {

    private Gson gson = new Gson();
    private SharedPreferencesService prefs;
    private AuthService AS = BackendFactory.getAuthService();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        String fragment = getIntent().getStringExtra("fragment");
        if(fragment != null && fragment.equals("openTravels")){
            FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
            Fragment f = new OpenTravelsFragment();
            setTitle("Open Travels");
            fragmentTransaction.replace(R.id.nav_fragment, f).commit();
        }

        setContentView(R.layout.activity_main);

        if(!isMyServiceRunning(TravelCheckService.class))
            startService(new Intent(MainActivity.this, TravelCheckService.class));

        NotificationManager mNotificationManager =
                (NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);
        mNotificationManager.deleteNotificationChannel("my_channel_01");

        prefs = new SharedPreferencesService(this);
        Driver driver = prefs.getDriver();
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.addDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

        View headerView = navigationView.getHeaderView(0);
        TextView navUsername = (TextView) headerView.findViewById(R.id.nav_name);
        navUsername.setText(driver.getFirstName() + " " + driver.getFirstName());
        TextView navEmail = (TextView) headerView.findViewById(R.id.nav_mail);
        navEmail.setText(driver.getEmail());

        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        DashboardFragment f1= new DashboardFragment();
        fragmentTransaction.add(R.id.nav_fragment, f1).commit();

    }

    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }

//    @Override
//    public boolean onCreateOptionsMenu(Menu menu) {
//        // Inflate the menu; this adds items to the action bar if it is present.
//        getMenuInflater().inflate(R.menu.main, menu);
//        return true;
//    }
//
//    @Override
//    public boolean onOptionsItemSelected(MenuItem item) {
//        // Handle action bar item clicks here. The action bar will
//        // automatically handle clicks on the Home/Up button, so long
//        // as you specify a parent activity in AndroidManifest.xml.
//        int id = item.getItemId();
//
//        //noinspection SimplifiableIfStatement
//        if (id == R.id.action_settings) {
//            return true;
//        }
//
//        return super.onOptionsItemSelected(item);
//    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();
        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        Fragment selectedFragment = null;

        if (id == R.id.nav_dashboard) {
            // Handle the camera action
            selectedFragment = new DashboardFragment();
            setTitle("Dashboard");
        } else if (id == R.id.nav_open_travels) {
            selectedFragment = new OpenTravelsFragment();
            setTitle("Open Travels");
        } else if (id == R.id.nav_my_travels) {
            selectedFragment = new MyTravelsFragment();
            setTitle("My Travels");
        } else if (id == R.id.nav_manage) {

        } else if (id == R.id.nav_log_out) {
            AS.logout();
            prefs.setLoggedIn(false);
            Intent login = new Intent(MainActivity.this, LoginActivity.class);
            login.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(login);

        }
        if (selectedFragment!=null)
            fragmentTransaction.replace(R.id.nav_fragment, selectedFragment).commit();

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }

    @Override
    public void onListItemClick(Travel travel, TravelListCaller caller) {
        BottomSheetDialog bottomSheetDialog = new BottomSheetDialog();
        String TravelJson = gson.toJson(travel);
        Bundle b = new Bundle();
        b.putString("travel", TravelJson);
        b.putString("caller", caller.toString());
        bottomSheetDialog.setArguments(b);
        bottomSheetDialog.show(getSupportFragmentManager(), "bottomSheet");
    }

    private boolean isMyServiceRunning(Class<?> serviceClass) {
        ActivityManager manager = (ActivityManager) getSystemService(Context.ACTIVITY_SERVICE);
        for (ActivityManager.RunningServiceInfo service : manager.getRunningServices(Integer.MAX_VALUE)) {
            if (serviceClass.getName().equals(service.service.getClassName())) {
                return true;
            }
        }
        return false;
    }
}
