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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddNannyWindow.xaml
    /// </summary>
    public partial class AddNannyWindow : Window
    {
        IBL bl;
        Nanny nanny;
        List<int> maxAgeList;
        List<int> minAgeList;
        public AddNannyWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            nanny = new Nanny();
            // bind nanny
            NannyDeatails.DataContext = nanny;
            nannyAgeTextBox.Text = "";
            DateTime dateTime = DateTime.Now.AddYears(-18);
            birthDateDatePicker.DisplayDateEnd = dateTime;

            // intialize min age list and bind to min age combobox
            minAgeList = new List<int>() { 0, 6, 12, 18, 24, 30 };
            minAgeTextBox.DataContext = minAgeList;
        }

        // work days and hours button click event
        private void WorkDaysHours_Click(object sender, RoutedEventArgs e)
        {
            // open new window to select days and hours
            new NannyWorkDaysHours(nanny).Show();
        }

        // date selected event
        private void DateSelected(object sender, SelectionChangedEventArgs e)
        {
            if (nanny.NannyAge != 0)
            {
                // update nanny age field in UI
                BindingExpression be = nannyAgeTextBox.GetBindingExpression(TextBox.TextProperty);
                nannyAgeTextBox.Text = nanny.NannyAge.ToString();
                be.UpdateSource();
            }
        }

        // v=event when select min age
        private void MinAgeSelected(object sender, SelectionChangedEventArgs e)
        {
            // get min age selection
            int minAge = int.Parse(minAgeTextBox.SelectedValue.ToString());
            // for each min age selction retrun customized list for max age
            switch (minAge)
            {
                case 0:
                    maxAgeList = new List<int>() { 6, 12, 18, 24, 30, 36 };
                    maxAgeTextBox.DataContext = maxAgeList;
                    break;
                case 6:
                    maxAgeList = new List<int>() { 12, 18, 24, 30, 36 };
                    maxAgeTextBox.DataContext = maxAgeList;
                    break;
                case 12:
                    maxAgeList = new List<int>() { 18, 24, 30, 36 };
                    maxAgeTextBox.DataContext = maxAgeList;
                    break;
                case 18:
                    maxAgeList = new List<int>() { 24, 30, 36 };
                    maxAgeTextBox.DataContext = maxAgeList;
                    break;
                case 24:
                    maxAgeList = new List<int>() { 30, 36 };
                    maxAgeTextBox.DataContext = maxAgeList;
                    break;
                case 30:
                    maxAgeList = new List<int>() { 36 };
                    maxAgeTextBox.DataContext = maxAgeList;
                    break;
                default:
                    break;
            }
        }

        // submit button click event
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // get the address
                nanny.Address = addressTextBox.Text;
                bl.AddNanny(nanny.Clone());
                nanny = new Nanny();
                NannyDeatails.DataContext = nanny;
                Close();
            }
            catch (BLException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}



//BindingExpression be = iDTextBox.GetBindingExpression(TextBox.TextProperty);
//iDTextBox.Text = nanny.ID.ToString();
//                be.UpdateSource();
