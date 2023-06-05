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
using DateTimePicker = System.Windows.Forms.DateTimePicker;
using System.IO;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] stopnie = { "Magister", "Doktor", "Doktor habilitowany", "Profesor" };
        private string[] zakresPrac2 = { "Prowadzenie ćwiczeń", "Prowadzenie badań naukowych", "Symulacje komputerowe", "Badania eksperymentalne", "Szkolenia" };

        public MainWindow()
        {
            InitializeComponent();
            this.Reset();
        }

        public void Reset()
        {
            name.Text = string.Empty;
            surname.Text = string.Empty;

            //ComboBox
            nazwyStopni.Items.Clear();
            foreach(string nazwaStopnia in stopnie)
            {
                nazwyStopni.Items.Add(nazwaStopnia);
            }
            nazwyStopni.Text = nazwyStopni.Items[0] as string;

            //ListBox
            zakresPrac.Items.Clear();
            CheckBox praca;
            foreach(string nazwaPracy in zakresPrac2)
            {
                praca = new CheckBox();
                praca.Margin = new Thickness(0, 0, 0, 10);
                praca.Content = nazwaPracy;
                zakresPrac.Items.Add(praca);
            }
            Nowy.IsChecked = true;
            DateTimePicker memberData = HostCzlonekOd.Child as DateTimePicker;
            memberData.Value = DateTime.Today;
            saveMember.IsEnabled = true;
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult key = MessageBox.Show("Czy na pewno zamknąć aplikację?", "Potwierdź", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            e.Cancel = (key != MessageBoxResult.Yes);
        }

        private void aboutMember_Click(object sender, RoutedEventArgs e)
        {
            About OknoO = new About();
            OknoO.ShowDialog();
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            this.Reset();
        }

        private void newMember_Click(object sender, RoutedEventArgs e)
        {
            this.Reset();
        }

        private void saveMember_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog oknoZapisuPliku = new SaveFileDialog();
            oknoZapisuPliku.DefaultExt = "txt";
            oknoZapisuPliku.AddExtension = true;
            oknoZapisuPliku.FileName = "Czlonkowie";
            oknoZapisuPliku.InitialDirectory = @"C:\Users\student.IAII\source\repos\svearike\WPF L5\WpfApp1";
            oknoZapisuPliku.OverwritePrompt = true;
            oknoZapisuPliku.Title = "Członkowie grupy naukowej";
            oknoZapisuPliku.ValidateNames = true;

            if (oknoZapisuPliku.ShowDialog().Value)
            {
                using(StreamWriter writer = new StreamWriter(oknoZapisuPliku.FileName))
                {
                    writer.WriteLine("Imię: {0}", name.Text);
                    writer.WriteLine("Nazwisko: {0}", surname.Text);
                    writer.WriteLine("Stopień naukowy: {0}", nazwyStopni.Text);
                    DateTimePicker memberDate = HostCzlonekOd.Child as DateTimePicker;
                    writer.WriteLine("Członek naukowy od {0}", memberDate.Value.ToString());
                    writer.WriteLine("Zakres prac do wykonania: ");
                    foreach (CheckBox cb in zakresPrac.Items)
                    {
                        if (cb.IsChecked.Value)
                        {
                            writer.WriteLine(cb.Content.ToString());
                        }
                    }
                    MessageBox.Show("Dane osoby zostały zapisane.");
                }
            }
        }
    }
}
