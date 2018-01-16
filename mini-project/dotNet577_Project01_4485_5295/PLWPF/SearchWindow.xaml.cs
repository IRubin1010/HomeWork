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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
        }

        private void EntitySelected(object sender, SelectionChangedEventArgs e)
        {
            Entity entity = (Entity)(sender as ComboBox).SelectedItem;
            switch(entity)
            {
                case Entity.nanny:
                        selectedAction.Content = new SearchNanny();
                        break;
                case Entity.mother:
                    selectedAction.Content = new SearchMother();
                    break;
                case Entity.child:
                    selectedAction.Content = new SearchChild();
                    break;
                case Entity.contract:
                    selectedAction.Content = new SearchContract();
                    break;
                default:
                    break;
            }
        }


        //private void click(object sender, RoutedEventArgs e)
        //{
        //    selectedAction.Content = new SearchNanny();
        //}
    }
}
