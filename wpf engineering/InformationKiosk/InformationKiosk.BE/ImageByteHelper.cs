using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace InformationKiosk.BE
{
    public static class ImageByteHelper
    {
        public static byte[] ImageToByte(Bitmap img)
        {
            using (var stream = new MemoryStream())
            {
                using (var a = new Bitmap(img))
                {
                    a.Save(stream, ImageFormat.Jpeg);
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
