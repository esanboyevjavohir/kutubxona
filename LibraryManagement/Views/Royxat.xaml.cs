using LibraryManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace LibraryManagement.Views
{
    /// <summary>
    /// Interaction logic for Royxat.xaml
    /// </summary>
    public partial class Royxat : Window
    {
        private readonly HttpClient _httpClient;
        public List<Library> stories { get; set; }

        public Royxat()
        {
            _httpClient = new HttpClient();

            stories = GetStory();

            InitializeComponent();

            royxatDataGrid.ItemsSource = null;
            royxatDataGrid.ItemsSource = stories.Select(book =>
            new LibraryView()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre.FirstOrDefault(),
                Description = book.Description
            });
        }

        private List<Library> GetStory()
        {
            var url = $"https://freetestapi.com/api/v1/books?limit=10";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = _httpClient.Send(httpRequestMessage);

            var streamReader = new StreamReader(response.Content.ReadAsStream());

            var result = JsonConvert.DeserializeObject<List<Library>>(streamReader.ReadToEnd());

            return result;
        }
    }
}
