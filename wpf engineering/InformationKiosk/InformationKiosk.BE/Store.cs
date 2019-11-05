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
        public string Address { get; set; }
        
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
                return this.WebsiteUri.AbsoluteUri;
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
}
