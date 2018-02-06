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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for NannyWorkDaysHours.xaml
    /// </summary>
    public partial class NannyWorkDaysHours : Window
    {
        Nanny Nanny;
        public NannyWorkDaysHours(Nanny nanny)
        {
            InitializeComponent();
            if (nanny != null)
                Nanny = nanny;
            else   // nanny is null 
                Nanny = new Nanny();
            // bind to nanny
            WorkDaysHours.DataContext = Nanny;
        }

        // submit button click event 
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
