package il.co.meir_itzik.gettaxi2.controller.fragments;

import android.content.Context;
import android.graphics.Canvas;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.helper.ItemTouchHelper;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.SwipeController;
import il.co.meir_itzik.gettaxi2.SwipeControllerActions;
import il.co.meir_itzik.gettaxi2.TravelItemRecyclerViewAdapter;
import il.co.meir_itzik.gettaxi2.dummy.DummyContent;
import il.co.meir_itzik.gettaxi2.dummy.DummyContent.DummyItem;


/**
 * A fragment representing a list of Items.
 * <p/>
 * Activities containing this fragment MUST implement the {@link OnListFragmentInteractionListener}
 * interface.
 */
public class OpenTravelsFragment extends Fragment {

    // TODO: Customize parameters
    private int mColumnCount = 1;

    private OnListFragmentInteractionListener mListener;

    /**
     * Mandatory empty constructor for the fragment manager to instantiate the
     * fragment (e.g. upon screen orientation changes).
     */
    public OpenTravelsFragment() {
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_open_travels, container, false);

        // Set the adapter
        if (view instanceof RecyclerView) {
            Context context = view.getContext();
            RecyclerView recyclerView = (RecyclerView) view;
            if (mColumnCount <= 1) {
                recyclerView.setLayoutManager(new LinearLayoutManager(context));
            } else {
                recyclerView.setLayoutManager(new GridLayoutManager(context, mColumnCount));
            }
            final TravelItemRecyclerViewAdapter adapter = new TravelItemRecyclerViewAdapter(DummyContent.ITEMS, mListener);
            recyclerView.setAdapter(adapter);
            final SwipeController swipeController = new SwipeController(new SwipeControllerActions() {
                @Override
                public void onLeftClicked(int position) {
                    adapter.mValues.remove(position);
                    adapter.notifyItemRemoved(position);
                    adapter.notifyItemRangeChanged(position, adapter.getItemCount());
                }
            }, getActivity());

            ItemTouchHelper itemTouchhelper = new ItemTouchHelper(swipeController);
            itemTouchhelper.attachToRecyclerView(recyclerView);

            recyclerView.addItemDecoration(new RecyclerView.ItemDecoration() {
                @Override
                public void onDraw(Canvas c, RecyclerView parent, RecyclerView.State state) {
                    swipeController.onDraw(c);
                }
            });
        }
        return view;
    }


    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof OnListFragmentInteractionListener) {
            mListener = (OnListFragmentInteractionListener) context;
        } else {
            throw new RuntimeException(context.toString()
                    + " must implement OnListFragmentInteractionListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }

    /**
     * This interface must be implemented by activities that contain this
     * fragment to allow an interaction in this fragment to be communicated
     * to the activity and potentially other fragments contained in that
     * activity.
     * <p/>
     * See the Android Training lesson <a href=
     * "http://developer.android.com/training/basics/fragments/communicating.html"
     * >Communicating with Other Fragments</a> for more information.
     */
    public interface OnListFragmentInteractionListener {
        // TODO: Update argument type and name
        void onListFragmentInteraction(DummyItem item);
    }
}
