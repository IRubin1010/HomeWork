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
    /// Interaction logic for SearchContract.xaml
    /// </summary>
    public partial class SearchContract : Page
    {
        IBL bl;
        Contract contract;
        List<Contract> contractList;
        public SearchContract(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            contract = new Contract();
            contractList = bl.CloneContractList();
            list.DataContext = contractList;
        }

        private void ContractSelected(object sender, SelectionChangedEventArgs e)
        {
            contract = (Contract)(sender as ComboBox).SelectedItem;
            searchContract.DataContext = contract;
        }
    }
}
