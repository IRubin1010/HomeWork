using System;
using System.Collections.Generic;
using System.Globalization;
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
            // bind child
            AddChild.DataContext = child;
            birthDateDatePicker.DisplayDateEnd = DateTime.Now;
        }

        // add child button click event
        private void AddChild_CLick(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddChild(child.Clone());
                child = new Child();
                AddChild.DataContext = child;
                Close();
            }
            catch (BLException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        // date selected event
        private void DateSelectsd(object sender, SelectionChangedEventArgs e)
        {
            // update child age field in UI
            BindingExpression be = ageInMonthTextBox.GetBindingExpression(TextBox.TextProperty);
            ageInMonthTextBox.Text = child.AgeInMonth.ToString();
            be.UpdateSource();
        }
    }
}
