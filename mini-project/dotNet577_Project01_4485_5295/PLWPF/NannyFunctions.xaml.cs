﻿using System;
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
    public partial class NannyFunctions : Window
    {
        IBL bl;
        Nanny nanny;
        public NannyFunctions(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
        }

        private void NannyContractsSelect(object sender, RoutedEventArgs e)
        {
            list.Text = "";
            NannyFunctionFrame.Visibility = Visibility.Hidden;
        }

        private void NannyChildrenSelect(object sender, RoutedEventArgs e)
        {
            list.Text = "";
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
            nanny = (Nanny)list.textComboBox.SelectedItem;
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

        private void textChanged(object sender, EventArgs e)
        {
            if (list.Text == "")
            {
                NannyFunctionFrame.Visibility = Visibility.Hidden;
            }
        }
    }
}
