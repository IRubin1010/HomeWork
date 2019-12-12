using GalaSoft.MvvmLight;
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
    public class UserStoresViewViewModel : ViewModelBase
    {
        private readonly StoreService storeService;

        public UserStoresViewViewModel()
        {
            storeService = new StoreService();
        }

        public async void initStores()
        {
            Stores = new ObservableCollection<Store>();
            var s = new ObservableCollection<Store>(await Task.Run(() => storeService.GetStoresAsync()));
            foreach (var store in s)
            {
                await Task.Run(() => Task.Delay(700));
                Stores.Add(store);
            }
        }

        #region Binding Fields
        private ObservableCollection<Store> _stores = null;
        public ObservableCollection<Store> Stores
        {
            get
            {
                return _stores;
            }
            set
            {
                if (_stores == value)
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
                NevigationCommandParameter = new NevigationCommandParameters()
                {
                    NevigationTarget = "UserStoreView",
                    Parameter = _selectedStore
                };
                RaisePropertyChanged(nameof(SelectedStore));
            }
        }

        private NevigationCommandParameters _nevigationCommandParametes = null;
        public NevigationCommandParameters NevigationCommandParameter
        {
            get
            {
                return _nevigationCommandParametes;
            }
            set
            {
                if (_nevigationCommandParametes == value)
                {
                    return;
                }
                _nevigationCommandParametes = value;
                RaisePropertyChanged(nameof(NevigationCommandParameter));
            }
        }
        #endregion
    }
}
