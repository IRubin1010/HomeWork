package il.co.meir_itzik.gettaxi1.model.utils;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

import il.co.meir_itzik.gettaxi1.R;
import il.co.meir_itzik.gettaxi1.model.entities.Travel;

public class TravelListAdapter extends ArrayAdapter<Travel> {

    private Context mContext;
    private int mResource;

    public TravelListAdapter(Context context, int resource, ArrayList<Travel> objects) {
        super(context, resource, objects);
        mContext = context;
        mResource = resource;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        String from = getItem(position).getSource().getAddress();
        String to = getItem(position).getDestination().getAddress();
        Date date = getItem(position).getStart();

        LayoutInflater inflater = LayoutInflater.from(mContext);
        convertView = inflater.inflate(mResource,parent,false);

        TextView fromView = convertView.findViewById(R.id.from);
        TextView toView = convertView.findViewById(R.id.to);
        TextView dateView = convertView.findViewById(R.id.date);

        fromView.setText(from);
        toView.setText(to);
        dateView.setText(new SimpleDateFormat("dd/MM/yyyy  -  HH:mm").format(date.getTime()));

        return convertView;
    }
}
