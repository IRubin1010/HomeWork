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
        BackgroundWorker worker2;
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
            beginTransectionDatePicker.DisplayDateStart = DateTime.Now;
            endTransectionDatePicker.DataContext = contract;
            isMeetCheckBox.DataContext = contract;
            worker = new BackgroundWorker();
            worker.DoWork += worker_Dowork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker2 = new BackgroundWorker();
            worker2.DoWork += worker2_Dowork;
            worker2.RunWorkerCompleted += worker2_RunWorkerCompleted;
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

        private void worker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            nannyList = (List<Nanny>)e.Result;
            nannyComboBox.DataContext = nannyList;
        }

        private void worker2_Dowork(object sender, DoWorkEventArgs e)
        {
            List<object> objList = (List<object>)e.Argument;
            e.Result = bl.PartialMatch((Mother)objList[0], (int?)objList[1], (int?)objList[2]);
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
            if (KmTextBox.Text == "")
            {
                var result = MessageBox.Show("No kilometer selected, the default is 1 kilometer", "No kilometer selected", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    objList.Add(mother);
                    objList.Add(1);
                    objList.Add(child.ID);
                    worker.RunWorkerAsync(objList);
                }
                else
                {
                    RButton4.IsChecked = false;
                }
            }
            else
            {
                objList.Add(mother);
                objList.Add(int.Parse(KmTextBox.Text));
                objList.Add(child.ID);
                worker.RunWorkerAsync(objList);
            }
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
            List<object> objList = new List<object>();
            if (KmTextBox.Text == "")
            {
                var result = MessageBox.Show("No kilometer selected, the default is 1 kilometer", "No kilometer selected", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    objList.Add(mother);
                    objList.Add(1);
                    objList.Add(child.ID);
                    worker2.RunWorkerAsync(objList);
                }
                else
                {
                    RButton4.IsChecked = false;
                }
            }
            else
            {
                objList.Add(mother);
                objList.Add(int.Parse(KmTextBox.Text));
                objList.Add(child.ID);
                worker2.RunWorkerAsync(objList);
            }
        }

        private void BeginDateSelected(object sender, SelectionChangedEventArgs e)
        {
            if (endTransectionDatePicker.SelectedDate < beginTransectionDatePicker.SelectedDate)
            {
                endTransectionDatePicker.BorderBrush = Brushes.Red;
                endTransectionDatePicker.ToolTip = "Selecd new date";
            }
            endTransectionDatePicker.SelectedDate= beginTransectionDatePicker.SelectedDate; 
            endTransectionDatePicker.DisplayDateStart = beginTransectionDatePicker.SelectedDate;
        }

        private void EndDateSelected(object sender, SelectionChangedEventArgs e)
        {
            if (endTransectionDatePicker.SelectedDate > beginTransectionDatePicker.SelectedDate)
            {
                endTransectionDatePicker.BorderBrush = beginTransectionDatePicker.BorderBrush;
                endTransectionDatePicker.ToolTip =null;
            }
        }
    }
}
