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
    /// Interaction logic for AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        IBL bl;
        Nanny nanny;
        Mother mother;
        Child child;
        Contract contract;
        List<Nanny> nannyList;
        List<Mother> motherList;
        List<Child> childList;
        public AddContractWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            nanny = new Nanny();
            mother = new Mother();
            child = new Child();
            contract = new Contract();
            nannyList = bl.CloneNannyList();
            nannyComboBox.DataContext = nannyList;
            motherList = bl.CloneMotherList();
            motherComboBox.DataContext = motherList;
            beginTransectionDatePicker.DataContext = contract;
            endTransectionDatePicker.DataContext = contract;
            isMeetCheckBox.DataContext = contract;
        }

        private void NannySelected(object sender, SelectionChangedEventArgs e)
        {
            nanny = (Nanny)(sender as ComboBox).SelectedItem;
            hourlyFeeTextBox.DataContext = nanny;
            monthlyFeeTextBox.DataContext = nanny;
            isPaymentByHourCheckBox.DataContext = nanny;

            contract.NannyID = nanny.ID;
            contract.HourlyFee = nanny.HourlyFee;
            contract.MonthlyFee = nanny.MonthlyFee;
            contract.IsPaymentByHour = nanny.IsHourlyFee;
        }

        private void MotherSelected(object sender, SelectionChangedEventArgs e)
        {
            mother = (Mother)(sender as ComboBox).SelectedItem;
            childList = bl.MotherChildren(mother);
            childComboBox.DataContext = childList;

            contract.MotherID = mother.ID;
        }

        private void ChildSelected(object sender, SelectionChangedEventArgs e)
        {
            child = (Child)(sender as ComboBox).SelectedItem;
            contract.ChildID = child.ID;
        }

        private void AddContract_Click(object sender, RoutedEventArgs e)
        {
            if (nanny != null && mother != null && child != null)
            {
                Console.WriteLine(contract);
                try
                {
                    bl.AddContract(contract);
                    Close();
                }
                catch (BLException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CalculatePayment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.CalculatePayment(contract);
                finalPaymentTextBox.DataContext = contract;
            }
            catch (BLException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
