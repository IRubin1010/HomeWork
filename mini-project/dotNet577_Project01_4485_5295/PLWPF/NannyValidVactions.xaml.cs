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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for NannyValidVactions.xaml
    /// </summary>
    public partial class NannyValidVactions : Page
    {
        IBL bl;
        public NannyValidVactions(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            // bind data drid to nanny with valid vaction days list
            Grouping.DataContext = bl.ValidVacationsNannys();
        }
    }
}
