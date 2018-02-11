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
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        IBL bl;
        Nanny nanny;
        Mother mother;
        Child child;
        Contract contract;
        public SearchWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
        }

        // entity selected event
        private void EntitySelected(object sender, SelectionChangedEventArgs e)
        {
            Entity entity = (Entity)(sender as ComboBox).SelectedItem;
            switch (entity)
            {
                // for each entity set serch control entity
                // and make frame unvisible (until item is selected in combobox)
                case Entity.nanny:
                    searchList.Entity = Entity.nanny;
                    searchList.Text = "";
                    selectedAction.Content = new Nannies(bl);
                    selectedAction.Visibility = Visibility.Visible;
                    break;
                case Entity.mother:
                    searchList.Entity = Entity.mother;
                    searchList.Text = "";
                    selectedAction.Content = new Mothers(bl);
                    selectedAction.Visibility = Visibility.Visible;
                    break;
                case Entity.child:
                    searchList.Entity = Entity.child;
                    searchList.Text = "";
                    selectedAction.Content = new Children(bl);
                    selectedAction.Visibility = Visibility.Visible;
                    break;
                case Entity.contract:
                    searchList.Entity = Entity.contract;
                    searchList.Text = "";
                    selectedAction.Content = new Contracts(bl);
                    selectedAction.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        // item selected in combobox event
        private void ItemSelected(object sender, EventArgs e)
        {
            Entity entity = (Entity)EntityList.SelectedItem;
            if (searchList.Text != null)
            {
                // make frame visible
                selectedAction.Visibility = Visibility.Visible;
                // for each item selected, get the item
                // and open the frame with the item 
                switch (entity)
                {
                    case Entity.nanny:
                        nanny = bl.CloneNannyList().FirstOrDefault(nanny => nanny.ToString() == searchList.Text);
                        selectedAction.Content = new SearchNanny(bl, nanny);
                        break;
                    case Entity.mother:
                        mother = bl.CloneMotherList().FirstOrDefault(mother => mother.ToString() == searchList.Text);
                        selectedAction.Content = new SearchMother(bl, mother);
                        break;
                    case Entity.child:
                        child = bl.CloneChildList().FirstOrDefault(child => child.ToString() == searchList.Text);
                        selectedAction.Content = new SearchChild(bl, child);
                        break;
                    case Entity.contract:
                        contract = bl.CloneContractList().FirstOrDefault(contract => contract.ToString() == searchList.Text);
                        selectedAction.Content = new SearchContract(bl, contract);
                        break;
                    default:
                        break;
                }
            }
        }

        // text changed in combobox event
        private void TextChanged(object sender, EventArgs e)
        {
            Entity entity = (Entity)EntityList.SelectedItem;
            if (searchList.Text == "")
            {
                // for each entity
                // if no item selected, clear all fields
                switch (entity)
                {
                    case Entity.nanny:
                        nanny = new Nanny();
                        selectedAction.Content = new SearchNanny(bl, nanny);
                        break;
                    case Entity.mother:
                        mother = new Mother();
                        selectedAction.Content = new SearchMother(bl, mother);
                        break;
                    case Entity.child:
                        child = new Child();
                        selectedAction.Content = new SearchChild(bl, child);
                        break;
                    case Entity.contract:
                        contract = new Contract();
                        selectedAction.Content = new SearchContract(bl, contract);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
