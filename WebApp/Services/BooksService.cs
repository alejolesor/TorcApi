using Newtonsoft.Json;
using System.Buffers;
using WebApp.Models;

namespace WebApp.Services
{
    public class BooksService : IBooksServices
    {
        private RestClient _restClient;

        public async Task<bool> Create(Books book)
        {
            _restClient = new RestClient();
            var response = _restClient.CreateBook(book);
            var resp = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("There was an Error");
                return false;
            }
            return true;
        }

        public async Task<List<Books>> GetBooksAsync()
        {
            _restClient = new RestClient();
            var response = _restClient.GetBooks();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("There was an Error");
                return null;
            }
            var json = await response.Content.ReadAsStringAsync();
            List<Books> books = null;
            books = JsonConvert.DeserializeObject<List<Books>>(json);

            return books;
        }

        public async Task<List<Books>> GetBooksByFilter(string SearchBy, string SearchValue)
        {
            _restClient = new RestClient();
            var response = _restClient.GetBooksByFilter(SearchBy, SearchValue);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("There was an Error");
                return null;
            }
            var json = await response.Content.ReadAsStringAsync();
            List<Books> books = null;
            books = JsonConvert.DeserializeObject<List<Books>>(json);

            return books;
        }

        public async Task<Books> GetBookById(int bookId)
        {
            _restClient = new RestClient();
            var response = _restClient.GetBookById(bookId);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("There was an Error");
                return null;
            }
            var json = await response.Content.ReadAsStringAsync();
            Books book = null;
            book = JsonConvert.DeserializeObject<Books>(json);

            return book;
        }

        public async Task<bool> Update(Books book)
        {
            _restClient = new RestClient();
            var response = _restClient.Update(book);
            var resp = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("There was an Error");
                return false;
            }
            return true;
        }
    }
}
