package il.co.meir_itzik.gettaxi2.utils;

import android.app.Notification;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.support.v4.app.NotificationCompat;
import android.widget.Toast;

import com.google.gson.Gson;

import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.controller.MainActivity;
import il.co.meir_itzik.gettaxi2.model.entities.Travel;

public class TravelBroadcastReceiver extends BroadcastReceiver {

    Gson gson = new Gson();

    @Override
    public void onReceive(Context context, Intent intent) {
        if(intent.getAction().equals("il.co.meir_itzik.gettaxi.NEW_TRAVEL")){

            String travelJson = intent.getStringExtra("data");
            Travel travel = gson.fromJson(travelJson, Travel.class);

            Intent notificationIntent = new Intent(context, MainActivity.class);
            notificationIntent.putExtra("fragment", "openTravels");

            PendingIntent contentIntent = PendingIntent.getActivity(context, 0, notificationIntent, PendingIntent.FLAG_UPDATE_CURRENT);

            String CHANNEL_ID = "my_channel_01";// The id of the channel.
            CharSequence name = "my_channel";// The user-visible name of the channel.
            int importance = NotificationManager.IMPORTANCE_HIGH;
            NotificationChannel mChannel = new NotificationChannel(CHANNEL_ID, name, importance);

            NotificationCompat.Builder mBuilder =
                    new NotificationCompat.Builder(context)
                            .setSmallIcon(R.mipmap.ic_launcher_taxi_round)
                            .setContentTitle("new travel was added")
                            .setContentText("from: " + travel.getSource())
                            .setChannelId(CHANNEL_ID);
            mBuilder.setContentIntent(contentIntent);
            mBuilder.setDefaults(Notification.DEFAULT_SOUND);
            mBuilder.setAutoCancel(true);
            NotificationManager mNotificationManager =
                    (NotificationManager) context.getSystemService(Context.NOTIFICATION_SERVICE);
            mNotificationManager.createNotificationChannel(mChannel);
            mNotificationManager.notify(1, mBuilder.build());
            Toast toast = Toast.makeText(context, "got travel from broadcast", Toast.LENGTH_SHORT);
            toast.show();
        }
    }
}
