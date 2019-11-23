using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using InformationKiosk.BL;
using InformationKiosk.PL.Controls;
using InformationKiosk.PL.Nevigation;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //public RelayCommand<INevigator> RunLoginDialogCommand { get; set; }
        public MainViewModel()
        {
            //RunLoginDialogCommand = new RelayCommand<INevigator>(LoginDialog, (nevigator) => true, true);
        }

        //public async void LoginDialog(INevigator nevigator)
        //{
        //    var view = new LoginDialogControl();
        //    var result = await DialogHost.Show(view, "LoginDialog");
        //    if (result != null && (result as bool?) == true)
        //    {
        //        var nevigatorCommand = new NevigatorCommand();
        //        nevigatorCommand.Nevigator = nevigator;
        //        nevigatorCommand.Execute(new NevigationCommandParameters("Manage"));
        //    }
        //}
    }
}
