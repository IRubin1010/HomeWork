using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.ViewModels
{
    public class AddStoreDialogViewModel : ViewModelBase
    {
        public RelayCommand AddStoreCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand LoadImageCommand { get; set; }

        public AddStoreDialogViewModel()
        {
            AddStoreCommand = new RelayCommand(CloseDialog, CanCloseDialog, true);
            CancelCommand = new RelayCommand(CancelDialog, () => true, true);
            LoadImageCommand = new RelayCommand(LoadImage, () => true, true);
        }

        private void CloseDialog()
        { 
            var store = new Store()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Address = Address,
                PhoneNumber = PhoneNumber,
                Website = Website,
                Img = Img,
                IceCreams = new List<IceCream>()
            };
            ClearFeilds();
            DialogHost.CloseDialogCommand.Execute(store, null);
        }

        private bool CanCloseDialog()
        {
            var a = Name.Length > 0
                && Address.Length > 0
                && PhoneNumber.Length > 0
                && Website.Length > 0
                && Img != null;
            return a;
        }

        private void CancelDialog()
        {
            ClearFeilds();
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        private void LoadImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Img = ConvertToBitmap(new Uri(op.FileName));
            }
        }

        private void ClearFeilds()
        {
            Name = "";
            Address = "";
            PhoneNumber = "";
            Website = "";
        }

        private Bitmap _img = null;
        public Bitmap Img
        {
            get
            {
                return _img;
            }
            set
            {
                if (_img == value)
                {
                    return;
                }
                _img = value;
                RaisePropertyChanged(nameof(Img));
                AddStoreCommand.RaiseCanExecuteChanged();
            }
        }

        #region bindings fields
        private string _name = "";
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == value)
                {
                    return;
                }
                _name = value;
                RaisePropertyChanged(nameof(Name));
                AddStoreCommand.RaiseCanExecuteChanged();
            }
        }

        private string _address = "";
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (_address == value)
                {
                    return;
                }
                _address = value;
                RaisePropertyChanged(nameof(Address));
                AddStoreCommand.RaiseCanExecuteChanged();
            }
        }

        private string _phoneNumber = "";
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (_phoneNumber == value)
                {
                    return;
                }
                _phoneNumber = value;
                RaisePropertyChanged(nameof(PhoneNumber));
                AddStoreCommand.RaiseCanExecuteChanged();
            }
        }

        private string _website = "";
        public string Website
        {
            get
            {
                return _website;
            }
            set
            {
                if (_website == value)
                {
                    return;
                }
                _website = value;
                RaisePropertyChanged(nameof(Website));
                AddStoreCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

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
