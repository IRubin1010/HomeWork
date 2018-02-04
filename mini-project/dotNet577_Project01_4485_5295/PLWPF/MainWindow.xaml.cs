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
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = FactoryBL.GetBL();
        public MainWindow()
        {
            InitializeComponent();
            Initialize init = new Initialize(bl);
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
            new AddNannyWindow(bl).Show();
        }

        private void DeleteNannySelect(object sender, RoutedEventArgs e)
        {
            new DeleteNanny(bl).Show();
        }

        private void UpdateNannySelect(object sender, RoutedEventArgs e)
        {
            new UpdateNannyWindow(bl).Show();
        }

        private void AddMotherSelect(object sender, RoutedEventArgs e)
        {
            new AddMotherWindow(bl).Show();
        }

        private void UpdateMotherSelect(object sender, RoutedEventArgs e)
        {
            new UpdateMotherWindow(bl).Show();
        }

        private void DeleteMotherSelect(object sender, RoutedEventArgs e)
        {
            new DeleteMotherWindow(bl).Show();
        }

        private void AddChildSelect(object sender, RoutedEventArgs e)
        {
            new AddChildWindow(bl).Show();
        }

        private void UpdateChildSelect(object sender, RoutedEventArgs e)
        {
            new UpdateChildWindow(bl).Show();
        }

        private void DeleteChildSelect(object sender, RoutedEventArgs e)
        {
            new DeleteChildWindow(bl).Show();
        }

        private void DeleteContractSelect(object sender, RoutedEventArgs e)
        {
            new DeleteContractWindow(bl).Show();
        }

        private void UpdateContractSelect(object sender, RoutedEventArgs e)
        {
            new UpdateContractWindow(bl).Show();
        }

        private void AddContractSelect(object sender, RoutedEventArgs e)
        {
            new AddContractWindow(bl).Show();
        }

        private void SearchSelect(object sender, RoutedEventArgs e)
        {
            new SearchWindow(bl).Show();
        }

        private void GroupByAgeSelect(object sender, RoutedEventArgs e)
        {
            new GroupByAge(bl).Show();
        }

        private void GroupByDistanceSelect(object sender, RoutedEventArgs e)
        {
            new GroupByDistance(bl).Show();
        }

        private void MoreOptionssSelect(object sender, RoutedEventArgs e)
        {
            new MoreOptions(bl).Show();
        }
    }
}
