using WebApp.Models;

namespace WebApp.Services
{
    public interface IBooksServices
    {
        Task<List<Books>> GetBooksAsync();
        Task<bool> Create(Books books);

        Task<List<Books>> GetBooksByFilter(string SearchBy, string SearchValue);
    }
}
