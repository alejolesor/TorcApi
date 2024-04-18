using WebApp.Models;

namespace WebApp.Services
{
    public class RestClient
    {
        string urlApi = "https://localhost:7152/Books/";
        public HttpResponseMessage GetBooks()
        {
            var endpoint = urlApi + "getbooks";
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            client.Dispose();
            return response;
        }

        public HttpResponseMessage CreateBook(Books book)
        {
            var endpoint = urlApi + "create";
            var client = new HttpClient();
            var response = client.PostAsJsonAsync(endpoint, book).Result;
            client.Dispose();
            return response;
        }

        public HttpResponseMessage GetBooksByFilter(string SearchBy, string SearchValue)
        {
            var endpoint = urlApi + $"getbooks/filter?searchBy={SearchBy}&SearchValue={SearchValue}";
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            client.Dispose();
            return response;
        }
    }
}
