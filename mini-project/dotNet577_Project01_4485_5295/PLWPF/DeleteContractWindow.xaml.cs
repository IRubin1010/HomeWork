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
    /// Interaction logic for DeleteContractWindow.xaml
    /// </summary>
    public partial class DeleteContractWindow : Window
    {
        IBL bl;
        Contract contract;
        public DeleteContractWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            contract = new Contract();
        }

        // event when select contract
        private void SelectContract(object sender, EventArgs e)
        {
            if (list.Text != null)
            {
                // get the contratc and bind to all fields
                contract = bl.CloneContractList().FirstOrDefault(contract => contract.ToString() == list.Text);
                DeleteContract.DataContext = contract;
            }
        }

        // event when text changed in search control
        private void textChanged(object sender, EventArgs e)
        {
            // if text is enpty
            // clear all fields
            if (list.Text == "")
            {
                contract = new Contract();
                DeleteContract.DataContext = contract;
            }
        }

        // delete contract button click event
        private void DeleteContract_Click(object sender, RoutedEventArgs e)
        {
            if (contract != null)
            {
                try
                {
                    bl.DeleteContract(contract.Clone());
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
