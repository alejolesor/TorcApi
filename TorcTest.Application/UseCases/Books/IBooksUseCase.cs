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
    }
}
