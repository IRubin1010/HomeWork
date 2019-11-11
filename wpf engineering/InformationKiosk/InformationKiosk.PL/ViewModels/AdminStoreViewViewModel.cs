using GalaSoft.MvvmLight;
using InformationKiosk.BE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.ViewModels
{
    public class AdminStoreViewViewModel : ViewModelBase
    {

        public AdminStoreViewViewModel()
        {
            if (IsInDesignMode)
            {
                var localDir = Directory.GetCurrentDirectory().Replace("InformationKiosk.Test\\bin\\Debug", "");
                var imgPath = localDir + "gettyimages-166017058-612x612.jpg";
                Store = new Store
                {
                    Id = Guid.NewGuid(),
                    Name = "stroe1",
                    Address = "adress1",
                    PhoneNumber = "phoneNumber1",
                    Website = "http://localhost:3000",
                    Img = ConvertToBitmap(imgPath),
                    IceCreams = new List<IceCream>()
                };
            }
        }

        private Store _store = null;
        public Store Store
        {
            get
            {
                return _store;
            }
            set
            {
                if (_store == value)
                {
                    return;
                }
                _store = value;
                RaisePropertyChanged(nameof(Store));
            }
        }

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
    }
}
