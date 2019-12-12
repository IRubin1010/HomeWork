using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using InformationKiosk.BL;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.ViewModels
{
    public class LoginDialogViewModel : ViewModelBase
    {
        private readonly AdministratorService administratorService;

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }


        public LoginDialogViewModel()
        {
            administratorService = new AdministratorService();
            LoginCommand = new RelayCommand(CloseDialog, CanCloseDialog, true);
            CancelCommand = new RelayCommand(CancelDialog, () => true, true);
        }

        private async void CloseDialog()
        {
            var administrator = await Task.Run(() => administratorService.GetAdministratorAsync(UserName, Password));
            if(administrator != null)
            {
                ClearFeilds();
                DialogHost.CloseDialogCommand.Execute(true, null);
            }
            else
            {
                IsIncorrectCredentials = true;
            }
        }

        private bool CanCloseDialog()
        {
            return UserName.Length > 0
                && Password.Length > 0;
        }

        private void CancelDialog()
        {
            ClearFeilds();
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        private void ClearFeilds()
        {
            UserName = "";
            Password = "";
        }

        #region Bindings Fields
        private string _userName = "";
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (_userName == value)
                {
                    return;
                }
                _userName = value;
                if (IsIncorrectCredentials)
                {
                    IsIncorrectCredentials = false;
                }
                RaisePropertyChanged(nameof(UserName));
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        private string _password = "";
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password == value)
                {
                    return;
                }
                _password = value;
                if (IsIncorrectCredentials)
                {
                    IsIncorrectCredentials = false;
                }
                RaisePropertyChanged(nameof(Password));
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _isIncorrectCredentials = false;
        public bool IsIncorrectCredentials
        {
            get
            {
                return _isIncorrectCredentials;
            }
            set
            {
                if (_isIncorrectCredentials == value)
                {
                    return;
                }
                _isIncorrectCredentials = value;
                RaisePropertyChanged(nameof(IsIncorrectCredentials));
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion 
    }
}
