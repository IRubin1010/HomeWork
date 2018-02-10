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
        public DeleteNanny(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
        }

        // event when select nanny
        private void SelectNanny(object sender, EventArgs e)
        {
            if (list.Text != null)
            {
                // get the nanny and bind to all fields
                nanny = bl.CloneNannyList().FirstOrDefault(nanny => nanny.ToString() == list.Text);
                NannyToDelete.DataContext = nanny;
                addressTextBox.Text = nanny.Address;
            }
        }

        // event when text changed in search control
        private void textChanged(object sender, EventArgs e)
        {
            // if text is enpty
            // clear all fields
            if (list.Text == "")
            {
                nanny = new Nanny();
                NannyToDelete.DataContext = nanny;
                addressTextBox.Text = nanny.Address;
            }
        }

        // work days and hours button clcick event
        private void WorkDaysHours(object sender, RoutedEventArgs e)
        {
            // send to another winndow to see the work days and hours
            new NannyWorkDaysHoursDelete(nanny).ShowDialog();
        }

        // delete nanny button click event
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (nanny != null)
            {
                try
                {
                    bl.DeleteNanny(nanny.Clone());
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
