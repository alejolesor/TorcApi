using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Services
{
    public class BooksService : IBooksServices
    {
        private RestClient _restClient;
        public List<Books> GetBooksAsync()
        {
            _restClient = new RestClient();
            var response = _restClient.GetBooks();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Se presento un Error");
                return null;
            }
            var json = response.Content.ReadAsStringAsync();
            List<Books> books = null;
            books = JsonConvert.DeserializeObject<List<Books>>(json.Result);

            return books;
        }
    }
}
