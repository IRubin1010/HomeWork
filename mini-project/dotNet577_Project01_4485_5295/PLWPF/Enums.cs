using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLWPF
{
    
    public enum Entity
    {
        nanny,
        mother,
        child,
        contract,
    }
}

//<Window x:Class="NestedGrid.MainWindow"
//        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
//        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
//        Title="MainWindow" Height="302" Width="553">
//    <Grid>
//        <DataGrid RowHeaderWidth = "0" Background="White" Name="dgCashflow" ColumnHeaderHeight="22"  RowHeight="50" AutoGenerateColumns="False" 
//                     AlternatingRowBackground="#FFD3DBF2" CanUserAddRows="False" CanUserDeleteRows="False" CanUserResizeRows="False"  
//                     SelectionMode="Single" SelectionUnit="FullRow" ItemsSource="{Binding}" Height="162" VerticalAlignment="Top" SelectionChanged="dgCashflow_SelectionChanged">
//            <DataGrid.Columns>
//                <DataGridTextColumn Binding = "{Binding Path=Name}" Header="Name" IsReadOnly="True" Width="100"/>

//                <DataGridTemplateColumn Header = "Cumulative Recovery Rate (CRR)" Width="300" >
//                    <DataGridTemplateColumn.CellTemplate>
//                        <DataTemplate>
//                            <DataGrid RowHeaderWidth = "0" Background="White" ColumnHeaderHeight="22" RowHeight="22"
//                                ItemsSource="{Binding Path=SubClass}" AutoGenerateColumns="False" VerticalAlignment="Stretch" 
//                                      ScrollViewer.HorizontalScrollBarVisibility="Disabled" ScrollViewer.VerticalScrollBarVisibility="Auto" >
//                                <DataGrid.Columns>
//                                    <DataGridTextColumn Binding = "{Binding Path=Week1}" Header="Week1" IsReadOnly="True" Width="90"/>
//                                    <DataGridTextColumn Binding = "{Binding Path=Week2}" Header="Week2" IsReadOnly="True" Width="90"/>
//                                    <DataGridTemplateColumn Header = "Change" Width="115" >
//                                        <DataGridTemplateColumn.CellTemplate>
//                                            <DataTemplate>
//                                                <TextBlock Text = "{Binding Path=Change}" Foreground ="{Binding Path=Clr}" TextAlignment="Center" HorizontalAlignment="Stretch" Height="22"/>
//                                            </DataTemplate>
//                                        </DataGridTemplateColumn.CellTemplate>
//                                    </DataGridTemplateColumn>
//                                </DataGrid.Columns>
//                            </DataGrid>
//                        </DataTemplate>
//                    </DataGridTemplateColumn.CellTemplate>
//                </DataGridTemplateColumn>

//                <DataGridTextColumn Binding = "{Binding Path=Note}" Header="Note" IsReadOnly="True" Width="100"/>
//            </DataGrid.Columns>
//        </DataGrid>

//        <DataGrid RowHeaderWidth = "0" Background="White" ColumnHeaderHeight="22"  RowHeight="22" AlternatingRowBackground="#FFD3DBF2" Name="dgs"
//                                CanUserAddRows="False" CanUserDeleteRows="False" CanUserResizeRows="False" SelectionMode="Single" SelectionUnit="Cell" 
//                   ItemsSource="{Binding}" Margin="0,168,0,0" Height="95" VerticalAlignment="Top" AutoGenerateColumns="False">
//            <DataGrid.Columns>
//                <DataGridTextColumn Binding = "{Binding Path=Week1}" Header="Week1" IsReadOnly="True"/>
//                <DataGridTextColumn Binding = "{Binding Path=Week2}"  Header="Week2" IsReadOnly="True"/>
//                <DataGridTextColumn Binding = "{Binding Path=Change}"  Header="Change" IsReadOnly="True"/>
//            </DataGrid.Columns>
//        </DataGrid>

//    </Grid>
//</Window>


//5. Add the following code in Mainwindow.cs to Load the Grid Data and selected item change event

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace NestedGrid
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        public MainWindow()
//        {
//            InitializeComponent();

//            LoadGrid();
//        }

//        private void LoadGrid()
//        {
//            List<Class1> listClass1 = new List<Class1>();


//            List<subclass11> sl1 = new List<subclass11>();
//            sl1.Add(new subclass11 { Week1 = 1000, Week2 = 3500, Change = "2500", Clr = Brushes.Red });
//            listClass1.Add(new Class1 { Name = "Dhaka", SubClass = sl1, Note = "For Dhaka" });

//            List<subclass11> sl2 = new List<subclass11>();
//            sl2.Add(new subclass11 { Week1 = 1500, Week2 = 3000, Change = "2000", Clr = Brushes.Green });
//            sl2.Add(new subclass11 { Week1 = 2500, Week2 = 3750, Change = "2750", Clr = Brushes.Green });
//            listClass1.Add(new Class1 { Name = "Khulna", SubClass = sl2, Note = "For Khulna" });

//            List<subclass11> sl3 = new List<subclass11>();
//            sl3.Add(new subclass11 { Week1 = 2000, Week2 = 4500, Change = "3500", Clr = Brushes.Blue });
//            listClass1.Add(new Class1 { Name = "Barisal", SubClass = sl3, Note = "For Barisal" });

//            dgCashflow.ItemsSource = listClass1;
//        }

//        private void dgCashflow_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {
//            try
//            {
//                dgs.ItemsSource = null;
//                Class1 _c = new Class1();
//                _c = dgCashflow.SelectedItems[0] as Class1;
//                List<subclass11> s = new List<subclass11>();
//                s = _c.SubClass;
//                dgs.ItemsSource = s;
//            }
//            catch { }
//        }
//    }
//}
