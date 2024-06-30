using LibraryManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryManagement.Views
{
    /// <summary>
    /// Interaction logic for LibraryWindow.xaml
    /// </summary>
    public partial class LibraryWindow : Window
    {
        private readonly HttpClient _httpClient;

        public List<Library> libraries { get; set; }
        public LibraryWindow()
        {
            _httpClient = new HttpClient();

            libraries = GetLibraries();            

            InitializeComponent();

            bookDataGrid.ItemsSource = null;
            bookDataGrid.ItemsSource = libraries.Select(book =>
            new LibraryView()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre.FirstOrDefault(),
                Description = book.Description
            });
        }

        private List<Library> GetLibraries()
        {
            var url = $"https://freetestapi.com/api/v1/books";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = _httpClient.Send(httpRequestMessage);

            var streamReader = new StreamReader(response.Content.ReadAsStream());

            var result = JsonConvert.DeserializeObject<List<Library>>(streamReader.ReadToEnd());

            return result;
        }

        private void OnClickIjara(object sender, RoutedEventArgs e)
        {
            RentWindow rentWindow = new RentWindow();
            rentWindow.Show();
        }

        private void OnClickAkkount(object sender, RoutedEventArgs e)
        {
            AccountWindow accountWindow = new AccountWindow();
            accountWindow.Show();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchText = searchTextBox.Text;

            Predicate<Library> predicate = delegate (Library emp)
            {

                if (emp.Citizenship is not null)
                {
                    if (emp.Citizenship.ToString().Contains(searchText))
                        return true;
                }

                else if (emp.BirthDay is not null)
                {
                    if (emp.BirthDay.ToString().Contains(searchText))
                        return true;
                }

                return false;
            };

            var searchBook = libraries.Where(book =>
                book.Id.ToString().Contains(searchText)||
                book.Title.Contains(searchText)||
                book.Author.Contains(searchText)||
                book.Genre.FirstOrDefault().Contains(searchText)||
                book.Description.Contains(searchText)||
                predicate.Invoke(book));

            bookDataGrid.ItemsSource = searchBook;
        }
    }
}
