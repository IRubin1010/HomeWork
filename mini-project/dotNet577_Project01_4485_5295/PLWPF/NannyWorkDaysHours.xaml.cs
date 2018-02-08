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

        public enum days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday };
        // submit button click event 
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            string messge = null;
            for(int i = 0; i < 6; i++)
                if (Nanny.IsWork[i] && Nanny.WorkHours[0][i] > Nanny.WorkHours[1][i])
                    messge += "start time can't be later then end time at day " + ((days)i).ToString() + "\n";
            if (messge!=null)
                MessageBox.Show(messge, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            Close();
        }
    }
}
