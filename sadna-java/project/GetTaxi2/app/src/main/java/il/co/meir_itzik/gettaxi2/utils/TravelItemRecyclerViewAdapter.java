package il.co.meir_itzik.gettaxi2.utils;

import android.graphics.Color;
import android.graphics.drawable.GradientDrawable;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;

import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.controller.fragments.OpenTravelsFragment.OnListFragmentInteractionListener;
import il.co.meir_itzik.gettaxi2.model.entities.Travel;

import java.text.SimpleDateFormat;
import java.util.List;

public class TravelItemRecyclerViewAdapter extends RecyclerView.Adapter<TravelItemRecyclerViewAdapter.ViewHolder> {

    public final List<Travel> mValues;
    private final OnListFragmentInteractionListener mListener;

    public TravelItemRecyclerViewAdapter(List<Travel> items, OnListFragmentInteractionListener listener) {
        mValues = items;
        mListener = listener;
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
                    mListener.onListFragmentInteraction(holder.mItem);
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return mValues.size();
    }

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
