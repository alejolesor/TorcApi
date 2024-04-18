using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorcTest.Application.Repository;
using TorcTest.Domain.Entities;
using TorcTest.Infrastructure.ConfigDB;
using TorcTest.Infrastructure.models;

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
                booksList.Add(new Domain.Entities.Books { BookId = item.Book_Id, Tittle = item.Tittle, FirstName = item.First_Name, 
                    LastName = item.Last_Name, TotalCopies = item.Total_Copies, CopiesInUse = item.Copies_in_use, Type = item.Type,
                Isbn = item.Isbn, Category = item.Category});
            }

            return booksList;
        }

        public async Task<List<string>> GetCategories()
        {
            var booksList = await _apiDbContext.Books.ToListAsync();

            var categories = booksList.Select(book => book.Category).Distinct().ToList();

            return categories;
        }
    }
}
