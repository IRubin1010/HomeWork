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
    /// Interaction logic for SearchMother.xaml
    /// </summary>
    public partial class SearchMother : Page
    {
        IBL bl;
        public SearchMother(IBL Bl, Mother mother)
        {
            InitializeComponent();
            bl = Bl;
            // bind mother details to mother
            searchMother.DataContext = mother;
            // bind work days and hours grid to mother
            work.DataContext = mother;
        }
    }
}
