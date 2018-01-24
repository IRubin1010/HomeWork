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
using System.Threading;
using System.ComponentModel;
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
        BackgroundWorker worker;
        public AddContractWindow(IBL BL)
        {
            InitializeComponent();
            bl = BL;
            nanny = new Nanny();
            mother = new Mother();
            child = new Child();
            contract = new Contract();
            motherList = bl.CloneMotherList();
            motherComboBox.DataContext = motherList;
            beginTransectionDatePicker.DataContext = contract;
            endTransectionDatePicker.DataContext = contract;
            isMeetCheckBox.DataContext = contract;
            worker = new BackgroundWorker();
            worker.DoWork += worker_Dowork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            nannyList = (List<Nanny>)e.Result;
            nannyComboBox.DataContext = nannyList;
        }

        private void worker_Dowork(object sender, DoWorkEventArgs e)
        {
            List<object> objList = (List<object>)e.Argument;
            e.Result = bl.NannysInKMWithConditions((Mother)objList[0], (int?)objList[1], (int?)objList[2]);
        }

        private void NannySelected(object sender, SelectionChangedEventArgs e)
        {
            nanny = (Nanny)(sender as ComboBox).SelectedItem;
            hourlyFeeTextBox.DataContext = nanny;
            monthlyFeeTextBox.DataContext = nanny;
            isPaymentByHourCheckBox.DataContext = nanny;


        }

        private void MotherSelected(object sender, SelectionChangedEventArgs e)
        {
            mother = (Mother)(sender as ComboBox).SelectedItem;
            childList = bl.MotherChildren(mother);
            childComboBox.DataContext = childList;
        }

        private void ChildSelected(object sender, SelectionChangedEventArgs e)
        {
            child = (Child)(sender as ComboBox).SelectedItem;

        }

        private void AddContract_Click(object sender, RoutedEventArgs e)
        {
            if (nanny != null && mother != null && child != null)
            {
                contract.NannyID = nanny.ID;
                contract.HourlyFee = nanny.HourlyFee;
                contract.MonthlyFee = nanny.MonthlyFee;
                contract.IsPaymentByHour = nanny.IsHourlyFee;
                contract.MotherID = mother.ID;
                contract.ChildID = child.ID;
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
            if (nanny != null && mother != null && child != null)
            {
                contract.NannyID = nanny.ID;
                contract.HourlyFee = nanny.HourlyFee;
                contract.MonthlyFee = nanny.MonthlyFee;
                contract.IsPaymentByHour = nanny.IsHourlyFee;
                contract.MotherID = mother.ID;
                contract.ChildID = child.ID;
                try
                {
                    bl.CalculatePayment(contract);
                    BindingExpression be = finalPaymentTextBox.GetBindingExpression(TextBox.TextProperty);
                    finalPaymentTextBox.Text = contract.FinalPayment.ToString();
                    be.UpdateSource();
                }
                catch (BLException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ManualChecked(object sender, RoutedEventArgs e)
        {
            nannyComboBox.Text = "";
            nanny = new Nanny();
            hourlyFeeTextBox.DataContext = nanny;
            monthlyFeeTextBox.DataContext = nanny;
            isPaymentByHourCheckBox.DataContext = nanny;
            finalPaymentTextBox.Text = "";
            nannyList = null;
            nannyList = bl.CloneNannyList();
            nannyComboBox.DataContext = nannyList;
        }

        private void HoursChecked(object sender, RoutedEventArgs e)
        {
            nannyComboBox.Text = "";
            nanny = new Nanny();
            hourlyFeeTextBox.DataContext = nanny;
            monthlyFeeTextBox.DataContext = nanny;
            isPaymentByHourCheckBox.DataContext = nanny;
            finalPaymentTextBox.Text = "";
            nannyList = null;
            nannyList = bl.PotentialMatch(mother, child.ID);
            nannyComboBox.DataContext = nannyList;
        }

        private void ConstraintsChecked(object sender, RoutedEventArgs e)
        {
            nannyComboBox.Text = "";
            nanny = new Nanny();
            hourlyFeeTextBox.DataContext = nanny;
            monthlyFeeTextBox.DataContext = nanny;
            isPaymentByHourCheckBox.DataContext = nanny;
            finalPaymentTextBox.Text = "";
            nannyList = null;
            nannyList = bl.MotherConditions(mother, child.ID);
            nannyComboBox.DataContext = nannyList;
        }

        private void DistanceChecked(object sender, RoutedEventArgs e)
        {
            nannyComboBox.Text = "";
            nanny = new Nanny();
            hourlyFeeTextBox.DataContext = nanny;
            monthlyFeeTextBox.DataContext = nanny;
            isPaymentByHourCheckBox.DataContext = nanny;
            finalPaymentTextBox.Text = "";
            nannyList = null;
            List<object> objList = new List<object>();
            objList.Add(mother);
            objList.Add(5000);
            objList.Add(child.ID);
            worker.RunWorkerAsync(objList);
            //nannyList = bl.NannysInKMWithConditions(mother, 5, child.ID);//////////////////////
            //nannyComboBox.DataContext = nannyList;
        }

        private void BestMatchChecked(object sender, RoutedEventArgs e)
        {
            nannyComboBox.Text = "";
            nanny = new Nanny();
            hourlyFeeTextBox.DataContext = nanny;
            monthlyFeeTextBox.DataContext = nanny;
            isPaymentByHourCheckBox.DataContext = nanny;
            finalPaymentTextBox.Text = "";
            nannyList = null;
            nannyList = bl.PartialMatch(mother, 5, child.ID);/////////////////////////////////
            nannyComboBox.DataContext = nannyList;
        }
    }
}
