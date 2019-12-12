using InformationKiosk.PL.Nevigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace InformationKiosk.PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INevigator
    {
        public NevigatorCommand Nevigator { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            //int x = 1;
            //int y = 2;
            //string progToRun = @"C:\development\personal\telegramDemo\telegramHendler.py";
            //char[] spliter = { '\r' };

            //Process proc = new Process();
            //proc.StartInfo.FileName = @"C:\Users\itziky\AppData\Local\Programs\Python\Python38-32\python.exe"; //C:\Users\itziky\AppData\Local\Programs\Python\Python38-32\python.exe
            //proc.StartInfo.RedirectStandardOutput = true;
            //proc.StartInfo.UseShellExecute = false;

            //// call hello.py to concatenate passed parameters
            //proc.StartInfo.Arguments = string.Concat(progToRun, " ", x.ToString(), " ", y.ToString());
            //proc.Start();

            //StreamReader sReader = proc.StandardOutput;
            //string[] output = sReader.ReadToEnd().Split(spliter);

            //foreach (string s in output)
            //    Console.WriteLine(s);

            //proc.WaitForExit();

            NevigatorCommand nevigatorCommand = Resources["NevigatorCommand"] as NevigatorCommand;
            nevigatorCommand.Nevigator = this;
        }

        public void NevigateTo(UserControl control)
        {
            BaseGrid.Children.Clear();
            BaseGrid.Children.Add(control);
        }
    }
}
