using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace InformationKiosk.BE
{
    public class IceCream
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
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

        public Guid StoreId { get; set; }
        public Store Store { get; set; }

        public Nutrients Nutrients { get; set; }

        public List<Reviews> Reviews { get; set; }

    }
}
