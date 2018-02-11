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
    /// Interaction logic for Mothers.xaml
    /// </summary>
    public partial class Mothers : Page
    {
        IBL bl;
        public Mothers(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            Grouping.DataContext = bl.CloneMotherList();
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            Mother mother = (Mother)Grouping.SelectedItem;
            SearchWindow wnd = (SearchWindow)Window.GetWindow(this);
            wnd.selectedAction.Content = new SearchMother(bl, mother);
        }
    }
}
