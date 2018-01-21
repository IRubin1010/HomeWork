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
    /// Interaction logic for AddChildWindow.xaml
    /// </summary>
    public partial class AddChildWindow : Window
    {
        IBL bl;
        Child child;
        public AddChildWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            child = new Child();
            AddChild.DataContext = child;
        }

        private void AddChild_CLick(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddChild(child);
                child = new Child();
                AddChild.DataContext = child;
                Close();
            }
            catch (BLException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void DateSelectsd(object sender, SelectionChangedEventArgs e)
        {
            BindingExpression be = ageInMonthTextBox.GetBindingExpression(TextBox.TextProperty);
            ageInMonthTextBox.Text = child.AgeInMonth.ToString();
            be.UpdateSource();
        }
    }
}
