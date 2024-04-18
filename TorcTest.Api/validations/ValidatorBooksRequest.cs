using FluentValidation;
using TorcTest.Api.Request;

namespace TorcTest.Api.validations
{
    public class ValidatorBooksRequest : AbstractValidator<BooksRequest>
    {
        public ValidatorBooksRequest()
        {
            RuleFor(book => book.Tittle).NotNull().NotEmpty();
            RuleFor(book => book.FirstName).NotNull().NotEmpty();
            RuleFor(book => book.LastName).NotNull().NotEmpty();
            RuleFor(book => book.TotalCopies).NotNull().NotEmpty();
            RuleFor(book => book.CopiesInUse).NotNull().NotEmpty();

        }
    }
}
