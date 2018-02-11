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
    /// Interaction logic for Nannies.xaml
    /// </summary>
    public partial class Nannies : Page
    {
        IBL bl;
        public Nannies(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            Grouping.DataContext = bl.CloneNannyList();
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            Nanny nanny = (Nanny)Grouping.SelectedItem;
            SearchWindow wnd = (SearchWindow)Window.GetWindow(this);
            wnd.selectedAction.Content = new SearchNanny(bl, nanny);
        }
    }
}
