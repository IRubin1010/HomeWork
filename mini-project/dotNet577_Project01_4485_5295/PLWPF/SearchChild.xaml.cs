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
    /// Interaction logic for SearchChild.xaml
    /// </summary>
    public partial class SearchChild : Page
    {
        IBL bl;
        Child child;
        List<Child> childList;
        public SearchChild(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            child = new Child();
            childList = bl.CloneChildList();
            list.DataContext = childList;
        }

        private void ChildSelected(object sender, SelectionChangedEventArgs e)
        {
            child = (Child)(sender as ComboBox).SelectedItem;
            searchChild.DataContext = child;
        }
    }
}
