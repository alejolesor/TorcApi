using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TorcTest.Application.Repository;
using TorcTest.Domain.Entities;

namespace TorcTest.Application.UseCases.Books
{
    public class BooksUseCase : IBooksUseCase
    {
        private readonly IBookRepository _ibookrepository;
        public BooksUseCase(IBookRepository bookRepository)
        {
            _ibookrepository = bookRepository;
        }


        public async Task<bool> Create(Domain.Entities.Books books)
        {
            var bookCreated = await _ibookrepository.Create(books);
            return bookCreated;
        }

        public async Task<List<Domain.Entities.Books>> GetBooks()
        {
            var booksList = await _ibookrepository.GetBooks();
            return booksList;
        }

        public async Task<List<Domain.Entities.Books>> GetBooksByFilter(string searchBy, string searchValue)
        {
           var booksListFiltered = await _ibookrepository.GetBooksByFilter(searchBy, searchValue);
            return booksListFiltered;
        }

        public Task<List<string>> GetCategories()
        {
            var categories = _ibookrepository.GetCategories();
            return categories;
        }
    }
}
