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
        IEnumerable<IGrouping<int?,Nanny>> groupingList;
        public GroupByAge(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
        }

        private void MaxAgeChecked(object sender, RoutedEventArgs e)
        {
            groupingList = bl.GruopNannyByChildAge(true, false);
            Grouping.DataContext = groupingList;
        }

        private void MinAgeChecked(object sender, RoutedEventArgs e)
        {
            groupingList = bl.GruopNannyByChildAge(false, false);
            Grouping.DataContext = groupingList;
        }

        private void Sort_CLick(object sender, RoutedEventArgs e)
        {
            groupingList = bl.GruopNannyByChildAge((bool)MaxAge.IsChecked, true);
            Grouping.DataContext = groupingList;
        }
    }
}
