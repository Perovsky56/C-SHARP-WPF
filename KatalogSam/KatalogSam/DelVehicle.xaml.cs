using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KatalogSam
{
    /// <summary>
    /// Logika interakcji dla klasy DelVehicle.xaml
    /// </summary>
    public partial class DelVehicle : Window
    {
        public DelVehicle()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number = int.Parse(delNumber.Text);
                ((MainWindow)System.Windows.Application.Current.MainWindow).DeleteStackPanel(number);
            }
            catch
            {
                lbl1.Content = "Musisz podać ID!";
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
}
}
