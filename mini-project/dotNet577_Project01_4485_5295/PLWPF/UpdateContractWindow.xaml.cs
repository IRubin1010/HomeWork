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
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateContractWindow.xaml
    /// </summary>
    public partial class UpdateContractWindow : Window
    {
        IBL bl;
        Contract contract;
        public UpdateContractWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            contract = new Contract();
            UpdateContract.DataContext = contract;
            endTransectionDatePicker.DataContext = contract;
        }

        private void SelectContract(object sender, EventArgs e)
        {
            if (list.Text != null)
            {
                contract = bl.CloneContractList().FirstOrDefault(contract => contract.ToString() == list.Text);
                UpdateContract.DataContext = contract;
                endTransectionDatePicker.DataContext = contract;
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            if (list.Text == "")
            {
                contract = new Contract();
                UpdateContract.DataContext = contract;
                endTransectionDatePicker.DataContext = contract;
            }
        }

        private void DeleteContract_Click(object sender, RoutedEventArgs e)
        {
            if (contract != null)
            {
                try
                {
                    bl.UpdateContract(contract);
                    Close();
                }
                catch (BLException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
