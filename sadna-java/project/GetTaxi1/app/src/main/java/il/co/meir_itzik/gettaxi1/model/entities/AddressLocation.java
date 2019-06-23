package il.co.meir_itzik.gettaxi1.model.entities;

import com.google.android.gms.maps.model.LatLng;

public class AddressLocation{
    private String address;
    private Double latitude;
    private Double longitude;

    public AddressLocation(){}

    public AddressLocation(String address, LatLng latLng) {
        this.address = address;
        this.latitude = latLng.latitude;
        this.longitude = latLng.longitude;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public Double getLatitude() {
        return latitude;
    }

    public void setLatitude(Double latitude) {
        this.latitude = latitude;
    }

    public Double getLongitude() {
        return longitude;
    }

    public void setLongitude(Double longitude) {
        this.longitude = longitude;
    }

}
