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
    /// Interaction logic for SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl
    {
        IBL bl;

        // create 2 events for the control
        public event EventHandler ItemSelectsd;
        public event EventHandler TextChanged;

        // Text property
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // add Text property to be Dependency property
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(SearchControl), new PropertyMetadata(null));

        // Entity property
        public Entity Entity
        {
            get { return (Entity)GetValue(EntityProperty); }
            set { SetValue(EntityProperty, value); }
        }

        // add Entity property to be Dependency property
        public static readonly DependencyProperty EntityProperty =
            DependencyProperty.Register("Entity", typeof(Entity), typeof(SearchControl), new PropertyMetadata(null));

        public SearchControl()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            SearchGrid.DataContext = this;
        }

        // grt the list and bind to the combobox
        private void setListInvok<T>(List<T> list)
        {
            this.textComboBox.ItemsSource = null;
            if (list.Count > 0)
            {
                this.textComboBox.ItemsSource = list;
                textComboBox.IsDropDownOpen = true;
            }
            else // list is empty
            {
                textComboBox.IsDropDownOpen = false;
            }
        }

        // get list according to the text in textbox
        private void searchList()
        {
            List<Mother> motherSearchList = new List<Mother>();
            List<Nanny> nannySearchList = new List<Nanny>();
            List<Child> childySearchList = new List<Child>();
            List<Contract> contractSearchList = new List<Contract>();
            // get the list according to the entity and the text
            switch (Entity)
            {
                case Entity.nanny:
                    nannySearchList = bl.CloneNannyList().Where(nanny => nanny.ID.ToString().StartsWith(Text)).ToList();
                    setListInvok(nannySearchList);
                    break;
                case Entity.mother:
                    motherSearchList = bl.CloneMotherList().Where(mother => mother.ID.ToString().StartsWith(Text)).ToList();
                    setListInvok(motherSearchList);
                    break;
                case Entity.child:
                    childySearchList = bl.CloneChildList().Where(child => child.ID.ToString().StartsWith(Text)).ToList();
                    setListInvok(childySearchList);
                    break;
                case Entity.contract:
                    contractSearchList = bl.CloneContractList().Where(contract => contract.ContractNumber.ToString().StartsWith(Text)).ToList();
                    setListInvok(contractSearchList);
                    break;
                default:
                    break;
            }
        }

        // text changed event
        private void textInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            // if Text is empty or item was selected in combobox
            // set dropdown to false
            if (Text == "" || textComboBox.SelectedItem != null)
            {
                // if the item selected is different from the Text
                // set item to be null
                if (textComboBox.SelectedItem != null && Text != textComboBox.SelectedItem.ToString())
                    textComboBox.SelectedItem = null;
                textComboBox.IsDropDownOpen = false;
            }
            // if Text is not empty and no item selected
            else
                // call to get a match list
                searchList();
            // invoke TextChanged event
            TextChanged?.Invoke(this, EventArgs.Empty);
        }

        // combobox selection changed event
        private void textComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = textComboBox.SelectedItem;
            if (item != null)
            {
                // update Text
                Text = item.ToString();
                textComboBox.IsDropDownOpen = false;
                // invoke ItemSelected event
                ItemSelectsd?.Invoke(this, EventArgs.Empty);
            }
        }
        // key down evevnt
        private void textInput_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Down)
            {
                // set focus to combobox
                this.textComboBox.Focus();
            }
        }

        // key up evevnt
        private void textComboBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Up)

                if (this.textComboBox.SelectedIndex == 0)
                    // set focus to textbox
                    this.textInput.Focus();
        }

        // dropdown button click event
        private void Drop_Clic(object sender, RoutedEventArgs e)
        {
            List<Mother> motherSearchList = new List<Mother>();
            List<Nanny> nannySearchList = new List<Nanny>();
            List<Child> childySearchList = new List<Child>();
            List<Contract> contractSearchList = new List<Contract>();
            // for each entity get list and call to show the list
            switch (Entity)
            {
                case Entity.nanny:
                    nannySearchList = bl.CloneNannyList();
                    setListInvok(nannySearchList);
                    break;
                case Entity.mother:
                    motherSearchList = bl.CloneMotherList();
                    setListInvok(motherSearchList);
                    break;
                case Entity.child:
                    childySearchList = bl.CloneChildList();
                    setListInvok(childySearchList);
                    break;
                case Entity.contract:
                    contractSearchList = bl.CloneContractList();
                    setListInvok(contractSearchList);
                    break;
                default:
                    break;
            }
        }
    }
}
