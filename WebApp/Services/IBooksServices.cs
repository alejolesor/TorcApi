using WebApp.Models;

namespace WebApp.Services
{
    public interface IBooksServices
    {
        Task<List<Books>> GetBooksAsync();
        Task<bool> Create(Books books);

        Task<List<Books>> GetBooksByFilter(string SearchBy, string SearchValue);

        Task<Books> GetBookById(int bookId);

        Task<bool> Update(Books book);

        Task<bool> Delete(int bookId);
    }
}
