using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using InformationKiosk.PL.Helpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using MaterialDesignThemes.Wpf;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace InformationKiosk.PL.ViewModels
{
    public class AddIceCreamDialogViewModel : ViewModelBase
    {
        public RelayCommand AddIceCreamCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand LoadImageCommand { get; set; }

        public AddIceCreamDialogViewModel()
        {
            AddIceCreamCommand = new RelayCommand(CloseDialog, CanCloseDialog, true);
            CancelCommand = new RelayCommand(CancelDialog, () => true, true);
            LoadImageCommand = new RelayCommand(LoadImage, () => true, true);
        }

        private void CloseDialog()
        {
            var iceCream = new IceCream()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Description = Description,
                Score = Score,
                Img = Img,
                NutritionId = NutritionId
            };
            ClearFeilds();
            DialogHost.CloseDialogCommand.Execute(iceCream, null);
        }

        private bool CanCloseDialog()
        {
            return Name.Length > 0
                && Description.Length > 0
                && Img != null
                && NutritionId > 0;
        }

        private void CancelDialog()
        {
            ClearFeilds();
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        private void LoadImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Img = ImageHelper.ConvertToBitmap(new Uri(op.FileName));
            }
        }

        private void ClearFeilds()
        {
            Name = "";
            Description = "";
            Score = 0;
            Img = null;
            NutritionId = 0;
        }

        #region Binding fields
        private string _name = "";
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == value)
                {
                    return;
                }
                _name = value;
                RaisePropertyChanged(nameof(Name));
                AddIceCreamCommand.RaiseCanExecuteChanged();
            }
        }

        private string _description = "";
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description == value)
                {
                    return;
                }
                _description = value;
                RaisePropertyChanged(nameof(Description));
                AddIceCreamCommand.RaiseCanExecuteChanged();
            }
        }

        private int _score = 0;
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                if (_score == value)
                {
                    return;
                }
                _score = value;
                RaisePropertyChanged(nameof(Score));
                AddIceCreamCommand.RaiseCanExecuteChanged();
            }
        }

        private int _nutritionId = 0;
        public int NutritionId
        {
            get
            {
                return _nutritionId;
            }
            set
            {
                if (_nutritionId == value)
                {
                    return;
                }
                _nutritionId = value;
                RaisePropertyChanged(nameof(NutritionId));
                AddIceCreamCommand.RaiseCanExecuteChanged();
            }
        }

        private Bitmap _img = null;
        public Bitmap Img
        {
            get
            {
                return _img;
            }
            set
            {
                if (_img == value)
                {
                    return;
                }
                _img = value;
                RaisePropertyChanged(nameof(Img));
                AddIceCreamCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion
    }
}
