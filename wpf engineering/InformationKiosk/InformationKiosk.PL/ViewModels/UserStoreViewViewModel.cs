using BingMapsRESTToolkit;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using InformationKiosk.BL;
using InformationKiosk.PL.Controls;
using MaterialDesignThemes.Wpf;
using MapLocation = Microsoft.Maps.MapControl.WPF.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.ViewModels
{
    public class UserStoreViewViewModel : ViewModelBase
    {
        private readonly StoreService storeService;
        public RelayCommand<object> RunRateDialogCommand { get; set; }

        public UserStoreViewViewModel()
        {
            storeService = new StoreService();
            RunRateDialogCommand = new RelayCommand<object>(RateDialog, (obj) => true, true);
        }


        public async void RateDialog(object obj)
        {
            var iceCream = obj as IceCream;
            var view = new RateDialogControl();
            ((RateDialogViewModel)view.DataContext).IceCream = iceCream;
            var result = await DialogHost.Show(view, "DialogPlaceHolder");
            if (result != null)
            {
                var store = await Task.Run(() => storeService.GetStoreAsync(Store.Id));
                Store = store;
            }
        }

        #region Binding Fields 
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
                Location = Store.Location.Location;
                RaisePropertyChanged(nameof(Store));
            }
        }

        private MapLocation _location = new MapLocation();
        public MapLocation Location
        {
            get
            {
                return _location;
            }
            set
            {
                if (_location == value)
                {
                    return;
                }
                _location = value;
                RaisePropertyChanged(nameof(Location));
            }
        }

        #endregion
    }
}
