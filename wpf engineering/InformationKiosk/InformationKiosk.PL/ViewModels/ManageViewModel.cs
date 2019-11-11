using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using InformationKiosk.BL;
using InformationKiosk.PL.Nevigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.ViewModels
{
    public class ManageViewModel : ViewModelBase
    {
        private StoreService storeService;

        public ManageViewModel() :base()
        {
            storeService = new StoreService();

            if (IsInDesignMode)
            {
                Stores = new ObservableCollection<Store>()
                {
                    new Store()
                    {
                        Id = Guid.NewGuid(),
                        Address = "qqq"
                    },
                    new Store()
                    {
                        Id = Guid.NewGuid(),
                        Address = "aaa"
                    },
                    new Store()
                    {
                        Id = Guid.NewGuid(),
                        Address = "zzz"
                    }
                };
            }
            else
            {
                initStores();
            }

        }

        public async void initStores()
        {
            var a  = new ObservableCollection<Store>( await Task.Run(() => storeService.GetStoresAsync()));
            Stores = a;
        }


        #region bindings fields
        private ObservableCollection<Store> _stores = null;
        public ObservableCollection<Store> Stores
        {
            get
            {
                return _stores;
            }
            set
            {
                if(_stores == value)
                {
                    return;
                }
                _stores = value;
                RaisePropertyChanged(nameof(Stores));
            }
        }

        private Store _selectedStore = null;
        public Store SelectedStore
        {
            get
            {
                return _selectedStore;
            }
            set
            {
                if (_selectedStore == value)
                {
                    return;
                }
                _selectedStore = value;
                RaisePropertyChanged(nameof(SelectedStore));
            }
        }
        #endregion
    }
}
