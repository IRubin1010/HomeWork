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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ChildrenWithNoNanny.xaml
    /// </summary>
    public partial class ChildrenWithNoNanny : Page
    {
        IBL bl;
        public ChildrenWithNoNanny(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            // bind child data grid
            Grouping.DataContext = bl.ChildrenWithNoNanny();
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            Child child = (Child)Grouping.SelectedItem;
            ChildDetails childWindow = new ChildDetails(bl, child);
            childWindow.Topmost = true;
            childWindow.Show();
        }
    }
}
