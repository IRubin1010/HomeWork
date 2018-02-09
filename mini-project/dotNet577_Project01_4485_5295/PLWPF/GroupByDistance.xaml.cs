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
        BackgroundWorker Worker;
        public GroupByDistance(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            // intialzie background worker
            Worker = new BackgroundWorker();
            Worker.DoWork += Worker_Dowork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            Worker.RunWorkerAsync(false);
            Worker.ProgressChanged += Worker_ProgressChanged;
            Worker.WorkerReportsProgress = true;
        }

        // worker complete thread event
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int i = 90; i <= 100; i+=10)
            {
                progressBarButton.Value = i;
            }
            Grouping.DataContext = (IEnumerable<IGrouping<int?, Contract>>)e.Result;
        }

        // worker thread event
        private void Worker_Dowork(object sender, DoWorkEventArgs e)
        {
            bool order = (bool)e.Argument;
            try
            {
                e.Result = bl.GroupContractByDistance(order);
                for (int i = 0; i < 80; i += 5)
                {
                    System.Threading.Thread.Sleep(500);
                    Worker.ReportProgress(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //worker progress change evet
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            progressBarButton.Value = progress;
        }

        // sort button click event
        private void Sort_CLick(object sender, RoutedEventArgs e)
        {
            Worker.RunWorkerAsync(true);
        }
    }
}
