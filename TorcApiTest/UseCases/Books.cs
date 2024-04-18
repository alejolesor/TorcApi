using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorcTest.Application.Repository;
using TorcTest.Application.UseCases.Books;
using TorcTest.Domain.Entities;
using Xunit;

namespace TorcApiTest.UseCases
{
    public class Books
    {

        [Fact]
        public async void TestCreateBook()
        {
            //Given
            var bookRequest = new TorcTest.Domain.Entities.Books()
            {
                BookId = 1,
                Tittle = "Pride and Prejudice",
                FirstName = "Jane",
                LastName = "Austen",
                TotalCopies = 2,
                CopiesInUse = 2,
                Type = "Hardcover",
                Isbn = "1234567891",
                Category = "fuction"


            };


            Mock<IBookRepository> IbookRepository = new Mock<IBookRepository>();
            IbookRepository.Setup(x => x.Create(bookRequest)).ReturnsAsync(true);
            BooksUseCase book = new BooksUseCase(IbookRepository.Object);

            //When
            var resultCreateBook = await book.Create(bookRequest);


            //Then
            Assert.True(resultCreateBook);
            IbookRepository.Verify(x => x.Create(bookRequest));
        }

        [Fact]
        public async void TestCreateBookFalse()
        {
            //Given
            var bookRequest = new TorcTest.Domain.Entities.Books()
            {
                BookId = 1,
                Tittle = "Pride and Prejudice",
                FirstName = "Jane",
                LastName = "Austen",
                TotalCopies = 2,
                CopiesInUse = 2,
                Type = "Hardcover",
                Isbn = "1234567891",
                Category = "fuction"


            };


            Mock<IBookRepository> IbookRepository = new Mock<IBookRepository>();
            IbookRepository.Setup(x => x.Create(bookRequest)).ReturnsAsync(false);
            BooksUseCase book = new BooksUseCase(IbookRepository.Object);

            //When
            var resultCreateBook = await book.Create(bookRequest);


            //Then
            Assert.False(resultCreateBook);
            IbookRepository.Verify(x => x.Create(bookRequest));
        }


        [Fact]
        public async void TestGetBooks()
        {
            //Given
            var bookRequest = new TorcTest.Domain.Entities.Books()
            {
                BookId = 1,
                Tittle = "Pride and Prejudice",
                FirstName = "Jane",
                LastName = "Austen",
                TotalCopies = 2,
                CopiesInUse = 2,
                Type = "Hardcover",
                Isbn = "1234567891",
                Category = "fuction"


            };

            var booksList = new List<TorcTest.Domain.Entities.Books>();
            booksList.Add(bookRequest);


            Mock<IBookRepository> IbookRepository = new Mock<IBookRepository>();
            IbookRepository.Setup(x => x.GetBooks()).ReturnsAsync(booksList);
            BooksUseCase book = new BooksUseCase(IbookRepository.Object);

            //When
            var books = await book.GetBooks();


            //Then
            Assert.NotNull(books);
            IbookRepository.Verify(x => x.GetBooks());
        }

        [Fact]
        public async void TestGetBooksByFilter()
        {
            //Given
            var bookRequest = new TorcTest.Domain.Entities.Books()
            {
                BookId = 1,
                Tittle = "Pride and Prejudice",
                FirstName = "Jane",
                LastName = "Austen",
                TotalCopies = 2,
                CopiesInUse = 2,
                Type = "Hardcover",
                Isbn = "1234567891",
                Category = "Fiction"


            };

            var booksList = new List<TorcTest.Domain.Entities.Books>();
            booksList.Add(bookRequest);


            Mock<IBookRepository> IbookRepository = new Mock<IBookRepository>();
            IbookRepository.Setup(x => x.GetBooksByFilter("Category", "Fiction")).ReturnsAsync(booksList);
            BooksUseCase book = new BooksUseCase(IbookRepository.Object);

            //When
            var books = await book.GetBooksByFilter("Category", "Fiction");


            //Then
            Assert.NotNull(books);
            IbookRepository.Verify(x => x.GetBooksByFilter("Category", "Fiction"));
        }
    }
}
