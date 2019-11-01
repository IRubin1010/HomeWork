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
                using (var stream = new MemoryStream())
                {
                    using (var a = new Bitmap(Img))
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

        public Guid StoreId { get; set; }
        public Store Store { get; set; }

        public Nutrients Nutrients { get; set; }


    }
}
