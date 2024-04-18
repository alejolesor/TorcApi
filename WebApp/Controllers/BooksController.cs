using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksServices _booksService;

        public BooksController(IBooksServices booksService)
        {
            _booksService = booksService;
        }
        public IActionResult Index()
        {
            var booksList = _booksService.GetBooksAsync();
            return View(booksList);
        }
    }
}
