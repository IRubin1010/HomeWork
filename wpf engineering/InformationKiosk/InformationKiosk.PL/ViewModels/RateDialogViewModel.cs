using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InformationKiosk.BE;
using InformationKiosk.BL;
using InformationKiosk.PL.Helpers;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InformationKiosk.PL.ViewModels
{
    public class RateDialogViewModel : ViewModelBase
    {
        private readonly ReviewService reviewService;
        private readonly ImageService imageService;
        public IceCream IceCream;
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand TriggerTelegramComand { get; set; }
        public RelayCommand AddReviewCommand { get; set; }

        public RateDialogViewModel()
        {
            reviewService = new ReviewService();
            imageService = new ImageService();
            CancelCommand = new RelayCommand(CancelDialog, () => true, true);
            AddReviewCommand = new RelayCommand(CloseDialog, CanCloseDialog, true);
            TriggerTelegramComand = new RelayCommand(TriggerTelegram, () => true, true);
        }
        public void init()
        {
            Img = null;
        }

        private async void CloseDialog()
        {
            var review = new Review()
            {
                Score = Score,
                Description = Description,
                Img = Img
            };
            try
            {
                await Task.Run(() => reviewService.AddReviewToIceCreamAsync(IceCream, review));
                ClearFeilds();
                DialogHost.CloseDialogCommand.Execute(review, null);
            }
            catch (Exception ex)
            {
                IsError = true;
            }
        }

        private bool CanCloseDialog()
        {
            return Score > 0 
                && Img != null;
        }

        private void CancelDialog()
        {
            ClearFeilds();
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        private void ClearFeilds()
        {
            Description = "";
            PhoneNumber = "";
            Score = 0;
            Img = null;
        }

        public async void TriggerTelegram()
        {
            Bitmap img = null;
            await Task.Run(async () =>
            {
                bool isIceCreamImage = true;
                var currentDir = Directory.GetCurrentDirectory();
                var imagePath = currentDir + "\\ice-cream-pic.jpg";
                bool isNewConversation = true;
                do
                {
                    RunTelegram(isNewConversation);

                    string imageUrl;

                    imageUrl = await imageService.UploadImageToFirebase(imagePath);
                    var encodedUrl = EncodeImageUrl(imageUrl);
                    isIceCreamImage = await imageService.IsIceCreamImage(encodedUrl);
                    isNewConversation = false;
                } while (!isIceCreamImage);

                img = ImageHelper.ConvertToBitmap(imagePath);
            });

            Img = img;
        }

        private void RunTelegram(bool isNewConversation)
        {
            string progToRun = @"C:\development\personal\telegramDemo\telegramHendler.py";

            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\Users\itziky\AppData\Local\Programs\Python\Python38-32\python.exe";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.Arguments = string.Concat(progToRun, " ", PhoneNumber, " ", isNewConversation);

            proc.Start();
            proc.WaitForExit();
        }

        private string EncodeImageUrl(string url)
        {
            var uri = new Uri(url);
            var newQueryString = HttpUtility.ParseQueryString(uri.Query);

            newQueryString.Remove("token");
            string pagePathWithoutQueryString = uri.GetLeftPart(UriPartial.Path);

            var newUrl = newQueryString.Count > 0
                ? String.Format("{0}?{1}", pagePathWithoutQueryString, newQueryString)
                : pagePathWithoutQueryString;

            return WebUtility.UrlEncode(newUrl);

        }


        #region Binding Fields
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
                AddReviewCommand.RaiseCanExecuteChanged();
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
                AddReviewCommand.RaiseCanExecuteChanged();
            }
        }

        private string _phoneNumber = "";
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (_phoneNumber == value)
                {
                    return;
                }
                _phoneNumber = value;
                if (IsError == true)
                {
                    IsError = false;
                }
                RaisePropertyChanged(nameof(PhoneNumber));
                AddReviewCommand.RaiseCanExecuteChanged();
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
                AddReviewCommand.RaiseCanExecuteChanged();
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
                AddReviewCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion
    }
}
