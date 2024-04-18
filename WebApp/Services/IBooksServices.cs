using WebApp.Models;

namespace WebApp.Services
{
    public interface IBooksServices
    {
        List<Books> GetBooksAsync();
    }
}
