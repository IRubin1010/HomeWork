using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace InformationKiosk.BE
{
    public static class ImageByteHelper
    {
        public static byte[] ImageToByte(Bitmap img)
        {
            if(img == null)
            {
                return null;
            }
            using (var stream = new MemoryStream())
            {
                using (var i = new Bitmap(img))
                {
                    i.Save(stream, ImageFormat.Jpeg);
                    return stream.ToArray();
                }
            }
        }

        public static Bitmap ByteToImage(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            using (var ms = new MemoryStream(bytes))
            {
                return new Bitmap(ms);
            }
        }
    }
}
