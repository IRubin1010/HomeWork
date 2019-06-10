package il.co.meir_itzik.gettaxi2.utils;

import android.app.Service;
import android.content.Intent;
import android.os.Handler;
import android.os.IBinder;
import android.util.Log;
import android.widget.Toast;

import com.google.gson.Gson;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Calendar;

import il.co.meir_itzik.gettaxi2.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi2.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi2.model.entities.Travel;

public class TravelCheckService extends Service {

    private static final String TAG = "TravelCheckService";
    private Timestamp timestamp = new Timestamp(System.currentTimeMillis());
    DataSource DB = BackendFactory.getDatasource();
    private Gson gson = new Gson();

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        final Handler handler = new Handler();
        handler.postDelayed(new Runnable() {

            @Override
            public void run() {
                Log.i(TAG, "Service running");
                checkForNewTravels();
                Calendar cal = Calendar.getInstance();
                cal.setTimeInMillis(timestamp.getTime());
                cal.add(Calendar.SECOND, 10);
                timestamp = new Timestamp(cal.getTime().getTime());
                handler.postDelayed(this, 10000);
            }
        }, 10000);

        // If we get killed, after returning from here, restart
        return START_STICKY;
    }

    private void checkForNewTravels() {
        final ArrayList<Travel> travels = new ArrayList<>();
        DB.getTravelsByTimestamp(timestamp, new Timestamp(1560164363600L), new DataSource.RunAction<ArrayList<Travel>>() {
            @Override
            public void onPreExecute() {

            }

            @Override
            public void onSuccess(ArrayList<Travel> obj) {
                //ArrayList<Travel> travels = obj;
                if(obj.size() > 0){
                    Log.i("travelService", "got travels");
                }
                for (Travel travel: obj) {
                    String travelJson = gson.toJson(travel);
                    Intent intent = new Intent(TravelCheckService.this, TravelBroadcastReceiver.class);
                    intent.setAction("il.co.meir_itzik.gettaxi.NEW_TRAVEL");
                    intent.putExtra("data",travelJson);
                    sendBroadcast(intent);

                }
            }

            @Override
            public void onFailure(ArrayList<Travel> obj, Exception e) {
                Toast toast = Toast.makeText(TravelCheckService.this, "failed to add get travels by timestamp" + e.getMessage(), Toast.LENGTH_SHORT);
                toast.show();
            }

            @Override
            public void onPostExecute() {

            }
        });
    }
}


