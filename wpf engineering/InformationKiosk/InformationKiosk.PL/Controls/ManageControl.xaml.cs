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

namespace InformationKiosk.PL.Controls
{
    /// <summary>
    /// Interaction logic for Manage.xaml
    /// </summary>
    public partial class ManageControl : UserControl, INevigator
    {
        public ManageControl()
        {
            InitializeComponent();
            NevigatorCommand nevigatorCommand = Resources["NevigatorCommand"] as NevigatorCommand;
            nevigatorCommand.Nevigator = this;
        }

        public void NevigateTo(UserControl control)
        {
            if(control.Name == "UserView")
            {
                var mainWindow = (MainWindow)Window.GetWindow(this);
                mainWindow.BaseGrid.Children.Clear();
                mainWindow.BaseGrid.Children.Add(control);
            }
            else
            {
                ControlPlaceHolder.Children.Clear();
                ControlPlaceHolder.Children.Add(control);
            }
        }
    }
}
