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
        public DeleteChildWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
        }

        // event when select child
        private void SelectChild(object sender, EventArgs e)
        {
            if (list.Text != null)
            {
                // get the child and bind to all fields
                child = bl.CloneChildList().FirstOrDefault(child => child.ToString() == list.Text);
                DeleteChild.DataContext = child;
            }
        }

        // event when text changed in search control
        private void textChanged(object sender, EventArgs e)
        {
            // if text is enpty
            // clear all fields
            if (list.Text == "")
            {
                child = new Child();
                DeleteChild.DataContext = child;
            }
        }

        // delete child button click event
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(child != null)
            {
                try
                {
                    bl.DeleteChild(child.Clone());
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
