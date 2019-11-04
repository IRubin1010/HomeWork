using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DataProtocol
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public int Score { get; set; }

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
        public Guid IceCreamId { get; set; }
        public IceCream IceCream { get; set; }
    }
}
