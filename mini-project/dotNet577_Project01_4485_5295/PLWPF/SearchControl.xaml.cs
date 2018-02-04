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

        public event EventHandler ItemSelectsd;
        public event EventHandler TextChanged;

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(SearchControl), new PropertyMetadata(null));

        public static readonly DependencyProperty EntityProperty =
            DependencyProperty.Register("Entity", typeof(Entity), typeof(SearchControl), new PropertyMetadata(null));

        public Entity Entity
        {
            get { return (Entity)GetValue(EntityProperty); }
            set { SetValue(EntityProperty, value); }
        }


        public SearchControl()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            Console.WriteLine(Entity);
            this.SearchGrid.DataContext = this;
        }

        private void setListInvok<T>(List<T> list)
        {
            this.textComboBox.ItemsSource = null;
            if (list.Count > 0)
            {
                this.textComboBox.ItemsSource = list;
                textComboBox.IsDropDownOpen = true;
            }
            else
            {
                textComboBox.IsDropDownOpen = false;
            }
        }

        private void searchList()
        {
            List<Mother> motherSearchList = new List<Mother>();
            List<Nanny> nannySearchList = new List<Nanny>();
            List<Child> childySearchList = new List<Child>();
            List<Contract> contractSearchList = new List<Contract>();
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
        private void textInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Text == "" || textComboBox.SelectedItem != null)
            {
                if (textComboBox.SelectedItem != null && Text != textComboBox.SelectedItem.ToString())
                    textComboBox.SelectedItem = null;
                textComboBox.IsDropDownOpen = false;
            }
            else
                searchList();
            TextChanged?.Invoke(this, EventArgs.Empty);
        }

        private void textComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = textComboBox.SelectedItem;
            if (item != null)
            {
                Text = item.ToString();
                textComboBox.IsDropDownOpen = false;
                ItemSelectsd?.Invoke(this, EventArgs.Empty);
            }
        }



        private void textInput_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Down)
            {
                this.textComboBox.Focus();

            }
        }

        private void textComboBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Up)

                if (this.textComboBox.SelectedIndex == 0)
                    this.textInput.Focus();
        }

        private void Drop_Clic(object sender, RoutedEventArgs e)
        {
            List<Mother> motherSearchList = new List<Mother>();
            List<Nanny> nannySearchList = new List<Nanny>();
            List<Child> childySearchList = new List<Child>();
            List<Contract> contractSearchList = new List<Contract>();
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
