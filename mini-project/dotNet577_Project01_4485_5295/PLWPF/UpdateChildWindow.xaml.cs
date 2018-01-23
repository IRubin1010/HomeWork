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
    /// Interaction logic for UpdateChildWindow.xaml
    /// </summary>
    public partial class UpdateChildWindow : Window
    {
        IBL bl;
        Child child;
        List<Child> childList;
        public UpdateChildWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            childList = bl.CloneChildList();
            list.DataContext = childList;
        }

        private void SelectChild(object sender, EventArgs e)
        {
            if (list.Text != null)
            {
                child = bl.CloneChildList().FirstOrDefault(child => child.ToString() == list.Text);
                UpdateChild.DataContext = child;
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            if (list.Text == "")
            {
                child = new Child();
                UpdateChild.DataContext = child;
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if(child != null)
            {
                try
                {
                    bl.UpdateChild(child);
                    Close();
                }
                catch (BLException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
