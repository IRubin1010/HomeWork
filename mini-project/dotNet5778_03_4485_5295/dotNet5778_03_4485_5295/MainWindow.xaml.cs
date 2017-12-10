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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PrinterUserControl CourentPrinter;
        Queue<PrinterUserControl> queue;


        public MainWindow()
        {
            InitializeComponent();
            inttializePrinters();
        }

        private void inttializePrinters()
        {
            queue = new Queue<PrinterUserControl>();
            foreach (Control item in printersGrid.Children)
            {
                if (item is PrinterUserControl)
                {
                    PrinterUserControl printer = item as PrinterUserControl;
                    printer.PageMissing += NoPages;
                    printer.InkEmpty += lowInk;
                    queue.Enqueue(printer);
                }
            }
            CourentPrinter = queue.Dequeue();
        }

        private void NoPages(object sender, PrinterEventArgs e)
        {
            PrinterUserControl printer = sender as PrinterUserControl;
            if (printer != null)
            {
                if (e.Critical == true)
                {
                    printer.pageLabel.Foreground = Brushes.Red;
                    string message = "at: " + e.Time + '\n' + "message from printer: " + e.Error;
                    string caption = e.PrinterName + " Page Missing!!!";
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon);

                    if (result == MessageBoxResult.OK)
                    {
                        printer.AddPages();
                        queue.Enqueue(CourentPrinter);
                        CourentPrinter = queue.Dequeue();
                    }
                }
            }
        }

        private void lowInk(object sender, PrinterEventArgs e)
        {
            PrinterUserControl printer = sender as PrinterUserControl;
            if (printer != null)
            {
                if (e.Critical == true)
                {
                    printer.inkLabel.Foreground = Brushes.Red;
                    string message = "at: " + e.Time + '\n' + "message from printer: " + e.Error;
                    string caption = e.PrinterName + " Ink Missing!!!";
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon);

                    if (result == MessageBoxResult.OK)
                    {
                        printer.AddInk();
                        if (printer == CourentPrinter)
                        {
                            queue.Enqueue(CourentPrinter);
                            CourentPrinter = queue.Dequeue();
                        }
                    }
                }
                else
                {
                    if (printer.InkCount > 10)
                        printer.inkLabel.Foreground = Brushes.Yellow;
                    else printer.inkLabel.Foreground = Brushes.Orange;
                    string message = "at: " + e.Time + '\n' + "message from printer: " + e.Error;
                    string caption = e.PrinterName + " Ink Missing!!!";
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon);
                }
            }
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                CourentPrinter.print();
            }


        }
    }
}
