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
        public AddNannyWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            nanny = new Nanny();
            NannyDeatails.DataContext = nanny;
            nannyAgeTextBox.Text = "";
            DateTime dateTime = DateTime.Now.AddYears(-18);
            birthDateDatePicker.DisplayDateEnd = dateTime;
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nanny.Address = addressTextBox.Text;
                Console.WriteLine(nanny.Address);
                Console.WriteLine(nanny);
                bl.AddNanny(nanny);
                nanny = bl.FindNanny(nanny.ID);
                Console.WriteLine(nanny);
                nanny = new Nanny();
                NannyDeatails.DataContext = nanny;
                Close();
            }
            catch (BLException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WorkDaysHours_Click(object sender, RoutedEventArgs e)
        {
            new NannyWorkDaysHours(nanny).Show();
        }

        private void DateSelected(object sender, SelectionChangedEventArgs e)
        {
            if (nanny.NannyAge != 0)
            {
                BindingExpression be = nannyAgeTextBox.GetBindingExpression(TextBox.TextProperty);
                nannyAgeTextBox.Text = nanny.NannyAge.ToString();
                be.UpdateSource();
            }
        }
    }
}






//BindingExpression be = iDTextBox.GetBindingExpression(TextBox.TextProperty);
//iDTextBox.Text = nanny.ID.ToString();
//                be.UpdateSource();
