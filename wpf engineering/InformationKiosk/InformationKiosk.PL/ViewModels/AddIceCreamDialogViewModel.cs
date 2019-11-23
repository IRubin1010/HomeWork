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
using InformationKiosk.BL;

namespace InformationKiosk.PL.ViewModels
{
    public class AddIceCreamDialogViewModel : ViewModelBase
    {
        private readonly IceCreamService iceCreamService;
        public Store Store { get; set; }
        public RelayCommand AddIceCreamCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand LoadImageCommand { get; set; }

        public AddIceCreamDialogViewModel()
        {
            iceCreamService = new IceCreamService();
            AddIceCreamCommand = new RelayCommand(CloseDialog, CanCloseDialog, true);
            CancelCommand = new RelayCommand(CancelDialog, () => true, true);
            LoadImageCommand = new RelayCommand(LoadImage, () => true, true);
        }

        private async void CloseDialog()
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
            try
            {
                await Task.Run(() => iceCreamService.AddIceCreamAsync(Store, iceCream));
                ClearFeilds();
                DialogHost.CloseDialogCommand.Execute(iceCream, null);
            }
            catch(Exception ex)
            {
                IsError = true;
            }
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
                if (IsError == true)
                {
                    IsError = false;
                }
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
                if (IsError == true)
                {
                    IsError = false;
                }
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
                if (IsError == true)
                {
                    IsError = false;
                }
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
                if (IsError == true)
                {
                    IsError = false;
                }
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
                if (IsError == true)
                {
                    IsError = false;
                }
                RaisePropertyChanged(nameof(Img));
                AddIceCreamCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _isError = false;
        public bool IsError
        {
            get
            {
                return _isError;
            }
            set
            {
                if (_isError == value)
                {
                    return;
                }
                _isError = value;
                RaisePropertyChanged(nameof(IsError));
                AddIceCreamCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion
    }
}
