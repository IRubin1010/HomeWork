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
    /// Interaction logic for SearchNanny.xaml
    /// </summary>
    public partial class SearchNanny : Page
    {
        IBL bl;
        Nanny nanny;
        List<Nanny> nannyList;
        public SearchNanny()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            nannyList = bl.CloneNannyList();
            list.DataContext = nannyList;
        }

        private void NannySelected(object sender, SelectionChangedEventArgs e)
        {
            nanny = (Nanny)(sender as ComboBox).SelectedItem;
            searchNanny.DataContext = nanny;
        }
    }
}
