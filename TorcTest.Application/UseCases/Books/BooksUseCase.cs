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

        public async Task<List<string>> GetCategories()
        {
            var categories = await _ibookrepository.GetCategories();
            return categories;
        }

        public async Task<Domain.Entities.Books> GetBookById(int book_id)
        {
            var book = await _ibookrepository.GetBookById(book_id);
            return book;
        }

        public async Task<bool> Update(Domain.Entities.Books book)
        {
            if (book != null)
            {
                BooksChanged.Invoke(this, book);
                return await _ibookrepository.Update(book);
            }
           

            return false;
        }

        public event EventHandler<Domain.Entities.Books> BooksChanged;

        public void UpdateSuscriptor(object sender, Domain.Entities.Books book)
        {
            Console.WriteLine("request updated here we put the new update in an message Broker to apply even sourcing or exucute subtask");

        }

    }

        
}
