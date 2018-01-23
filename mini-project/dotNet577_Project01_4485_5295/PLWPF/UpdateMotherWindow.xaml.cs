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
    /// Interaction logic for UpdateMotherWindow.xaml
    /// </summary>
    public partial class UpdateMotherWindow : Window
    {
        IBL bl;
        Mother mother;
        List<Mother> motherList;
        string text;
        public UpdateMotherWindow(IBL Bl)
        {
            InitializeComponent();
            bl = Bl;
            motherList = bl.CloneMotherList();
            list.DataContext = motherList;
            mother = new Mother();
            UpdateMother.DataContext = mother;
        }

        //private void MotherSelected(object sender, SelectionChangedEventArgs e)
        //{
        //    ComboBox comboBox = sender as ComboBox;
        //    if (e.Equals(Key.Enter))
        //    {
        //        mother = (Mother)comboBox.SelectedItem;
        //        UpdateMother.DataContext = mother;
        //        if (mother != null)
        //            addressTextBox.Text = mother.Address;
        //    }
        //    else
        //    {
        //        comboBox.Text = text;
        //        comboBox.IsDropDownOpen = true;
        //    }
        //}

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (mother != null)
            {
                try
                {
                    mother.Address = addressTextBox.Text;
                    bl.UpdateMother(mother);
                    Close();
                }
                catch (BLException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SelectMother(object sender, EventArgs e)
        {
            if(list.Text != null)
            {
                mother = bl.CloneMotherList().Where(mother => mother.ToString() == list.Text).ToList()[0];
                UpdateMother.DataContext = mother;
                addressTextBox.Text = mother.Address;
            }
        }

        //private void TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    List<Mother> searchList = new List<Mother>();
        //    var textbox = (TextBox)list.Template.FindName("PART_EditableTextBox", list);
        //    var item = (sender as ComboBox);
        //    text = item.Text;
        //    if (text == string.Empty)
        //    {
        //        list.IsDropDownOpen = false;
        //        addressTextBox.Text = "";
        //    }
        //    searchList = motherList.Where(mother => mother.ID.ToString().StartsWith(text)).ToList();
        //    if (searchList.Count > 0)
        //    {
        //        list.DataContext = searchList;
        //        list.IsDropDownOpen = true;
        //        textbox.CaretIndex = text.Length;
        //    }
        //    else
        //        list.IsDropDownOpen = false;
        //}

    }
}
