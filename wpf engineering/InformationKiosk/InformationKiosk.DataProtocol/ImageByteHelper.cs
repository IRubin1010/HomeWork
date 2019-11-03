using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DataProtocol
{
    public static class ImageByteHelper
    {
        public static byte[] ImageToByte(Bitmap img)
        {
            using (var stream = new MemoryStream())
            {
                using (var a = new Bitmap(img))
                {
                    a.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return stream.ToArray();
                }
            }
        }

        public static Bitmap ByteToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return new Bitmap(ms);
            }
        }
    }
}
