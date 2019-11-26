using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using InformationKiosk.BL;
using InformationKiosk.PL.Controls;
using InformationKiosk.PL.Nevigation;
using MaterialDesignThemes.Wpf;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InformationKiosk.PL.ViewModels
{
    public class UserViewViewModel : ViewModelBase
    {
        public RelayCommand<INevigator> RunLoginDialogCommand { get; set; }

        public UserViewViewModel()
        {
            RunLoginDialogCommand = new RelayCommand<INevigator>(LoginDialog, (nevigator) => true, true);
            Header = "The Stores";
        }

        public async void LoginDialog(INevigator nevigator)
        {
            var view = new LoginDialogControl();
            var result = await DialogHost.Show(view, "DialogPlaceHolder");
            if (result != null && (result as bool?) == true)
            {
                var nevigatorCommand = new NevigatorCommand();
                nevigatorCommand.Nevigator = nevigator;
                nevigatorCommand.Execute(new NevigationCommandParameters("Manage"));
            }
        }

        #region Binding Fields
        private string _header = null;
        public string Header
        {
            get
            {
                return _header;
            }
            set
            {
                if (_header == value)
                {
                    return;
                }
                _header = value;
                RaisePropertyChanged(nameof(Header));
            }
        }
        #endregion
    }
}
