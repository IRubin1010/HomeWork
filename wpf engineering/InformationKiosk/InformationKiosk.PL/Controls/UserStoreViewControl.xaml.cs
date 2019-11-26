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
    /// Interaction logic for UserStoreViewControl.xaml
    /// </summary>
    public partial class UserStoreViewControl : UserControl
    {
        public UserStoreViewControl(object param)
        {
            InitializeComponent();
            var store = param as Store;
            (DataContext as UserStoreViewViewModel).Store = store;
        }
    }
}
