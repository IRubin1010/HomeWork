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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for NannyFunctions.xaml
    /// </summary>
    public partial class MoreOptions : Window
    {
        IBL bl;
        Nanny nanny;
        Mother mother;
        public MoreOptions(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
        }

        // nanny contracts selected event
        private void NannyContractsSelect(object sender, RoutedEventArgs e)
        {
            NannyList.Text = "";
            // make frame unvisible
            NannyFunctionFrame.Visibility = Visibility.Hidden;
        }

        // nanny children selected event
        private void NannyChildrenSelect(object sender, RoutedEventArgs e)
        {
            NannyList.Text = "";
            // make frame unvisible
            NannyFunctionFrame.Visibility = Visibility.Hidden;
        }

        // nanny with valid vactions days selected event
        private void NannyVactionSelect(object sender, RoutedEventArgs e)
        {
            // make frame visible
            NannyFunctionFrame.Visibility = Visibility.Visible;
            // show the frame
            NannyFunctionFrame.Content = new NannyValidVactions(bl);
        }

        // nanny with children less then selected event
        private void NannyChildrenLessSelect(object sender, RoutedEventArgs e)
        {
            // make frame unvisible
            NannyFunctionFrame.Visibility = Visibility.Hidden;
        }

        // less then textbox text changed event
        private void lessThanTextChanged(object sender, TextChangedEventArgs e)
        {
            if (lessThanTextBox.Text != "")
            {
                if (RButton3.IsChecked == true)
                {
                    // make frame visible and show
                    NannyFunctionFrame.Visibility = Visibility.Visible;
                    NannyFunctionFrame.Content = new NannyChildrenLess(bl, int.Parse(lessThanTextBox.Text));
                }
            }
            // text is empty
            else
            {
                // make frame unvisible
                NannyFunctionFrame.Visibility = Visibility.Hidden;
            }
        }

        // event when nanny selected
        private void NannySelected(object sender, EventArgs e)
        {
            nanny = (Nanny)NannyList.textComboBox.SelectedItem;
            if (nanny != null)
            {
                // if select nanny contracts
                if (RButton1.IsChecked == true)
                {
                    NannyFunctionFrame.Visibility = Visibility.Visible;
                    NannyFunctionFrame.Content = new NannyContracts(bl, nanny);
                }
                // if select nanny children
                if (RButton2.IsChecked == true)
                {
                    NannyFunctionFrame.Visibility = Visibility.Visible;
                    NannyFunctionFrame.Content = new NannyChildren(bl, nanny);
                }
            }
        }

        // event when text in nanny search control is changed
        private void NannySearchtextChanged(object sender, EventArgs e)
        {
            if (NannyList.Text == "")
            {
                NannyFunctionFrame.Visibility = Visibility.Hidden;
            }
        }

        // mother children selected event
        private void MotherChildrenSelect(object sender, RoutedEventArgs e)
        {
            MotherList.Text = "";
            // make frame unvisivle
            NannyFunctionFrame.Visibility = Visibility.Hidden;
        }

        // children with no nanny selected event
        private void ChildrenWithNoNannySelect(object sender, RoutedEventArgs e)
        {
            NannyFunctionFrame.Visibility = Visibility.Visible;
            NannyFunctionFrame.Content = new ChildrenWithNoNanny(bl);
        }

        // event when mother selected
        private void MotherSelected(object sender, EventArgs e)
        {
            mother = (Mother)MotherList.textComboBox.SelectedItem;
            if (mother != null)
            {
                // if mother children selected
                if (RButton5.IsChecked == true)
                {
                    NannyFunctionFrame.Visibility = Visibility.Visible;
                    NannyFunctionFrame.Content = new MotherChildren(bl, mother);
                }
            }
        }

        // event when text in mother search control is changed
        private void MotherSearchtextChanged(object sender, EventArgs e)
        {
            if (MotherList.Text == "")
            {
                NannyFunctionFrame.Visibility = Visibility.Hidden;
            }
        }

    }
}
