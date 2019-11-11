using InformationKiosk.PL.Nevigation;
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

            NevigatorCommand nevigatorCommand = Resources["NevigatorCommand"] as NevigatorCommand;
            nevigatorCommand.Nevigator = this;
        }

        public void NevigateTo(UserControl control)
        {
            BaseGrid.Children.Remove(MainWindowGrid);
            //ControlPlaceHolder.Children.Clear();
            BaseGrid.Children.Add(control);
        }
    }
}
