using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using InformationKiosk.PL.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.ViewModels
{
    public class UserStoreViewViewModel : ViewModelBase
    {
        public RelayCommand RunRateDialogCommand { get; set; }

        public UserStoreViewViewModel()
        {
            RunRateDialogCommand = new RelayCommand(RateDialog, () => true, true);
        }

        public async void RateDialog()
        {
            var view = new RateDialogControl();
            var result = await DialogHost.Show(view, "DialogPlaceHolder");
            if (result != null && (result as bool?) == true)
            {
                //var nevigatorCommand = new NevigatorCommand();
                //nevigatorCommand.Nevigator = nevigator;
                //nevigatorCommand.Execute(new NevigationCommandParameters("Manage"));
            }
        }

        #region Vinding Fields 
        private Store _store = null;
        public Store Store
        {
            get
            {
                return _store;
            }
            set
            {
                if (_store == value)
                {
                    return;
                }
                _store = value;
                RaisePropertyChanged(nameof(Store));
            }
        }
        #endregion
    }
}
