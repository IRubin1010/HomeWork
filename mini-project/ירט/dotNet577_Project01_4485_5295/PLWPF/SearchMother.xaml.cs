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
    /// Interaction logic for SearchMother.xaml
    /// </summary>
    public partial class SearchMother : Page
    {
        IBL bl;
        Mother mother;
        List<Mother> motherList;
        public SearchMother(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            motherList = bl.CloneMotherList();
            list.DataContext = motherList;
        }

        private void MotherSelected(object sender, SelectionChangedEventArgs e)
        {
            mother = (Mother)(sender as ComboBox).SelectedItem;
            searchMother.DataContext = mother;
        }
    }
}
