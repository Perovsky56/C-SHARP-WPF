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
using System.Windows.Markup;
using System.IO;
using System.Xml;

namespace KatalogSam
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

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
            
        }
        public int StacksNumber = 7;
        public void CreateNewStackPanel(string imageName, string carName)
        {
            string saveStackPanel = XamlWriter.Save(aaa);
            StringReader stringReader = new StringReader(saveStackPanel);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            StackPanel st1 = (StackPanel)XamlReader.Load(xmlReader);

            Image Img = new Image();
            Img.Source = new BitmapImage(new Uri(@"C:\Users\pawci\source\repos\KatalogSam\KatalogSam\Images\" + imageName +".png", UriKind.RelativeOrAbsolute));
            Img.Width = 250;
            Img.Height = 150;
            Img.Margin = new Thickness(15);

            TextBlock Txt1 = new TextBlock();
            Txt1.Text = carName;
            Txt1.Foreground = Brushes.White;
            Txt1.FontSize = 12;
            Txt1.FontWeight = FontWeights.Bold;
            Txt1.HorizontalAlignment = HorizontalAlignment.Center;
            Txt1.Margin = new Thickness(15);

            st1.Width = 340;
            st1.Height = 250;
            st1.Margin = new Thickness(33, 0, 0, 33);
            Grid.SetColumn(st1, 0);
            st1.Children.Add(Img);
            st1.Children.Add(Txt1);
            st1.Name = "StackPanel"+StacksNumber;
            menu.Children.Add(st1);

            StacksNumber++;
        }

        public void DeleteStackPanel(int number)
        {
            try {
                menu.Children.RemoveAt(number);
            }
            catch {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Kontakt(object sender, RoutedEventArgs e)
        {
            Contact Kontakt = new Contact();
            Kontakt.ShowDialog();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            About ONas = new About();
            ONas.ShowDialog();
        }
        public int number = 7;
        private void Add_Vehicle(object sender, RoutedEventArgs e)
        {
            AddVehicle newCar = new AddVehicle();
            newCar.ShowDialog();
        }

        private void Del_Vehicle(object sender, RoutedEventArgs e)
        {
            DelVehicle delCar = new DelVehicle();
            delCar.ShowDialog();
        }
    }
}
