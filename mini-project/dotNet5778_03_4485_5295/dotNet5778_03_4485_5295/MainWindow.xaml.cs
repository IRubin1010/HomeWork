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

        // intialize the printers 
        private void inttializePrinters()
        {
            queue = new Queue<PrinterUserControl>();
            // add the printers to the queue
            foreach (Control item in printersGrid.Children)
            {
                if (item is PrinterUserControl)
                {
                    PrinterUserControl printer = item as PrinterUserControl;
                    // add the events
                    printer.PageMissing += NoPages; 
                    printer.InkEmpty += lowInk;
                    queue.Enqueue(printer);
                }
            }
            CourentPrinter = queue.Dequeue();
        }

        // event for if there is no pages
        private void NoPages(object sender, PrinterEventArgs e)
        {
            PrinterUserControl printer = sender as PrinterUserControl;
            if (printer != null)
            {
                // if theis is a critical event send an appropriate message box 
                if (e.Critical == true) 
                {
                    printer.pageLabel.Foreground = Brushes.Red;
                    string message = "at: " + e.Time + '\n' + "message from printer: " + e.Error;
                    string caption = e.PrinterName + " Page Missing!!!";
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon);
                    // if press OK switch printer
                    if (result == MessageBoxResult.OK)
                    {
                        printer.AddPages();
                        queue.Enqueue(CourentPrinter);
                        CourentPrinter = queue.Dequeue();
                    }
                }
            }
        }

        // event for if there is no ink
        private void lowInk(object sender, PrinterEventArgs e)
        {
            PrinterUserControl printer = sender as PrinterUserControl;
            if (printer != null)
            {
                // if theis is a critical event - there is no ink
                // send an appropriate message box
                if (e.Critical == true)
                {
                    printer.inkLabel.Foreground = Brushes.Red;
                    string message = "at: " + e.Time + '\n' + "message from printer: " + e.Error;
                    string caption = e.PrinterName + " Ink Missing!!!";
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon);
                    // if press OK
                    if (result == MessageBoxResult.OK)
                    {
                        printer.AddInk();
                        // if didn't switched printers yet
                        // switch printers
                        if (printer == CourentPrinter)
                        {
                            queue.Enqueue(CourentPrinter);
                            CourentPrinter = queue.Dequeue();
                        }
                    }
                }
                // if this is not a critical event - lwo ink
                else
                {
                    // change the color of the label
                    // according to the amount of ink
                    if (printer.InkCount > 10)
                        printer.inkLabel.Foreground = Brushes.Yellow;
                    else printer.inkLabel.Foreground = Brushes.Orange;
                    // send an appropriate message box
                    string message = "at: " + e.Time + '\n' + "message from printer: " + e.Error;
                    string caption = e.PrinterName + " Ink Missing!!!";
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon);
                }
            }
        }

        // event for clicck on print button 
        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                CourentPrinter.print();
            }

        }
    }
}
