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
using System.ComponentModel;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GroupByDistance.xaml
    /// </summary>
    public partial class GroupByDistance : Window
    {
        IBL bl;
        IEnumerable<IGrouping<int?, Contract>> groupingList;
        BackgroundWorker Worker;
        public GroupByDistance(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            Worker = new BackgroundWorker();
            Worker.DoWork += Worker_Dowork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            Worker.RunWorkerAsync(false);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            groupingList = (IEnumerable<IGrouping<int?, Contract>>)e.Result;
            Grouping.DataContext = groupingList;
        }

        private void Worker_Dowork(object sender, DoWorkEventArgs e)
        {
            bool order = (bool)e.Argument;
            e.Result = bl.GroupContractByDistance(order);
        }

        private void Sort_CLick(object sender, RoutedEventArgs e)
        {
            Worker.RunWorkerAsync(true);
        }
    }
}
