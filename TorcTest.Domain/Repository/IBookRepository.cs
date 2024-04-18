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

        Task<List<Domain.Entities.Books>> GetBooks();

        Task<List<string>> GetCategories();
    }
}
