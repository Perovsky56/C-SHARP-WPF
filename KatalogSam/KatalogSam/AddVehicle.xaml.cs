using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Logika interakcji dla klasy AddVehicle.xaml
    /// </summary>
    public partial class AddVehicle : Window
    {
        public AddVehicle()
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

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Wybierz obraz";
            op.Filter = "Wszystkie wspierane grafiki|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory + @"\Images");
            op.InitialDirectory = path;
            if (op.ShowDialog() == true)
            {
                btnSave.Visibility = Visibility.Visible;
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var window = (MainWindow)Application.Current.MainWindow;
            string filePath = @"C:\Users\pawci\source\repos\KatalogSam\KatalogSam\Images\car-"+window.number+".png";
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imgPhoto.Source));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
                encoder.Save(stream);

            string photoName = "car-" + window.number;
            ((MainWindow)System.Windows.Application.Current.MainWindow).CreateNewStackPanel(photoName, carName.Text);

            window.number++;

            if(carName.Text == "")
            {
                lbl1.Content = "Pojazd został dodany pomyślnie.";
            } else
            {
                lbl1.Content = "Pojazd został " + carName.Text + " dodany pomyślnie.";
            }

        }
    }
}
