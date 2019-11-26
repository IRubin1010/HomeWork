using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.ViewModels
{
    public class RateDialogViewModel : ViewModelBase
    {
        public RelayCommand CancelCommand { get; set; }
        public RateDialogViewModel()
        {
            CancelCommand = new RelayCommand(CancelDialog, () => true, true);
        }
        
        private void CancelDialog()
        {
            //ClearFeilds();
            DialogHost.CloseDialogCommand.Execute(null, null);
        }
    }
}
