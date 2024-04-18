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
    }
}
