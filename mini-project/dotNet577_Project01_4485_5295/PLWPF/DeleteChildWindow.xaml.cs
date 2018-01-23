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
    /// Interaction logic for DeleteChildWindow.xaml
    /// </summary>
    public partial class DeleteChildWindow : Window
    {
        IBL bl;
        Child child;
        List<Child> childList;
        public DeleteChildWindow(IBL Bl)
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
                DeleteChild.DataContext = child;
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            if (list.Text == "")
            {
                child = new Child();
                DeleteChild.DataContext = child;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(child != null)
            {
                try
                {
                    bl.DeleteChild(child);
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
