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
    /// Interaction logic for AddMotherWindow.xaml
    /// </summary>
    public partial class AddMotherWindow : Window
    {
        Mother mother;
        IBL bl;
        public AddMotherWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            mother = new Mother();
            MotherDetails.DataContext = mother;
        }

        private void AddMother_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddMother(mother);
                mother = new Mother();
                MotherDetails.DataContext = mother;
                Close();
            }
            catch (BLException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
