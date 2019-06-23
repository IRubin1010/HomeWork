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
    private static int notificationNumber = 1;

    @Override
    public void onReceive(Context context, Intent intent) {
        if(intent.getAction().equals("il.co.meir_itzik.gettaxi.NEW_TRAVEL")){

            String travelJson = intent.getStringExtra("data");
            Travel travel = gson.fromJson(travelJson, Travel.class);

            Intent notificationIntent = new Intent(context, MainActivity.class);
            notificationIntent.putExtra("fragment", "openTravels");

            PendingIntent contentIntent = PendingIntent.getActivity(context, 0, notificationIntent, PendingIntent.FLAG_UPDATE_CURRENT);

            String CHANNEL_ID = "channel";// The id of the channel.
            CharSequence name = "channel";// The user-visible name of the channel.
            int importance = NotificationManager.IMPORTANCE_HIGH;
            NotificationChannel mChannel = new NotificationChannel(CHANNEL_ID, name, importance);

            NotificationCompat.Builder mBuilder =
                    new NotificationCompat.Builder(context, CHANNEL_ID)
                            .setSmallIcon(R.mipmap.ic_launcher_taxi_round)
                            .setContentTitle("New Travel")
                            .setContentText("from:   " + travel.getSource().getAddress())
                            .setContentIntent(contentIntent)
                            .setDefaults(Notification.DEFAULT_SOUND)
                            .setGroup("GROUP");

            Notification summaryNotification = new NotificationCompat.Builder(context, CHANNEL_ID)
                    .setSmallIcon(R.mipmap.ic_launcher_taxi_round)
                    .setStyle(new NotificationCompat.InboxStyle()
                            .setSummaryText("new travels where ordered"))
                    .setGroup("GROUP")
                    .setGroupAlertBehavior(NotificationCompat.GROUP_ALERT_CHILDREN)
                    .setGroupSummary(true)
                    .build();

            NotificationManager mNotificationManager =
                    (NotificationManager) context.getSystemService(Context.NOTIFICATION_SERVICE);
            mNotificationManager.createNotificationChannel(mChannel);

            mNotificationManager.notify(notificationNumber++, mBuilder.build());
            mNotificationManager.notify(0, summaryNotification);
        }
    }
}
