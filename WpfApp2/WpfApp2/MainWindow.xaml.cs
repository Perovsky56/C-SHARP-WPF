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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Button MyControl = new Button();
            //MyControl.Content = "Test Button!";

            //Grid.SetRow(MyControl, 3);
            //Grid.SetColumn(MyControl, 0);
            //menu.Children.Add(MyControl);
        }

        public void AddElementToWrap()
        {
             //< StackPanel Height = "150"
             //       Width = "200"
             //       Margin = "33, 0, 0, 33"
             //       VerticalAlignment = "Top"
             //       HorizontalAlignment = "Left"
             //       Orientation = "Horizontal"
             //       Background = "#000" />
            StackPanel st1 = new StackPanel();
            st1.Height = 150;
            st1.Width = 200;
            st1.Margin = new Thickness(33, 0, 0, 33);
            st1.VerticalAlignment = VerticalAlignment.Top;
            st1.HorizontalAlignment = HorizontalAlignment.Left;
            st1.Orientation = Orientation.Horizontal;
            st1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#000000");
            Grid.SetRow(st1, 0);
            menu.Children.Add(st1);

        }

        private void Przycisk(object sender, RoutedEventArgs e)
        {
            AddElementToWrap();
        }
    }
}
