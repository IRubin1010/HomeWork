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

        private void NannyContractsSelect(object sender, RoutedEventArgs e)
        {
            NannyList.Text = "";
            NannyFunctionFrame.Visibility = Visibility.Hidden;
        }

        private void NannyChildrenSelect(object sender, RoutedEventArgs e)
        {
            NannyList.Text = "";
            NannyFunctionFrame.Visibility = Visibility.Hidden;
        }

        private void NannyVactionSelect(object sender, RoutedEventArgs e)
        {
            NannyFunctionFrame.Visibility = Visibility.Visible;
            NannyFunctionFrame.Content = new NannyValidVactions(bl);
        }

        private void NannyChildrenLessSelect(object sender, RoutedEventArgs e)
        {
            NannyFunctionFrame.Visibility = Visibility.Hidden;
        }

        private void lessThanTextChanged(object sender, TextChangedEventArgs e)
        {
            if (lessThanTextBox.Text != "")
            {
                if (RButton3.IsChecked == true)
                {
                    NannyFunctionFrame.Visibility = Visibility.Visible;
                    NannyFunctionFrame.Content = new NannyChildrenLess(bl, int.Parse(lessThanTextBox.Text));
                }
            }
            else
            {
                NannyFunctionFrame.Visibility = Visibility.Hidden;
            }
        }

        private void NannySelected(object sender, EventArgs e)
        {
            nanny = (Nanny)NannyList.textComboBox.SelectedItem;
            if (nanny != null)
            {
                if (RButton1.IsChecked == true)
                {
                    NannyFunctionFrame.Visibility = Visibility.Visible;
                    NannyFunctionFrame.Content = new NannyContracts(bl, nanny);
                }
                if (RButton2.IsChecked == true)
                {
                    NannyFunctionFrame.Visibility = Visibility.Visible;
                    NannyFunctionFrame.Content = new NannyChildren(bl, nanny);
                }
            }
        }

        private void NannySearchtextChanged(object sender, EventArgs e)
        {
            if (NannyList.Text == "")
            {
                NannyFunctionFrame.Visibility = Visibility.Hidden;
            }
        }

        private void MotherChildrenSelect(object sender, RoutedEventArgs e)
        {
            MotherList.Text = "";
            NannyFunctionFrame.Visibility = Visibility.Hidden;
        }

        private void ChildrenWithNoNannySelect(object sender, RoutedEventArgs e)
        {
            NannyFunctionFrame.Visibility = Visibility.Visible;
            NannyFunctionFrame.Content = new ChildrenWithNoNanny(bl);
        }

        private void MotherSelected(object sender, EventArgs e)
        {
            mother = (Mother)MotherList.textComboBox.SelectedItem;
            if (mother != null)
            {
                if (RButton5.IsChecked == true)
                {
                    NannyFunctionFrame.Visibility = Visibility.Visible;
                    NannyFunctionFrame.Content = new MotherChildren(bl, mother);//////////
                }
            }
        }

        private void MotherSearchtextChanged(object sender, EventArgs e)
        {
            if (MotherList.Text == "")
            {
                NannyFunctionFrame.Visibility = Visibility.Hidden;
            }
        }

    }
}
