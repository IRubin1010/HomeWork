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
        public static Random randNum = new Random();

        private event EventHandler<PrinterEventArgs> PageMissing;
        private event EventHandler<PrinterEventArgs> InkEmpty;

        public string PrinterName { get; }
        public double InkCount { get; }
        public int PageCount { get; }

        const int MAX_INK = 100;
        const double MIN_ADD_INK = 5.0;
        const double MAX_PRINT_INK = 50.0;
        const int MAX_PAGES = 400;
        const int MIN_ADD_PAGES = 10;
        const int MAX_PTINT_PAGES = 300;

        public PrinterUserControl()
        {
            PrinterName = "printer 1";
            InkCount = randNum.Next(0, 101) + randNum.NextDouble();
            PageCount = randNum.Next(0, 401);
            InitializeComponent();
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
