using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DataProtocol
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
                using (var stream = new MemoryStream())
                {
                    using(var a = new Bitmap(Img))
                    {
                        a.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return stream.ToArray();
                    }
                }
            }
            set
            {
                using (var ms = new MemoryStream(value))
                {
                    Img = new Bitmap(ms);
                }
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
