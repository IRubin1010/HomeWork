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
    /// Interaction logic for Contracts.xaml
    /// </summary>
    public partial class Contracts : Page
    {
        IBL bl;
        public Contracts(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            Grouping.DataContext = bl.CloneContractList();
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            Contract contract = (Contract)Grouping.SelectedItem;
            SearchWindow wnd = (SearchWindow)Window.GetWindow(this);
            wnd.selectedAction.Content = new SearchContract(bl, contract);
        }
    }
}
