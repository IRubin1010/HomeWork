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
        List<Nanny> nannyList;
        public UpdateNannyWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            nannyList = bl.CloneNannyList();
            list.DataContext = nannyList;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (nanny != null)
            {
                try
                {
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

        private void WorkDaysHours(object sender, RoutedEventArgs e)
        {
            new NannyWorkDaysHours(nanny).Show();
        }

        private void NannySelected(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            nanny = (Nanny)comboBox.SelectedItem;
            NannyToUpdate.DataContext = nanny;
            addressTextBox.Text = nanny.Address;
        }

    }
}
