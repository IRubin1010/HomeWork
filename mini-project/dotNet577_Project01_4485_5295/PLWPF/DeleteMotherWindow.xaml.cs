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
    /// Interaction logic for DeleteMotherWindow.xaml
    /// </summary>
    public partial class DeleteMotherWindow : Window
    {
        IBL bl;
        Mother mother;
        public DeleteMotherWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
        }

        // event when select mother
        private void SelectMother(object sender, EventArgs e)
        {
            if (list.Text != null)
            {
                // get the mother and bind to all fields
                mother = bl.CloneMotherList().FirstOrDefault(mother => mother.ToString() == list.Text);
                DeleteMother.DataContext = mother;
                addressTextBox.Text = mother.Address;
            }
        }

        // event when text changed in search control
        private void textChanged(object sender, EventArgs e)
        {
            // if text is enpty
            // clear all fields
            if (list.Text == "")
            {
                mother = new Mother();
                DeleteMother.DataContext = mother;
                addressTextBox.Text = mother.Address;
            }
        }

        // delete mother button click event
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(mother != null)
            {
                try
                {
                    bl.DeleteMother(mother.Clone());
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
