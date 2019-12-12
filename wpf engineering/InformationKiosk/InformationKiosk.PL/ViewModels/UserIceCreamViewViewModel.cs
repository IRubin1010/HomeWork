using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using InformationKiosk.BL;
using InformationKiosk.PL.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapLocation = Microsoft.Maps.MapControl.WPF.Location;

namespace InformationKiosk.PL.ViewModels
{
    public class UserIceCreamViewViewModel : ViewModelBase
    {
        private readonly IceCreamService iceCreamService;
        public RelayCommand RunRateDialogCommand { get; set; }

        public UserIceCreamViewViewModel()
        {
            iceCreamService = new IceCreamService();
            RunRateDialogCommand = new RelayCommand(RateDialog, () => true, true);
        }

        public async void RateDialog()
        {
            var view = new RateDialogControl();
            ((RateDialogViewModel)view.DataContext).IceCream = IceCream;
            var result = await DialogHost.Show(view, "DialogPlaceHolder");
            if (result != null)
            {
                var iceCream = await Task.Run(() => iceCreamService.GetIceCreamAsync(IceCream.Id));
                IceCream = iceCream;
            }
        }

        private IceCream _iceCream = null;
        public IceCream IceCream
        {
            get
            {
                return _iceCream;
            }
            set
            {
                if (_iceCream == value)
                {
                    return;
                }
                _iceCream = value;
                Location = _iceCream.Store.Location.Location;
                RaisePropertyChanged(nameof(IceCream));
            }
        }

        private MapLocation _location = new MapLocation();
        public MapLocation Location
        {
            get
            {
                return _location;
            }
            set
            {
                if (_location == value)
                {
                    return;
                }
                _location = value;
                RaisePropertyChanged(nameof(Location));
            }
        }
    }
}
