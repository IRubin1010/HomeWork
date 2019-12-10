using InformationKiosk.BE;
using InformationKiosk.PL.ViewModels;
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
    /// Interaction logic for UserIceCreamViewControl.xaml
    /// </summary>
    public partial class UserIceCreamViewControl : UserControl
    {
        public UserIceCreamViewControl(object param)
        {
            InitializeComponent();
            var store = param as IceCream;
            (DataContext as UserIceCreamViewViewModel).IceCream = store;
        }


    }
}
