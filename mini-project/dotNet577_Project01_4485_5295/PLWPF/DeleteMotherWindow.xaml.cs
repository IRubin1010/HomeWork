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
        List<Mother> motherList;
        public DeleteMotherWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            motherList = bl.CloneMotherList();
            list.DataContext = motherList;
            mother = new Mother();
            DeleteMother.DataContext = mother;
        }

        private void MotherSelected(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            mother = (Mother)comboBox.SelectedItem;
            DeleteMother.DataContext = mother;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(mother != null)
            {
                try
                {
                    bl.DeleteMother(mother);
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
