using System.Windows;
using Zaliczenie.View;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Zaliczenie.Models;

namespace Zaliczenie
{
    public partial class MainWindow : Window
    {
        private readonly Movies _movies = new Movies();

        public MainWindow()
        {
            InitializeComponent();
        }
        // Metoda dla przycisku Szukaj po nazwie
        private async void OnSearchAllClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var results = await _movies.GetMoviesAsync(tb1.Text);
                lb1.ItemsSource = results.D;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Metoda dla przycisku Szukaj filmu
        private async void OnSearchMoviesClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var results = await _movies.GetMoviesAsync(tb1.Text);
                if (results.D != null) // Sprawdzenie czy lista nie jest pusta
                {
                    var movies = results.D
                        .Where(item => item != null && item.Q != null && item.QID != null) // Sprawdzenie, czy item, Q, QID nie są null
                        .Where(item => item.Q.ToLower().Contains("feature") && item.QID.ToLower().Equals("movie"))
                        .ToList();
                    lb1.ItemsSource = movies;
                }
                else
                {
                    MessageBox.Show("Brak wyników do wyświetlenia.");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // Metoda dla przycisku Szukaj Serialu
        private async void OnSearchSeriesClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var results = await _movies.GetMoviesAsync(tb1.Text);
                if (results.D != null) // Sprawdzenie czy lista nie jest pusta
                {
                    var movies = results.D
                        .Where(item => item != null && item.Q != null && item.QID != null) // Sprawdzenie, czy item, Q, QID nie są null
                        .Where(item => item.Q.ToLower().Contains("tv") && item.QID.ToLower().Contains("tv"))
                        .ToList();
                    lb1.ItemsSource = movies;
                }
                else
                {
                    MessageBox.Show("Brak wyników do wyświetlenia.");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // Metoda dla przypisania obrazu do img1 dla znalezionej listy
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb1.SelectedItem is SearchItem selectedMovie && selectedMovie.I != null)
            {
                img1.Source = new BitmapImage(new Uri(selectedMovie.I.ImageUrl));
            }
        }
    }
 }