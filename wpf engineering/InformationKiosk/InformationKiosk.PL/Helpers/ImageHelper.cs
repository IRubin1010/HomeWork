using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.Helpers
{
    public static class ImageHelper
    {
        public static Bitmap ConvertToBitmap(string fileName)
        {
            Bitmap bitmap;
            using (Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);

                bitmap = new Bitmap(image);

            }
            return bitmap;
        }

        public static Bitmap ConvertToBitmap(Uri fileNameUri)
        {
            var fileName = fileNameUri.LocalPath;
            return ConvertToBitmap(fileName);
        }
    }
}
