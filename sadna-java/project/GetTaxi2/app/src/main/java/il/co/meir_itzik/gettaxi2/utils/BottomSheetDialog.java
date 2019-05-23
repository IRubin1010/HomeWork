package il.co.meir_itzik.gettaxi2.utils;

import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.net.Uri;
import android.os.Bundle;
import android.provider.ContactsContract;
import android.support.annotation.Nullable;
import android.support.design.widget.BottomSheetDialogFragment;
import android.support.v7.widget.AppCompatImageView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.Gson;

import java.text.SimpleDateFormat;

import il.co.meir_itzik.gettaxi2.R;
import il.co.meir_itzik.gettaxi2.model.backend.BackendFactory;
import il.co.meir_itzik.gettaxi2.model.datasource.DataSource;
import il.co.meir_itzik.gettaxi2.model.entities.Passenger;
import il.co.meir_itzik.gettaxi2.model.entities.Travel;

public class BottomSheetDialog extends BottomSheetDialogFragment {
    private Travel travel;
    private Gson gson = new Gson();
    private TextView fromStreet, fromCity, destinationStreet, destinationCity, time, name, phone, email, comment;
    private Button acceptTravelBtn;
    private DataSource DB = BackendFactory.getDatasource();
    private AppCompatImageView dialPhone, sendSms, sendEmail, addPassenger;
    private Passenger passenger;
    //private BottomSheetListener mListener;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.bottom_sheet, container, false);

        String travelJson = getArguments().getString("travel");
        travel = gson.fromJson(travelJson, Travel.class);
        passenger = travel.getPassenger();

        fromStreet = v.findViewById(R.id.from_street);
        fromCity = v.findViewById(R.id.from_city);
        destinationStreet = v.findViewById(R.id.to_street);
        destinationCity = v.findViewById(R.id.to_city);
        time = v.findViewById(R.id.time);
        name = v.findViewById(R.id.name);
        phone = v.findViewById(R.id.phone);
        email = v.findViewById(R.id.email);
        comment = v.findViewById(R.id.comment);
        acceptTravelBtn = v.findViewById(R.id.accept_travel_btn);
        dialPhone = v.findViewById(R.id.dial_phone);
        addPassenger = v.findViewById(R.id.add_passenger);
        sendSms = v.findViewById(R.id.send_sms);
        sendEmail = v.findViewById(R.id.send_email);

        String fromS = travel.getSource().split(",")[0];
        String fromC = travel.getSource().substring(fromS.length() + 2);

        String toS = travel.getDestination().split(",")[0];
        String toC = travel.getDestination().substring(toS.length() + 2);

        fromStreet.setText(fromS);
        fromCity.setText(fromC);
        destinationStreet.setText(toS);
        destinationCity.setText(toC);
        time.setText(new SimpleDateFormat("dd/MM/yyyy  -  HH:mm").format(travel.getStart().getTime()));
        name.setText(passenger.getFirstName() + " " + passenger.getLastName());
        phone.setText(passenger.getPhoneNumber());
        email.setText(passenger.getEmail());
        comment.setText(travel.getComment());

        acceptTravelBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                DB.updateTravelStatus(travel, Travel.Status.IN_PROGRESS, new DataSource.RunAction<Travel>() {
                    @Override
                    public void onPreExecute() {

                    }

                    @Override
                    public void onSuccess(Travel obj) {
                        Toast toast = Toast.makeText(getActivity(), "Travel accepted successfully", Toast.LENGTH_SHORT);
                        TextView v = toast.getView().findViewById(android.R.id.message);
                        v.setTextColor(Color.GREEN);
                        toast.show();
                        dismiss();
                    }

                    @Override
                    public void onFailure(Travel obj, Exception e) {
                        Toast toast = Toast.makeText(getActivity(), "failed to accept travel", Toast.LENGTH_SHORT);
                        TextView v = toast.getView().findViewById(android.R.id.message);
                        v.setTextColor(Color.RED);
                        toast.show();
                    }

                    @Override
                    public void onPostExecute() {
                    }
                });
            }
        });

        addPassenger.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!PermissionsService.isContactPermissionsGranted(getContext())) {
                    PermissionsService.requestContactPermissions(getActivity());
                }
                if (PermissionsService.isContactPermissionsGranted(getContext())) {
                    Intent intent = new Intent(ContactsContract.Intents.Insert.ACTION);
                    intent.setType(ContactsContract.RawContacts.CONTENT_TYPE);
                    intent
                            .putExtra(ContactsContract.Intents.Insert.NAME,passenger.getFirstName() + " " + passenger.getLastName())
                            .putExtra(ContactsContract.Intents.Insert.PHONE,passenger.getPhoneNumber())
                            .putExtra(ContactsContract.Intents.Insert.EMAIL,passenger.getEmail())
                            .putExtra(ContactsContract.Intents.Insert.PHONE_TYPE,ContactsContract.CommonDataKinds.Phone.TYPE_WORK)
                            .putExtra(ContactsContract.Intents.Insert.EMAIL_TYPE,ContactsContract.CommonDataKinds.Email.TYPE_WORK)
                            ;
                    startActivity(intent);
                }
            }
        });

        dialPhone.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!PermissionsService.isCallPermissionsGranted(getContext())) {
                    PermissionsService.requestPhonePermissions(getActivity());
                }
                if (PermissionsService.isCallPermissionsGranted(getContext())) {
                    Intent intent = new Intent(Intent.ACTION_DIAL);
                    intent.setData(Uri.parse("tel:" + passenger.getPhoneNumber()));
                    startActivity(intent);
                }
            }
        });

        sendSms.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!PermissionsService.isSMSPermissionsGranted(getContext())) {
                    PermissionsService.requestSMSPermissions(getActivity());
                }
                if (PermissionsService.isSMSPermissionsGranted(getContext())) {
                    Intent intent = new Intent(Intent.ACTION_VIEW);
                    intent.setData(Uri.parse("sms:" + passenger.getPhoneNumber()));
                    startActivity(intent);
                }
            }
        });

        sendEmail.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Intent.ACTION_SENDTO);
                intent.setData(Uri.fromParts("mailto", passenger.getEmail(), null));
                startActivity(intent);
            }
        });

        return v;
    }

//    public interface BottomSheetListener {
//        Travel getTravel();
//    }

//    @Override
//    public void onAttach(Context context) {
//        super.onAttach(context);
//
//        try {
//            mListener = (BottomSheetListener) context;
//        } catch (ClassCastException e) {
//            throw new ClassCastException(context.toString()
//                    + " must implement BottomSheetListener");
//        }
//    }
}
