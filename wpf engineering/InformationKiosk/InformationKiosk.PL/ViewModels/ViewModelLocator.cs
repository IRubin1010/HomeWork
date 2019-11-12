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
    }
}
