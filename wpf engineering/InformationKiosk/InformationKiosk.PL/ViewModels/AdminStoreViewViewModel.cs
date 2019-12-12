using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using InformationKiosk.BL;
using InformationKiosk.PL.Controls;
using MaterialDesignThemes.Wpf;
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
        private readonly IceCreamService iceCreamService;
        public RelayCommand RunAddIceCreamDialogCommand { get; set; }

        public AdminStoreViewViewModel()
        {
            iceCreamService = new IceCreamService();
            RunAddIceCreamDialogCommand = new RelayCommand(AddIceCreamDialog, () => true, true);
        }

        public async void AddIceCreamDialog()
        {
            var view = new AddIceCreamDialogControl();
            ((AddIceCreamDialogViewModel)view.DataContext).Store = Store;
            var result = await DialogHost.Show(view, "ManageRootDialog");
            if (result != null)
            {
                var iceCream = result as IceCream;
                //await Task.Run(() => iceCreamService.AddIceCreamAsync(Store, iceCream));
                Store.IceCreams = await Task.Run(() => iceCreamService.GetIceCreamsAsync(Store));
                RaisePropertyChanged(nameof(Store));
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
