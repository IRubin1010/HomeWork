using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using InformationKiosk.BL;
using InformationKiosk.PL.Controls;
using InformationKiosk.PL.Nevigation;
using MaterialDesignThemes.Wpf;
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
        private readonly StoreService storeService;
        public RelayCommand RunAddStoreDialogCommand { get; set; }

        public ManageViewModel() : base()
        {
            storeService = new StoreService();
            RunAddStoreDialogCommand = new RelayCommand(AddStoreDialog, () => true, true);
            initStores();

        }

        public async void initStores()
        {
            Stores = new ObservableCollection<Store>(await Task.Run(() => storeService.GetStoresAsync()));
        }

        public async void AddStoreDialog()
        {
            var view = new AddStoreDialogControl();
            var result = await DialogHost.Show(view, "ManageRootDialog");
            if (result != null)
            {
                var store = result as Store;
                await Task.Run(() => storeService.AddStoreAsync(store));
                Stores = new ObservableCollection<Store>(await Task.Run(() => storeService.GetStoresAsync()));
            }
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
                RaisePropertyChanged(nameof(SelectedStore));
            }
        }
        #endregion
    }
}
