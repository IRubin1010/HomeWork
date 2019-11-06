using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using InformationKiosk.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly AdministratorService _adminService;
        private Administrator _admin = new Administrator();
        public RelayCommand AddUserCommand { get; set; }
        public MainViewModel()
        {
            _adminService = new AdministratorService();
            AddUserCommand = new RelayCommand(
                () => AddAdmin(),
                () => true,
                true
                );
        }

        public async Task AddAdmin()
        {
            try
            {
                _admin = await _adminService.AddNewAdministratorcAsync("admin", "admin", "admin@admin.com", "123456").ConfigureAwait(false);
                UserName = _admin.FirstName;
            }
            catch(Exception e)
            {
                UserName = "exception";
            }
        }

        private string _userName = null;
        public string UserName
        {
            get
            {
                return _admin.FirstName;
            }
            set
            {
                if (_userName == value)
                {
                    return;
                }
                _admin.FirstName = value;
                RaisePropertyChanged("UserName");
            }
        }
    }
}
