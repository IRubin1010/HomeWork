using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using InformationKiosk.BL;
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

        public RelayCommand<Store> ShowDetailCommand { get; set; }
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

            ShowDetailCommand = new RelayCommand<Store>(param => this.ShowDetails(param));

        }

        public async void initStores()
        {
            var a  = new ObservableCollection<Store>( await Task.Run(() => storeService.GetStoresAsync()));
            Stores = a;
        }

        public void ShowDetails(Store obj)
        {
            //var a = obj as Store;
            Console.WriteLine("aaaa");
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
        #endregion
    }
}
