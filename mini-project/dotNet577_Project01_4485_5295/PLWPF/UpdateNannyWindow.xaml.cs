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
    /// Interaction logic for UpdateNannyWindow.xaml
    /// </summary>
    public partial class UpdateNannyWindow : Window
    {
        IBL bl;
        Nanny nanny;
        List<int> maxAgeList;
        List<int> minAgeList;
        public UpdateNannyWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            nanny = new Nanny();
            // bind to nanny
            NannyToUpdate.DataContext = nanny;
            nannyAgeTextBox.Text = "";
            // intialize min age list and bind to min age combobox
            minAgeList = new List<int>() { 0, 6, 12, 18, 24, 30 };
            maxAgeList = new List<int>() { 6, 12, 18, 24, 30, 36 };
        }

        // nanny selected event
        private void SelectNanny(object sender, EventArgs e)
        {
            if (list.Text != null)
            {
                // get nanny
                nanny = bl.CloneNannyList().FirstOrDefault(nanny => nanny.ToString() == list.Text);
                // bind to nanny
                NannyToUpdate.DataContext = nanny;
                addressTextBox.Text = nanny.Address;
                minAgeTextBox.DataContext = minAgeList;
                if (nanny.MinAge != null && nanny.MinAge != null)
                {
                    minAgeTextBox.SelectedIndex = minAgeList.IndexOf((int)nanny.MinAge);
                    maxAgeTextBox.SelectedIndex = maxAgeList.IndexOf((int)nanny.MaxAge);
                }
            }
        }

        // text changed event
        private void textChanged(object sender, EventArgs e)
        {
            if (list.Text == "")
            {
                nanny = new Nanny();
                // bind to nanny
                NannyToUpdate.DataContext = nanny;
                addressTextBox.Text = nanny.Address;
            }

        }

        // event when select min age
        private void MinAgeSelected(object sender, SelectionChangedEventArgs e)
        {
            maxAgeTextBox.SelectedIndex = -1;
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

        // max age selected event
        private void MaxAgeSelected(object sender, SelectionChangedEventArgs e)
        {
            // get the min and max age
            if (minAgeTextBox.SelectedValue != null && maxAgeTextBox.SelectedValue != null)
            {
                int minage, maxage;
                int.TryParse(minAgeTextBox.SelectedValue.ToString(), out minage);
                int.TryParse(maxAgeTextBox.SelectedValue.ToString(), out maxage);
                nanny.MinAge = minage;
                nanny.MaxAge = maxage;
            }
        }

        // work days and hours button click event
        private void WorkDaysHours(object sender, RoutedEventArgs e)
        {
            // open new window to select days and hours
            new NannyWorkDaysHours(nanny).Show();
        }

        // update button click event
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (nanny != null)
            {
                try
                {
                    // get the address
                    nanny.Address = addressTextBox.Text;
                    bl.UpdateNanny(nanny);
                    Close();
                }
                catch (BLException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("ther is no such nanny", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
