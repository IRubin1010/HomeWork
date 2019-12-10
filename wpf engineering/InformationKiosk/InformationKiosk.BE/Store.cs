using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace InformationKiosk.BE
{
    public class Store
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public StoreLocation Location { get; set; }

        [NotMapped]
        public Bitmap Img { get; set; } 
        public byte[] ImgAsBytes 
        {
            get
            {
                return ImageByteHelper.ImageToByte(Img);
            }
            set
            {
                Img = ImageByteHelper.ByteToImage(value);
            }
        }

        public string PhoneNumber { get; set; }
        public string Website
        {
            get
            {
                return this.WebsiteUri?.AbsoluteUri;
            }
            set
            {
                WebsiteUri = new Uri(value);
            }
        } 
        public List<IceCream> IceCreams { get; set; }
        [NotMapped]
        public Uri WebsiteUri { get; set; }

    }

    public class StoreLocation
    {
        public Guid Id { get; set; }

        public string Address { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }

        public Location Location
        {
            get
            {
                return new Location(latitude, longitude);
            }
        }

        public Guid StoreId { get; set; }
    }
}
