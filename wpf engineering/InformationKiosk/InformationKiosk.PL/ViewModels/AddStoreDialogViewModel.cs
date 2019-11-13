using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using InformationKiosk.PL.Helpers;

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
            return Name.Length > 0
                && Address.Length > 0
                && PhoneNumber.Length > 0
                && Website.Length > 0
                && Img != null;
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
                Img = ImageHelper.ConvertToBitmap(new Uri(op.FileName));
            }
        }

        private void ClearFeilds()
        {
            Name = "";
            Address = "";
            PhoneNumber = "";
            Website = "";
            Img = null;
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
        #endregion

        
    }
}
