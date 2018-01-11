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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for NannyFunctionality.xaml
    /// </summary>
    public partial class NannyFunctionality : Window
    {
        public NannyFunctionality()
        {
            InitializeComponent();
        }

        private void AddNanny_Click(object sender, RoutedEventArgs e)
        {
            new AddNannyWindow().Show();
        }

        private void DeleteNanny_Click(object sender, RoutedEventArgs e)
        {
            new DeleteNanny().Show();
        }

        private void UpdateNanny_Click(object sender, RoutedEventArgs e)
        {
            new UpdateNannyWindow().Show();
        }
    }
}
