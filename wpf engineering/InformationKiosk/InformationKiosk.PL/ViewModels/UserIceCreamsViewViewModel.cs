using GalaSoft.MvvmLight;
using InformationKiosk.BE;
using InformationKiosk.BL;
using InformationKiosk.PL.Nevigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.ViewModels
{
    public class UserIceCreamsViewViewModel : ViewModelBase
    {
        private readonly IceCreamService iceCreamService;

        public UserIceCreamsViewViewModel()
        {
            iceCreamService = new IceCreamService();
        }

        public async void initIceCreams()
        {
            IceCreams = new ObservableCollection<IceCream>();
            var iceCreams = new ObservableCollection<IceCream>(await Task.Run(() => iceCreamService.GetIceCreamsAsync()));
            foreach (var iceCream in iceCreams)
            {
                await Task.Run(() => Task.Delay(700));
                IceCreams.Add(iceCream);
            }
        }

        #region Binding Fields
        private ObservableCollection<IceCream> _iceCreams = null;
        public ObservableCollection<IceCream> IceCreams
        {
            get
            {
                return _iceCreams;
            }
            set
            {
                if (_iceCreams == value)
                {
                    return;
                }
                _iceCreams = value;
                RaisePropertyChanged(nameof(IceCreams));
            }
        }

        private IceCream _selectedIceCream = null;
        public IceCream SelectedIceCream
        {
            get
            {
                return _selectedIceCream;
            }
            set
            {
                if (_selectedIceCream == value)
                {
                    return;
                }
                _selectedIceCream = value;
                NevigationCommandParameter = new NevigationCommandParameters()
                {
                    NevigationTarget = "UserIceCreamView",
                    Parameter = _selectedIceCream
                };
                RaisePropertyChanged(nameof(SelectedIceCream));
            }
        }

        private NevigationCommandParameters _nevigationCommandParametes = null;
        public NevigationCommandParameters NevigationCommandParameter
        {
            get
            {
                return _nevigationCommandParametes;
            }
            set
            {
                if (_nevigationCommandParametes == value)
                {
                    return;
                }
                _nevigationCommandParametes = value;
                RaisePropertyChanged(nameof(NevigationCommandParameter));
            }
        }
        #endregion
    }
}
