using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParalimpiaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Paralimpia> paralimpiak = new List<Paralimpia>();
        int id = 0;
        public MainWindow()
        {
            InitializeComponent();
            using(StreamReader sr = new StreamReader(@"..\..\..\src\ermek.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    paralimpiak.Add(new Paralimpia(sr.ReadLine()));
                }
            }

            AdatokGrid.ItemsSource = paralimpiak;
        }

        private void modositas_Click(object sender, RoutedEventArgs e)
        {
            var ev = JeloltEv.Content.ToString();
            var arany = JeloltArany.Text;
            var ezust = JeloltEzust.Text;
            var bronz = JeloltBronz.Text;
            DateTime most = DateTime.Now;
            var id = this.id;

           

            if (MessageBoxResult.Yes == MessageBox.Show($"Valóban javaslatot tesz a(z) {ev}. évi paralimpia éremszámára?", "Megerősítés", MessageBoxButton.YesNo))
            {
                using (StreamWriter sw = new StreamWriter(@"..\..\..\src\javaslat.txt", true, Encoding.UTF8))
                {
                    sw.WriteLine($"{most.ToString("yyyy.MM.dd. HH:mm:ss")} Id: {id} {ev} {arany} {ezust} {bronz}");
                }
            }

            

        }

        private void SearchTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string kereses = SearchTxt.Text;
            if (kereses.Length > 0)
            {
                AdatokGrid.ItemsSource = paralimpiak.Where(x => x.Orszag.ToLower().Contains(kereses.ToLower()) || x.Varos.ToLower().Contains(kereses.ToLower())).ToList();
            }
            else
            {
                AdatokGrid.ItemsSource = paralimpiak;
            }
        }

        private void AdatokGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var valasztott = AdatokGrid.SelectedItem as Paralimpia;

            JeloltEv.Content = valasztott.Ev.ToString();
            JeloltArany.Text = valasztott.Arany.ToString();
            JeloltEzust.Text = valasztott.Ezust.ToString();
            JeloltBronz.Text = valasztott.Bronz.ToString();
            id = valasztott.Id;

        }
    }
}