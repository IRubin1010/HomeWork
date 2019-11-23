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
    }
}
