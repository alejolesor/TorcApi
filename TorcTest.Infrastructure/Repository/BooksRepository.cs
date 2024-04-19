using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorcTest.Application.Repository;
using TorcTest.Domain.Entities;
using TorcTest.Infrastructure.ConfigDB;
using TorcTest.Infrastructure.models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TorcTest.Infrastructure.Repository
{
    public class BooksRepository : IBookRepository
    {
        private ApiDbContext _apiDbContext;

        public BooksRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }
        public async Task<bool> Create(Domain.Entities.Books books)
        {

            _apiDbContext.Books.Add(new models.Books
            {
                Tittle = books.Tittle,
                First_Name = books.FirstName,
                Last_Name = books.LastName,
                Total_Copies = books.TotalCopies,
                Copies_in_use = books.CopiesInUse,
                Type = books.Type,
                Isbn = books.Isbn,
                Category = books.Category
            });
            var insert = await _apiDbContext.SaveChangesAsync();
            if (insert != 0)
            {
                return true;
            }

            return false;

        }

        public async Task<List<Domain.Entities.Books>> GetBooks()
        {
            var booksList = new List<Domain.Entities.Books>();
            var books = await _apiDbContext.Books.ToListAsync();

            if (books == null)
                return null;


            foreach (var item in books)
            {
                booksList.Add(new Domain.Entities.Books
                {
                    BookId = item.Book_Id,
                    Tittle = item.Tittle,
                    FirstName = item.First_Name,
                    LastName = item.Last_Name,
                    TotalCopies = item.Total_Copies,
                    CopiesInUse = item.Copies_in_use,
                    Type = item.Type,
                    Isbn = item.Isbn,
                    Category = item.Category
                });
            }

            var sortedList = booksList.OrderByDescending(book => book.BookId).ToList();

            return sortedList;
        }

        public async Task<List<Domain.Entities.Books>> GetBooksByFilter(string searchBy, string searchValue)
        {
            var booksList = new List<Domain.Entities.Books>();
            var books = await _apiDbContext.Books.ToListAsync();

            if (books == null)
                return null;


            foreach (var item in books)
            {
                booksList.Add(new Domain.Entities.Books
                {
                    BookId = item.Book_Id,
                    Tittle = item.Tittle,
                    FirstName = item.First_Name,
                    LastName = item.Last_Name,
                    TotalCopies = item.Total_Copies,
                    CopiesInUse = item.Copies_in_use,
                    Type = item.Type,
                    Isbn = item.Isbn,
                    Category = item.Category
                });
            }

            var filteredBooks = booksList.Where(book => book.GetType().GetProperty(searchBy).GetValue(book, null)?.ToString() == searchValue).
                ToList().OrderByDescending(book => book.BookId).ToList(); ;

            return filteredBooks;
        }

        public async Task<List<string>> GetCategories()
        {
            var booksList = await _apiDbContext.Books.ToListAsync();

            var categories = booksList.Select(book => book.Category).Distinct().ToList();

            return categories;
        }


        public async Task<Domain.Entities.Books> GetBookById(int bookId)
        {
            var booksList = new List<Domain.Entities.Books>();
            var book = _apiDbContext.Books.Where(book => book.Book_Id == bookId).First();

            if (book == null)
                return null;

            var bookDomain = new Domain.Entities.Books
            {
                BookId = book.Book_Id,
                Tittle = book.Tittle,
                FirstName = book.First_Name,
                LastName = book.Last_Name,
                TotalCopies = book.Total_Copies,
                CopiesInUse = book.Copies_in_use,
                Type = book.Type,
                Isbn = book.Isbn,
                Category = book.Category
            };

            return bookDomain;
        }

        public async Task<bool> Update(Domain.Entities.Books book)
        {

            var bookToUpdate = _apiDbContext.Books.FirstOrDefault(b => b.Book_Id == book.BookId);
            if (book == null)
                return false;


            bookToUpdate.Book_Id = book.BookId;
            bookToUpdate.Tittle = book.Tittle;
            bookToUpdate.First_Name = book.FirstName;
            bookToUpdate.Last_Name = book.LastName;
            bookToUpdate.Total_Copies = book.TotalCopies;
            bookToUpdate.Copies_in_use = book.CopiesInUse;
            bookToUpdate.Type = book.Type;
            bookToUpdate.Isbn = book.Isbn;
            bookToUpdate.Category = book.Category;


            _apiDbContext.Books.Update(bookToUpdate);

            var updated = await _apiDbContext.SaveChangesAsync();

            if (updated != 0)
            {
                return true;
            }

            return false;
        }

    }
}
