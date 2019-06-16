package il.co.meir_itzik.gettaxi2.utils.travelList;

import android.graphics.Color;
import android.graphics.drawable.GradientDrawable;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Filter;
import android.widget.Filterable;
import android.widget.LinearLayout;
import android.widget.TextView;

import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.controller.fragments.OpenTravelsFragment;
import il.co.meir_itzik.gettaxi2.model.entities.Travel;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;

public class TravelItemRecyclerViewAdapter extends RecyclerView.Adapter<TravelItemRecyclerViewAdapter.ViewHolder> implements Filterable {

    public final List<Travel> mValues;
    private List<Travel> travelFullList;
    private final onListItemClickListener mListener;
    private final TravelListCaller mCaller;

    public TravelItemRecyclerViewAdapter(List<Travel> items, onListItemClickListener listener, TravelListCaller caller) {
        mValues = items;
        travelFullList = new ArrayList<>(items);
        mListener = listener;
        mCaller = caller;
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
                String filterPattern = constraint.toString().toLowerCase().trim();

                for (Travel item : travelFullList) {
                    if (item.getDestination().toLowerCase().startsWith(filterPattern)) {
                        filteredList.add(item);
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
