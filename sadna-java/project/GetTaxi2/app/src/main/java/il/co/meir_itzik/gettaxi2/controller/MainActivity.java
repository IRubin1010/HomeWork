package il.co.meir_itzik.gettaxi2.controller;

import android.app.ActivityManager;
import android.app.NotificationManager;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.widget.SearchView;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.View;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.view.inputmethod.EditorInfo;
import android.widget.TextView;

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
import il.co.meir_itzik.gettaxi2.utils.TravelCheckService;
import il.co.meir_itzik.gettaxi2.utils.travelList.TravelListCaller;
import il.co.meir_itzik.gettaxi2.utils.travelList.onListItemClickListener;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener, onListItemClickListener {

    private Gson gson = new Gson();
    private SharedPreferencesService prefs;
    private AuthService AS = BackendFactory.getAuthService();
    private Fragment f;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // check that service is running, if not rerunning
        if(!isMyServiceRunning(TravelCheckService.class))
            startService(new Intent(MainActivity.this, TravelCheckService.class));

        NotificationManager mNotificationManager =
                (NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);
        mNotificationManager.deleteNotificationChannel("channel");

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

        String fragment = getIntent().getStringExtra("fragment");
        if(fragment != null && fragment.equals("openTravels")){
            f = new OpenTravelsFragment();
            setTitle("Open Travels");
        }else{
            f = new DashboardFragment();
            setTitle("Dashboard");
        }
        fragmentTransaction.replace(R.id.nav_fragment, f).commit();
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

/*    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.filter_menu, menu);

        MenuItem searchItem = menu.findItem(R.id.action_search);
        SearchView searchView = (android.support.v7.widget.SearchView) searchItem.getActionView();

        searchView.setImeOptions(EditorInfo.IME_ACTION_DONE);

        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                adapter.getFilter().filter(newText);
                return false;
            }
        });
        return true;
    }*/

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        f = null;
        if (id == R.id.nav_dashboard) {
            // Handle the camera action
            f = new DashboardFragment();
            setTitle("Dashboard");
        } else if (id == R.id.nav_open_travels) {
            f = new OpenTravelsFragment();
            setTitle("Open Travels");

        } else if (id == R.id.nav_my_travels) {
            f = new MyTravelsFragment();
            setTitle("My Travels");
        } else if (id == R.id.nav_manage) {

        } else if (id == R.id.nav_log_out) {
            AS.logout();
            prefs.setLoggedIn(false);
            Intent login = new Intent(MainActivity.this, LoginActivity.class);
            login.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(login);

        }
        if (f!=null)
            fragmentTransaction.replace(R.id.nav_fragment, f).commit();

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
