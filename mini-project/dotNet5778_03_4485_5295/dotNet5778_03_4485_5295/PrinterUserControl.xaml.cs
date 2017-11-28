using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet5778_03_4485_5295
{
    /// <summary>
    /// Interaction logic for PrinterUserControl.xaml
    /// </summary>
    public partial class PrinterUserControl : UserControl
    {
        private static int i = 1;
        public static Random randNum = new Random();

        internal event EventHandler<PrinterEventArgs> PageMissing;
        internal event EventHandler<PrinterEventArgs> InkEmpty;

        public string PrinterName { get; set; }
        public double InkCount { get; set; }
        public int PageCount { get; set; }

        const int MAX_INK = 100;
        const double MIN_ADD_INK = 15.0;
        const double MAX_PRINT_INK = 100.0;
        const int MAX_PAGES = 400;
        const int MIN_ADD_PAGES = 10;
        const int MAX_PRINT_PAGES = 300;

        public PrinterUserControl()
        {
            PrinterName = "printer " + i;
            InkCount = randNum.Next(0, 101) + randNum.NextDouble();
            PageCount = randNum.Next(0, 401);
            InitializeComponent();
            i++;
        }

        public void AddPages()
        {
            int addPage;
            if (MAX_PAGES - PageCount < MAX_PRINT_PAGES)
                addPage = MAX_PAGES - PageCount;
            else addPage = MAX_PRINT_PAGES;
            PageCount = randNum.Next(MIN_ADD_PAGES, addPage);
            pageCountSlider.Value = PageCount;
            pageLabel.Foreground = Brushes.Black;
        }

        public void AddInk()
        {
            double addInk;
            if (MAX_INK - InkCount < MAX_PRINT_INK)
                addInk = MAX_INK - InkCount;
            else addInk = MAX_PRINT_INK - 1;
            InkCount = randNum.Next((int)MIN_ADD_INK, (int)addInk) + randNum.NextDouble();
            inkCountProgressBar.Value = InkCount;
            inkLabel.Foreground = Brushes.Black;
        }

        public void print()
        {
            PageCount -= randNum.Next(1, 20);
            InkCount -= randNum.Next(1, 5);
            if (InkCount < 0) InkCount = 0;
            pageCountSlider.Value = PageCount;
            inkCountProgressBar.Value = InkCount;
            if(PageCount < 0)
            {
                PageMissing(this, new PrinterEventArgs(true, "Missing " + (-1 * PageCount) + " pages", PrinterName));
            }
            if (InkCount < 15 && InkCount > 1)
                InkEmpty(this, new PrinterEventArgs(false, "your ink is only " + (int)InkCount + " %", PrinterName));
            else if (InkCount < 1)
                InkEmpty(this, new PrinterEventArgs(true, "your ink is only " + (int)InkCount + " %", PrinterName));
        }

        private void printerNameLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Label label)
                label.FontSize = 25;
        }

        private void printerNameLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Label label)
                label.FontSize = 16;
        }

        private void inkCountProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ProgressBar progressBar = sender as ProgressBar;
            progressBar.Value = InkCount;
            progressBar.ToolTip = "ink: " + string.Format("{0:F1}", progressBar.Value) + "%";
        }

        private void pageCountSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            slider.Value = PageCount;
            
        }

        private void printerNameLabel_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is Label label)
            {
                label.Content = PrinterName;
            }
        }
    }
}
