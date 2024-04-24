using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorcTest.Domain.Entities;

namespace TorcTest.Application.UseCases.Books
{
    public interface IBooksUseCase
    {
        Task<bool> Create(Domain.Entities.Books books);
        Task<List<Domain.Entities.Books>> GetBooks();

        Task<List<string>> GetCategories();

        Task<List<Domain.Entities.Books>> GetBooksByFilter(string searchBy, string searchValue);

        Task<Domain.Entities.Books> GetBookById(int book_id);

        Task<bool> Update(Domain.Entities.Books book);

        void UpdateSuscriptor(object sender, Domain.Entities.Books book);

        public event EventHandler<Domain.Entities.Books> BooksChanged;

        Task<bool> Delete(int bookId);
    }
}
