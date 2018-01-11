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
        Nanny nanny;
        IBL bl;
        public UpdateNannyWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int id = int.Parse(IDtextbox.Text);
            nanny = bl.FindNanny(id);
            if (nanny != null)
            {
                new UpdateNannyDetailsWindow(nanny).Show();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (nanny != null)
            {
                try
                {
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
