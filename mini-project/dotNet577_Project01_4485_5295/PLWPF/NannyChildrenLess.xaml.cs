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
    /// Interaction logic for NannyChildrenLess.xaml
    /// </summary>
    public partial class NannyChildrenLess : Page
    {
        IBL bl;
        public NannyChildrenLess(IBL Bl, int num)
        {
            InitializeComponent();
            bl = Bl;
            // bind data grid to nanny with childen less than list
            Grouping.DataContext = bl.NannyWitheChildrenLessThen(num);
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            Nanny nanny = (Nanny)Grouping.SelectedItem;
            NannyDetails nannyWindow = new NannyDetails(bl, nanny);
            nannyWindow.Topmost = true;
            nannyWindow.Show();
        }
    }
}
