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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NannySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nanny.SelectedIndex = 0;
        }

        private void MotherSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mother.SelectedIndex = 0;
        }

        private void ChildSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            child.SelectedIndex = 0;
        }

        private void ContractSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contract.SelectedIndex = 0;
        }

        private void SearchSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            search.SelectedIndex = 0;
        }

        private void AddNannySelect(object sender, RoutedEventArgs e)
        {
            new AddNannyWindow().Show();
        }

        private void DeleteNannySelect(object sender, RoutedEventArgs e)
        {
            new DeleteNanny().Show();
        }

        private void UpdateNannySelect(object sender, RoutedEventArgs e)
        {
            new UpdateNannyWindow().Show();
        }
    }
}
