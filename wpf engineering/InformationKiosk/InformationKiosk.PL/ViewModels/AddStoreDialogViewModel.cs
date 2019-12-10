using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using InformationKiosk.PL.Helpers;
using System.Threading.Tasks;
using InformationKiosk.BL;
using BingMapsRESTToolkit;

namespace InformationKiosk.PL.ViewModels
{
    public class AddStoreDialogViewModel : ViewModelBase
    {
        private readonly StoreService storeService;
        public RelayCommand AddStoreCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand LoadImageCommand { get; set; }

        public AddStoreDialogViewModel()
        {
            storeService = new StoreService();
            AddStoreCommand = new RelayCommand(CloseDialog, CanCloseDialog, true);
            CancelCommand = new RelayCommand(CancelDialog, () => true, true);
            LoadImageCommand = new RelayCommand(LoadImage, () => true, true);
        }

        private async void CloseDialog()
        {
            var location = new SimpleWaypoint(Address);
            await SimpleWaypoint.TryGeocodeWaypoints(new List<SimpleWaypoint>() { location }, "AttsGkqIHCOIEA11KtQZDphl5bi8lppin64jeg-ZOOhiS4cdHA_EXJwHSbyZi4Xo");
            var store = new Store()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Location = new StoreLocation()
                {
                    Id = Guid.NewGuid(),
                    Address = location.Address,
                    longitude = location.Coordinate.Longitude,
                    latitude = location.Coordinate.Latitude
                },
                PhoneNumber = PhoneNumber,
                Website = Website,
                Img = Img,
                IceCreams = new List<IceCream>()
            };
            try
            {
                await Task.Run(() => storeService.AddStoreAsync(store));
                ClearFeilds();
                DialogHost.CloseDialogCommand.Execute(store, null);
            }
            catch(Exception ex)
            {
                IsError = true;
            }
            
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

        private async void LoadImage()
        {
            Bitmap img = null;
            await Task.Run(() =>
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";
                if (op.ShowDialog() == true)
                {
                    img = ImageHelper.ConvertToBitmap(new Uri(op.FileName));
                }
            });
            Img = img;
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
                if(IsError == true)
                {
                    IsError = false;
                }
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
                if (IsError == true)
                {
                    IsError = false;
                }
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
                if (IsError == true)
                {
                    IsError = false;
                }
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
                if (IsError == true)
                {
                    IsError = false;
                }
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
                if (IsError == true)
                {
                    IsError = false;
                }
                RaisePropertyChanged(nameof(Img));
                AddStoreCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _isError = false;
        public bool IsError
        {
            get
            {
                return _isError;
            }
            set
            {
                if (_isError == value)
                {
                    return;
                }
                _isError = value;
                RaisePropertyChanged(nameof(IsError));
                AddStoreCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion


    }
}
