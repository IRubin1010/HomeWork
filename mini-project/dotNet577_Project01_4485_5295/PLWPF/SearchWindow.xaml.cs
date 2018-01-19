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
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        IBL bl;
        public SearchWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
        }

        private void EntitySelected(object sender, SelectionChangedEventArgs e)
        {
            Entity entity = (Entity)(sender as ComboBox).SelectedItem;
            switch (entity)
            {
                case Entity.nanny:
                    selectedAction.Content = new SearchNanny(bl);
                    break;
                case Entity.mother:
                    selectedAction.Content = new SearchMother(bl);
                    break;
                case Entity.child:
                    selectedAction.Content = new SearchChild(bl);
                    break;
                case Entity.contract:
                    selectedAction.Content = new SearchContract(bl);
                    break;
                default:
                    break;
            }
        }
    }
}
