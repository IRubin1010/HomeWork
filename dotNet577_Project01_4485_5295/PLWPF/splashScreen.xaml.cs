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
using System.Windows.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for splashScreen.xaml
    /// </summary>
    public partial class splashScreen : Window
    {
        DispatcherTimer timer = null;
        void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += new EventHandler(timer_Elapsed);
            timer.Start();
        }

        void timer_Elapsed(object sender, EventArgs e)
        {
            timer.Stop();
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
        public splashScreen()
        {
            InitializeComponent();
            StartTimer();

        }
    }
}
