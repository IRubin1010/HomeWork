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
            // get mother list and bind to mother combobox
            motherList = bl.MotherWithChilrenWithNoNanny();
            motherComboBox.DataContext = motherList;
            // bind transection date to contract
            beginTransectionDatePicker.DataContext = contract;
            beginTransectionDatePicker.DisplayDateStart = DateTime.Now;
            endTransectionDatePicker.DataContext = contract;
            isMeetCheckBox.DataContext = contract;
            // intialize 2 background workers
            // for 2 functions that use thread
            worker = new BackgroundWorker();
            worker.DoWork += worker_Dowork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker2 = new BackgroundWorker();
            worker2.DoWork += worker2_Dowork;
            worker2.RunWorkerCompleted += worker2_RunWorkerCompleted;
            worker2.ProgressChanged += worker2_ProgressChanged;
            worker2.WorkerReportsProgress = true;
        }

        // worker complete thread event
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int i = 90; i <= 100; i += 10)
            {
                progressbar.Value = i;
            }
            progressbar.Visibility = Visibility.Hidden;
            nannyList = (List<Nanny>)e.Result;
            // bind data grid of nanny to nanny list nd make it visible
            Grouping.DataContext = nannyList;
            // bind nanny list to nanny combobox
            nannyComboBox.IsEnabled = true;
            nannyComboBox.DataContext = nannyList;
        }

        // worker thread event
        private void worker_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<object> objList = (List<object>)e.Argument;
                e.Result = bl.NannysInKMWithConditions((Mother)objList[0], (int?)objList[1], (int?)objList[2]);
                for (int i = 0; i < 80; i += 5)
                {
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //worker progress change evet
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            progressbar.Value = progress;
        }

        // worker2 complete thread event
        private void worker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int i = 90; i <= 100; i += 10)
            {
                progressbar.Value = i;
            }
            progressbar.Visibility = Visibility.Hidden;
            nannyList = (List<Nanny>)e.Result;
            // bind data grid of nanny to nanny list nd make it visible
            Grouping.DataContext = nannyList;
            // bind nanny list to nanny combobox
            nannyComboBox.IsEnabled = true;
            nannyComboBox.DataContext = nannyList;
        }

        // worker2 thread event
        private void worker2_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<object> objList = (List<object>)e.Argument;
                e.Result = bl.PartialMatch((Mother)objList[0], (int?)objList[1], (int?)objList[2]);
                for (int i = 0; i < 80; i += 5)
                {
                    System.Threading.Thread.Sleep(500);
                    worker2.ReportProgress(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //worker progress change evet
        private void worker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            progressbar.Value = progress;
        }

        // event when select mother
        private void MotherSelected(object sender, SelectionChangedEventArgs e)
        {
            mother = (Mother)(sender as ComboBox).SelectedItem;
            nannyComboBox.SelectedItem = null;
            nannyComboBox.IsEnabled = false;
            nanny = new Nanny();
            // bind payment to the new nanny
            // because in case that select another mother to cleen touse fields
            hourlyFeeTextBox.DataContext = nanny;
            monthlyFeeTextBox.DataContext = nanny;
            isPaymentByHourCheckBox.DataContext = nanny;
            if (mother != null)
            {
                // get mother children and bind to child combobox
                childList = bl.MotherChildren(mother).Where(child => child.HaveNanny == false).ToList();
                childComboBox.DataContext = childList;
                foreach (var item in RadioGrid.Children)
                {
                    RadioButton RB = item as RadioButton;
                    if (RB != null)
                    {
                        RB.IsChecked = false;
                    }
                }
                Grouping.DataContext = null;
            }
        }

        // event when select child
        private void ChildSelected(object sender, SelectionChangedEventArgs e)
        {
            child = (Child)(sender as ComboBox).SelectedItem;
            if (child != null)
            {
                foreach (var item in RadioGrid.Children)
                {
                    RadioButton RB = item as RadioButton;
                    if (RB != null)
                    {
                        if (RB.IsChecked == true)
                        {
                            RB.IsChecked = false;
                            RB.IsChecked = true;
                        }
                    }
                }
            }
        }

        // event when select manual selection
        private void ManualChecked(object sender, RoutedEventArgs e)
        {
            nannyComboBox.Text = "";
            nanny = new Nanny();
            // bind payment to the new nanny
            // because in case that select another mother to cleen touse fields
            hourlyFeeTextBox.DataContext = nanny;
            monthlyFeeTextBox.DataContext = nanny;
            isPaymentByHourCheckBox.DataContext = nanny;
            finalPaymentTextBox.Text = "";
            nannyList = null;
            // get nanny list and bind to nanny data grid and nanny combobox
            nannyComboBox.IsEnabled = true;
            nannyList = bl.CloneNannyList();
            NannyListGrid.Visibility = Visibility.Visible;
            Grouping.DataContext = nannyList;
            nannyComboBox.DataContext = nannyList;
        }

        // event when select hourly match selection
        private void HoursChecked(object sender, RoutedEventArgs e)
        {
            nannyComboBox.Text = "";
            nanny = new Nanny();
            // bind payment to the new nanny
            // because in case that select another mother to cleen touse fields
            hourlyFeeTextBox.DataContext = nanny;
            monthlyFeeTextBox.DataContext = nanny;
            isPaymentByHourCheckBox.DataContext = nanny;
            finalPaymentTextBox.Text = "";
            nannyList = null;
            // get hourly match nanny list, and bind to nanny data grid and nanny combobox
            nannyComboBox.IsEnabled = true;
            nannyList = bl.PotentialMatch(mother, child.ID);
            NannyListGrid.Visibility = Visibility.Visible;
            Grouping.DataContext = nannyList;
            nannyComboBox.DataContext = nannyList;
        }

        // event when select constraints match selection
        private void ConstraintsChecked(object sender, RoutedEventArgs e)
        {
            nannyComboBox.Text = "";
            nanny = new Nanny();
            // bind payment to the new nanny
            // because in case that select another mother to cleen touse fields
            hourlyFeeTextBox.DataContext = nanny;
            monthlyFeeTextBox.DataContext = nanny;
            isPaymentByHourCheckBox.DataContext = nanny;
            finalPaymentTextBox.Text = "";
            nannyList = null;
            // get constraints match nanny list, and bind to nanny data grid and nanny combobox
            nannyComboBox.IsEnabled = true;
            nannyList = bl.MotherConditions(mother, child.ID);
            NannyListGrid.Visibility = Visibility.Visible;
            Grouping.DataContext = nannyList;
            nannyComboBox.DataContext = nannyList;
        }

        // event when select distance match selection
        private void DistanceChecked(object sender, RoutedEventArgs e)
        {
            nannyComboBox.Text = "";
            nanny = new Nanny();
            // bind payment to the new nanny
            // because in case that select another mother to cleen touse fields
            hourlyFeeTextBox.DataContext = nanny;
            monthlyFeeTextBox.DataContext = nanny;
            isPaymentByHourCheckBox.DataContext = nanny;
            finalPaymentTextBox.Text = "";
            nannyList = null;
            List<object> objList = new List<object>();
            // if didn't get KM 
            if (KmTextBox.Text == "")
            {
                // send message box
                var result = MessageBox.Show("No kilometer selected, the default is 1 kilometer", "No kilometer selected", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    NannyListGrid.Visibility = Visibility.Visible;
                    // defalt distance is 1 KM
                    objList.Add(mother);
                    objList.Add(1);
                    objList.Add(child.ID);
                    // run thread
                    progressbar.Value = 0;
                    progressbar.Visibility = Visibility.Visible;
                    worker.RunWorkerAsync(objList);
                }
                else
                {
                    // need to select again
                    RButton4.IsChecked = false;
                }
            }
            // if get KM
            else
            {
                try
                {
                    NannyListGrid.Visibility = Visibility.Visible;
                    objList.Add(mother);
                    objList.Add(int.Parse(KmTextBox.Text));
                    objList.Add(child.ID);
                    // run thread
                    progressbar.Value = 0;
                    progressbar.Visibility = Visibility.Visible;
                    worker.RunWorkerAsync(objList);
                }
                // if was format exception of KM textbox
                catch (Exception)
                {
                    MessageBox.Show("KM was in a wrong format, please try again", "format exception", MessageBoxButton.OK, MessageBoxImage.Error);
                    RButton4.IsChecked = false;
                }
            }
        }

        // event when select 5 best match selection
        private void BestMatchChecked(object sender, RoutedEventArgs e)
        {
            nannyComboBox.Text = "";
            nanny = new Nanny();
            // bind payment to the new nanny
            // because in case that select another mother to cleen touse fields
            hourlyFeeTextBox.DataContext = nanny;
            monthlyFeeTextBox.DataContext = nanny;
            isPaymentByHourCheckBox.DataContext = nanny;
            finalPaymentTextBox.Text = "";
            nannyList = null;
            List<object> objList = new List<object>();
            // if didn't get KM
            if (KmTextBox.Text == "")
            {
                // send message box
                var result = MessageBox.Show("No kilometer selected, the default is 1 kilometer", "No kilometer selected", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    NannyListGrid.Visibility = Visibility.Visible;
                    // defalt distance is 1 KM
                    objList.Add(mother);
                    objList.Add(1);
                    objList.Add(child.ID);
                    // run thread
                    progressbar.Value = 0;
                    progressbar.Visibility = Visibility.Visible;
                    worker2.RunWorkerAsync(objList);
                }
                else
                {
                    // need to select again
                    RButton5.IsChecked = false;
                }
            }
            // get KM
            else
            {
                try
                {
                    NannyListGrid.Visibility = Visibility.Visible;
                    objList.Add(mother);
                    objList.Add(int.Parse(KmTextBox.Text));
                    objList.Add(child.ID);
                    // run thread
                    progressbar.Value = 0;
                    progressbar.Visibility = Visibility.Visible;
                    worker2.RunWorkerAsync(objList);
                }
                // if was format exception of KM textbox
                catch (Exception)
                {
                    MessageBox.Show("KM was in a wrong format, please try again", "format exception", MessageBoxButton.OK, MessageBoxImage.Error);
                    RButton5.IsChecked = false;
                }
            }
        }

        // event when select nanny
        private void NannySelected(object sender, SelectionChangedEventArgs e)
        {
            nanny = (Nanny)(sender as ComboBox).SelectedItem;
            if (nanny != null)
            {
                // bind payment fields to nanny
                // (payment depends on nanny payment Method)
                hourlyFeeTextBox.DataContext = nanny;
                monthlyFeeTextBox.DataContext = nanny;
                isPaymentByHourCheckBox.DataContext = nanny;
            }
        }

        // add contract click button event
        private void AddContract_Click(object sender, RoutedEventArgs e)
        {
            if (nanny != null && mother != null && child != null)
            {
                // get contract details
                contract.NannyID = nanny.ID;
                contract.HourlyFee = nanny.HourlyFee;
                contract.MonthlyFee = nanny.MonthlyFee;
                contract.IsPaymentByHour = nanny.IsHourlyFee;
                contract.MotherID = mother.ID;
                contract.ChildID = child.ID;
                try
                {
                    bl.AddContract(contract.Clone());
                    string message = "The contract was successfully added\n The contract number is: " + (bl.getContractNumber() - 1);
                    MessageBox.Show(message, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                catch (BLException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // calculate payment button clicl event
        private void CalculatePayment_Click(object sender, RoutedEventArgs e)
        {
            if (nanny != null && mother != null && child != null)
            {
                // get contract details
                contract.NannyID = nanny.ID;
                contract.HourlyFee = nanny.HourlyFee;
                contract.MonthlyFee = nanny.MonthlyFee;
                contract.IsPaymentByHour = nanny.IsHourlyFee;
                contract.MotherID = mother.ID;
                contract.ChildID = child.ID;
                try
                {
                    // calculate the final payment
                    bl.CalculatePayment(contract);
                    // update payment field in UI
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

        private void BeginDateSelected(object sender, SelectionChangedEventArgs e)
        {
            if (endTransectionDatePicker.SelectedDate < beginTransectionDatePicker.SelectedDate)
            {
                endTransectionDatePicker.BorderBrush = Brushes.Red;
                endTransectionDatePicker.ToolTip = "Selecd new date";
            }
            endTransectionDatePicker.SelectedDate = beginTransectionDatePicker.SelectedDate;
            endTransectionDatePicker.DisplayDateStart = beginTransectionDatePicker.SelectedDate;
        }

        private void EndDateSelected(object sender, SelectionChangedEventArgs e)
        {
            if (endTransectionDatePicker.SelectedDate > beginTransectionDatePicker.SelectedDate)
            {
                endTransectionDatePicker.BorderBrush = beginTransectionDatePicker.BorderBrush;
                endTransectionDatePicker.ToolTip = null;
            }
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            Nanny nanny = (Nanny)Grouping.SelectedItem;
            NannyDetails nannyWindow = new NannyDetails(bl, nanny);
            nannyWindow.Topmost = true;
            nannyWindow.Show();
        }
    }
}
