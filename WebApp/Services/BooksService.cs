using Newtonsoft.Json;
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
    }
}
