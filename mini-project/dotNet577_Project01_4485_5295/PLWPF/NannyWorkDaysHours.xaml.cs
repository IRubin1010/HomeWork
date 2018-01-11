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
    /// Interaction logic for NannyWorkDaysHours.xaml
    /// </summary>
    public partial class NannyWorkDaysHours : Window
    {
        Nanny Nanny;
        public NannyWorkDaysHours(Nanny nanny)
        {
            InitializeComponent();
            Nanny = nanny;
            WorkDaysHours.DataContext = Nanny;
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(Nanny.WorkHours[0][0]);
            Console.WriteLine(Nanny.WorkHours[0][1]);
            Console.WriteLine(Nanny.WorkHours[1][0]);
            Console.WriteLine(Nanny.WorkHours[0][3]);
            Console.WriteLine(Nanny.WorkHours[1][3]);
            Console.WriteLine(Nanny.IsWork[0]);
            Console.WriteLine(Nanny.IsWork[1]);
            Close();
        }
    }
}
