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
    /// Interaction logic for GroupByAge.xaml
    /// </summary>
    public partial class GroupByAge : Window
    {
        IBL bl;
        public GroupByAge(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
        }

        // max age selected event
        private void MaxAgeChecked(object sender, RoutedEventArgs e)
        {
            Grouping.DataContext = bl.GruopNannyByChildAge(true, false);
        }

        // min age selected event
        private void MinAgeChecked(object sender, RoutedEventArgs e)
        {
            Grouping.DataContext = bl.GruopNannyByChildAge(false, false);
        }

        // sort button click event
        private void Sort_CLick(object sender, RoutedEventArgs e)
        {
            Grouping.DataContext = bl.GruopNannyByChildAge((bool)MaxAge.IsChecked, true);
        }

    }
}
