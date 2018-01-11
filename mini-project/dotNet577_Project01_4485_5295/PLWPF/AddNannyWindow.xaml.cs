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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddNannyWindow.xaml
    /// </summary>
    public partial class AddNannyWindow : Window
    {
        IBL bl;
        Nanny nanny;
        public AddNannyWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            nanny = new Nanny();
            NannyDeatails.DataContext = nanny;
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine(nanny.WorkHours[0][0]);
                Console.WriteLine(nanny.WorkHours[1][0]);
                Console.WriteLine(nanny.WorkHours[0][3]);
                Console.WriteLine(nanny.WorkHours[1][3]);
                Console.WriteLine(nanny.IsWork[0]);
                bl.AddNanny(nanny);
                Console.WriteLine(nanny);
                nanny = new Nanny();
                NannyDeatails.DataContext = nanny;
                Close();
            }
            catch (BLException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WorkDaysHours_Click(object sender, RoutedEventArgs e)
        {
            new NannyWorkDaysHours(nanny).Show();
        }

        private void textboxes_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableButton();
        }
        private void EnableButton()
        {
            
        }
    }
}






//BindingExpression be = iDTextBox.GetBindingExpression(TextBox.TextProperty);
//iDTextBox.Text = nanny.ID.ToString();
//                be.UpdateSource();
