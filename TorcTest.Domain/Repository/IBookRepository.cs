using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorcTest.Domain.Entities;

namespace TorcTest.Application.Repository
{
    public interface IBookRepository
    {
        Task<bool> Create(Books books);

        Task<List<Books>> GetBooks();

        Task<List<string>> GetCategories();

        Task<List<Books>> GetBooksByFilter(string searchBy, string searchValue);

        Task<Books> GetBookById(int bookId);

        Task<bool> Update(Books book);

        Task<bool> Delete(int bookId);
    }
}
