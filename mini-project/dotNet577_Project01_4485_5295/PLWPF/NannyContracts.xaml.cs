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
    /// Interaction logic for NannyContracts.xaml
    /// </summary>
    public partial class NannyContracts : Page
    {
        IBL bl;
        public NannyContracts(IBL Bl, Nanny nanny)
        {
            InitializeComponent();
            bl = Bl;
            // bind data grid to nanny contracts list
            Grouping.DataContext = bl.NannyContracts(nanny);
        }

        private new void MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("click");
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            Contract contract = (Contract)Grouping.SelectedItem;
            ContractDetails contracWindow = new ContractDetails(bl, contract);
            contracWindow.Topmost = true;
            contracWindow.Show();
        }
    }
}
