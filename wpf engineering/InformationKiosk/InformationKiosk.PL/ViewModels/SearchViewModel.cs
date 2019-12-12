using GalaSoft.MvvmLight;
using InformationKiosk.BE;
using InformationKiosk.BL;
using InformationKiosk.PL.Helpers;
using InformationKiosk.PL.Nevigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {

        private readonly IceCreamService iceCreamService;

        public SearchViewModel()
        {
            iceCreamService = new IceCreamService();
            initIceCreams();
        }

        public async void initIceCreams()
        {
            AllIceCreams = new ObservableCollection<IceCream>(await Task.Run(() => iceCreamService.GetIceCreamsAsync()));
        }

        private void applySearch()
        {
            IceCreams = new ObservableCollection<IceCream>(AllIceCreams.Where(i =>
            {
                if(!i.Name.Contains(_searchIceCreamText, StringComparison.OrdinalIgnoreCase) && !i.Description.Contains(_searchIceCreamText, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                if(FatChecked && !FatComparator.Operator(i.Nutrients.Fats, FatSliderValue))
                {
                    return false;
                }
                if (ProteinChecked && !ProteinComparator.Operator(i.Nutrients.Protein, ProteinSliderValue))
                {
                    return false;
                }
                if (EnergyChecked && !EnergyComparator.Operator(i.Nutrients.Energy, EnergySliderValue))
                {
                    return false;
                }
                return true;
            }));
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

        private ObservableCollection<IceCream> _allIceCreams = null;
        public ObservableCollection<IceCream> AllIceCreams
        {
            get
            {
                return _allIceCreams;
            }
            set
            {
                if (_allIceCreams == value)
                {
                    return;
                }
                _allIceCreams = value;
                IceCreams = _allIceCreams;
                RaisePropertyChanged(nameof(AllIceCreams));
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

        private string _searchIceCreamText = "";
        public string SearchIceCreamText
        {
            get
            {
                return _searchIceCreamText;
            }
            set
            {
                if (_searchIceCreamText == value)
                {
                    return;
                }
                _searchIceCreamText = value;
                applySearch();
                RaisePropertyChanged(nameof(SearchIceCreamText));
            }
        }

        public ObservableCollection<string> Comparators { get; } = new ObservableCollection<string>()
        {
            ">",
            ">=",
            "=",
            "<",
            "<="

        };

        private string _fatComparator = ">";
        public string FatComparator
        {
            get
            {
                return _fatComparator;
            }
            set
            {
                if (_fatComparator == value)
                {
                    return;
                }
                _fatComparator = value;
                if (FatChecked)
                {
                    applySearch();
                }
                RaisePropertyChanged(nameof(FatComparator));
            }
        }

        private string _energyComparator = ">";
        public string EnergyComparator
        {
            get
            {
                return _energyComparator;
            }
            set
            {
                if (_energyComparator == value)
                {
                    return;
                }
                _energyComparator = value;
                if (EnergyChecked)
                {
                    applySearch();
                }
                RaisePropertyChanged(nameof(EnergyComparator));
            }
        }

        private string _proteinComparator = ">";
        public string ProteinComparator
        {
            get
            {
                return _proteinComparator;
            }
            set
            {
                if (_proteinComparator == value)
                {
                    return;
                }
                _proteinComparator = value;
                if (ProteinChecked)
                {
                    applySearch();
                }
                RaisePropertyChanged(nameof(ProteinComparator));
            }
        }

        private bool _fatChecked = false;
        public bool FatChecked
        {
            get
            {
                return _fatChecked;
            }
            set
            {
                if (_fatChecked == value)
                {
                    return;
                }
                _fatChecked = value;
                applySearch();
                RaisePropertyChanged(nameof(FatChecked));
            
            }
        }

        private bool _proteinChecked = false;
        public bool ProteinChecked
        {
            get
            {
                return _proteinChecked;
            }
            set
            {
                if (_proteinChecked == value)
                {
                    return;
                }
                _proteinChecked = value;
                applySearch();
                RaisePropertyChanged(nameof(ProteinChecked));

            }
        }

        private bool _energyChecked = false;
        public bool EnergyChecked
        {
            get
            {
                return _energyChecked;
            }
            set
            {
                if (_energyChecked == value)
                {
                    return;
                }
                _energyChecked = value;
                applySearch();
                RaisePropertyChanged(nameof(EnergyChecked));

            }
        }

        private int _fatSliderValue = 0;
        public int FatSliderValue
        {
            get
            {
                return _fatSliderValue;
            }
            set
            {
                if (_fatSliderValue == value)
                {
                    return;
                }
                _fatSliderValue = value;
                applySearch();
                RaisePropertyChanged(nameof(FatSliderValue));

            }
        }

        private int _proteinSliderValue = 0;
        public int ProteinSliderValue
        {
            get
            {
                return _proteinSliderValue;
            }
            set
            {
                if (_proteinSliderValue == value)
                {
                    return;
                }
                _proteinSliderValue = value;
                applySearch();
                RaisePropertyChanged(nameof(ProteinSliderValue));

            }
        }

        private int _energySliderValue = 0;
        public int EnergySliderValue
        {
            get
            {
                return _energySliderValue;
            }
            set
            {
                if (_energySliderValue == value)
                {
                    return;
                }
                _energySliderValue = value;
                applySearch();
                RaisePropertyChanged(nameof(EnergySliderValue));

            }
        }
        #endregion
    }
}
