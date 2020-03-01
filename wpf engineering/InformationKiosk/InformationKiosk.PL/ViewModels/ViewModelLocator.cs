using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ManageViewModel>();
            SimpleIoc.Default.Register<AdminStoreViewViewModel>();
            SimpleIoc.Default.Register<AddStoreDialogViewModel>();
            SimpleIoc.Default.Register<AddIceCreamDialogViewModel>();
            SimpleIoc.Default.Register<LoginDialogViewModel>();
            SimpleIoc.Default.Register<UserViewViewModel>();
            SimpleIoc.Default.Register<UserStoresViewViewModel>();
            SimpleIoc.Default.Register<UserIceCreamsViewViewModel>();
            SimpleIoc.Default.Register<UserStoreViewViewModel>();
            SimpleIoc.Default.Register<RateDialogViewModel>();
            SimpleIoc.Default.Register<UserIceCreamViewViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ManageViewModel Manage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ManageViewModel>();
            }
        }

        public AdminStoreViewViewModel AdminStoreView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AdminStoreViewViewModel>();
            }
        }

        public AddStoreDialogViewModel AddStoreDialog
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddStoreDialogViewModel>();
            }
        }

        public AddIceCreamDialogViewModel AddIceCreamDialog
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddIceCreamDialogViewModel>();
            }
        }

        public LoginDialogViewModel LoginDialog
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginDialogViewModel>();
            }
        }

        public UserViewViewModel UserView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserViewViewModel>();
            }
        }

        public UserStoresViewViewModel UserStoresView
        {
            get
            {
                var uc = new UserStoresViewViewModel(); 
                uc.initStores();
                return uc;
            }
        }

        public UserIceCreamsViewViewModel UserIceCreamsView
        {
            get
            {
                var uc = new UserIceCreamsViewViewModel();
                uc.initIceCreams();
                return uc;
            }
        }

        public UserIceCreamViewViewModel UserIceCreamView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserIceCreamViewViewModel>();
            }
        }

        public UserStoreViewViewModel UserStoreView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserStoreViewViewModel>();
            }
        }

        public RateDialogViewModel RateDialog
        {
            get
            {
                var uc = ServiceLocator.Current.GetInstance<RateDialogViewModel>();
                uc.init();
                return uc;
            }
        }

        public SearchViewModel Search
        {
            get
            {
                return new SearchViewModel();
            }
        }
    }
}
