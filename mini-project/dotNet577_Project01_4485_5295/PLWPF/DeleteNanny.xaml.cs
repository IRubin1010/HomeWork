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
        string name;
        public DeleteNanny()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();  
            Name.DataContext = this;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int id = int.Parse(IDtextbox.Text);
            nanny = bl.FindNanny(id);
            if (nanny != null)
            {
                name = nanny.FullName();
                BindingExpression be = Nametextblock.GetBindingExpression(TextBlock.TextProperty);
                Nametextblock.Text = name;
                be.UpdateSource();
            }
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
    }
}
