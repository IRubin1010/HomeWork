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
    /// Interaction logic for DeleteNanny.xaml
    /// </summary>
    public partial class DeleteNanny : Window
    {
        IBL bl;
        Nanny nanny;
        List<Nanny> nannyList;
        public DeleteNanny(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            nannyList = bl.CloneNannyList();
            list.DataContext = nannyList;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (nanny != null)
            {
                try
                {
                    bl.DeleteNanny(nanny);
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

        private void SelectNanny(object sender, EventArgs e)
        {
            if (list.Text != null)
            {
                nanny = bl.CloneNannyList().FirstOrDefault(nanny => nanny.ToString() == list.Text);
                NannyToDelete.DataContext = nanny;
                addressTextBox.Text = nanny.Address;
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            if (list.Text == "")
            {
                nanny = new Nanny();
                NannyToDelete.DataContext = nanny;
                addressTextBox.Text = nanny.Address;
            }
        }

        private void WorkDaysHours(object sender, RoutedEventArgs e)
        {
            new NannyWorkDaysHoursDelete(nanny).Show();
        }
    }
}
