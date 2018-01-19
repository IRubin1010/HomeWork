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
    /// Interaction logic for UpdateMotherWindow.xaml
    /// </summary>
    public partial class UpdateMotherWindow : Window
    {
        IBL bl;
        Mother mother;
        List<Mother> motherList;
        public UpdateMotherWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            motherList = bl.CloneMotherList();
            list.DataContext = motherList;
            mother = new Mother();
            UpdateMother.DataContext = mother;
        }

        private void MotherSelected(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            mother = (Mother)comboBox.SelectedItem;
            UpdateMother.DataContext = mother;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if(mother != null)
            {
                try
                {
                    bl.UpdateMother(mother);
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
