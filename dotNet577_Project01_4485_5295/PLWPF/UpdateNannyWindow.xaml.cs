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
    /// Interaction logic for UpdateNannyWindow.xaml
    /// </summary>
    public partial class UpdateNannyWindow : Window
    {
        IBL bl;
        Nanny nanny;
        List<Nanny> nannyList;
        public UpdateNannyWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            nannyList = bl.CloneNannyList();
            list.DataContext = nannyList;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text.Text != "")
            {
                int id = int.Parse(IDtextbox.Text);
                nanny = bl.FindNanny(id);
                if (nanny != null)
                {
                    NannyToUpdate.DataContext = nanny;
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (nanny != null)
            {
                try
                {
                    bl.UpdateNanny(nanny);
                    Close();
                }
                catch (BLException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("ther is no such nanny", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WorkDaysHours(object sender, RoutedEventArgs e)
        {
            new NannyWorkDaysHours(nanny).Show();
        }

        private void NannySelected(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            nanny = (Nanny)comboBox.SelectedItem;
            NannyToUpdate.DataContext = nanny;
        }
    }
}
