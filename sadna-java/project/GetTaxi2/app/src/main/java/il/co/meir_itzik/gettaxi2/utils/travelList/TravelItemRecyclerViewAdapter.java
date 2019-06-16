package il.co.meir_itzik.gettaxi2.utils.travelList;

import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.GradientDrawable;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Filter;
import android.widget.Filterable;
import android.widget.LinearLayout;
import android.widget.TextView;

import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.model.entities.Travel;
import il.co.meir_itzik.gettaxi2.utils.LocationService;

import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;

public class TravelItemRecyclerViewAdapter extends RecyclerView.Adapter<TravelItemRecyclerViewAdapter.ViewHolder> implements Filterable {

    public final List<Travel> mValues;
    private List<Travel> travelFullList;
    private final onListItemClickListener mListener;
    private final TravelListCaller mCaller;
    private final LocationService mLocationService;
    private Geocoder geocoder;

    public TravelItemRecyclerViewAdapter(Context context, List<Travel> items, onListItemClickListener listener, TravelListCaller caller, LocationService locationService) {
        mValues = items;
        travelFullList = new ArrayList<>(items);
        mListener = listener;
        mCaller = caller;
        mLocationService = locationService;
        geocoder = new Geocoder(context);
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.fragment_travel_item, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(final ViewHolder holder, int position) {
        holder.mItem = mValues.get(position);
        Travel travel = mValues.get(position);
        holder.mTimeView.setText(new SimpleDateFormat("dd/MM/yyyy  -  HH:mm").format(travel.getStart().getTime()));
        holder.mFromView.setText(travel.getSource());
        holder.mDestinationView.setText(travel.getDestination());


        GradientDrawable drawable = new GradientDrawable();
        drawable.setShape(GradientDrawable.RECTANGLE);
        drawable.setCornerRadius(8);

        if(travel.getStatus() == Travel.Status.FINISH){
            drawable.setStroke(1, Color.RED);
        }
        else if(travel.getStatus() == Travel.Status.IN_PROGRESS){
            drawable.setStroke(1, Color.GREEN);
        }
        if(travel.getStatus() != Travel.Status.OPEN){
            holder.mLlView.setBackground(drawable);
        }

        holder.mView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (null != mListener) {
                    mListener.onListItemClick(holder.mItem, mCaller);
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return mValues.size();
    }

    @Override
    public  Filter getFilter() {
        return travelFilter;
    }

    private Filter travelFilter = new Filter() {
        @Override
        protected FilterResults performFiltering(CharSequence constraint) {
            List<Travel> filteredList = new ArrayList<>();

            if (constraint == null || constraint.length() == 0) {
                filteredList.addAll(travelFullList);
            } else {
                int filterPattern = Integer.parseInt(constraint.toString());

                Location driverLocation = mLocationService.getLocation();

                for (Travel item : travelFullList) {
                    Location itemLocation = new Location("itemLocation");
                    List<Address> addresses = null;
                    try {
                        addresses = geocoder.getFromLocationName(item.getSource(), 5);
                        if(addresses == null || addresses.size() == 0){
                            continue;
                        }
                        Address loc = addresses.get(0);
                        itemLocation.setLatitude(loc.getLatitude());
                        itemLocation.setLongitude(loc.getLongitude());
                        float a = driverLocation.distanceTo(itemLocation);
                        if (driverLocation.distanceTo(itemLocation)/1000 <= filterPattern) {
                            filteredList.add(item);
                        }
                    } catch (IOException e) {
                        e.printStackTrace();
                        Log.d("adapter", "can not get location from travel");
                    }
                }
            }

            FilterResults results = new FilterResults();
            results.values = filteredList;

            return results;
        }

        @Override
        protected void publishResults(CharSequence constraint, FilterResults results) {
            mValues.clear();
            mValues.addAll((List) results.values);
            notifyDataSetChanged();
        }
    };

    public class ViewHolder extends RecyclerView.ViewHolder {
        private final View mView;
        private final TextView mFromView;
        private final TextView mDestinationView;
        private final TextView mTimeView;
        private final LinearLayout mLlView;
        private Travel mItem;

        public ViewHolder(View view) {
            super(view);
            mView = view;
            mFromView = (TextView) view.findViewById(R.id.from);
            mDestinationView = (TextView) view.findViewById(R.id.to);
            mTimeView = (TextView) view.findViewById(R.id.time);
            mLlView = (LinearLayout) view.findViewById(R.id.item_ll);
        }

    }

}
