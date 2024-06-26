﻿using Microsoft.AspNetCore.Mvc;
using TorcTest.Api.Request;
using TorcTest.Application.UseCases.Books;

namespace TorcTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class BooksController : Controller
    {
        private readonly IBooksUseCase _IbooksUseCase;

        public BooksController(IBooksUseCase ibooksUseCase)
        {
            _IbooksUseCase = ibooksUseCase;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(BooksRequest request)
        {
            try
            {
                var result = await _IbooksUseCase.Create(new Domain.Entities.Books()
                {
                    Tittle = request.Tittle,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    TotalCopies = request.TotalCopies,
                    CopiesInUse = request.CopiesInUse,
                    Type = request.Type,
                    Isbn = request.Isbn,
                    Category = request.Category,
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                //logger errors
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getbooks")]
        public async Task<IActionResult> GetBooks()
        {
            var booksList = await _IbooksUseCase.GetBooks();
            return Ok(booksList);

        }

        [HttpGet]
        [Route("getcategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categoriesList = await _IbooksUseCase.GetCategories();
            return Ok(categoriesList);

        }

        [HttpGet]
        [Route("getbooks/filter")]
        public async Task<IActionResult> GetBooksByFilter(string searchBy, string searchValue)
        {
            var booksList = await _IbooksUseCase.GetBooksByFilter(searchBy, searchValue);
            return Ok(booksList);

        }

        [HttpGet]
        [Route("getbooks/byId")]
        public async Task<IActionResult> GetBooksByFilter(int bookId)
        {
            var book = await _IbooksUseCase.GetBookById(bookId);
            return Ok(book);

        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(BooksRequest request)
        {
            var book = new Domain.Entities.Books()
            {
                BookId = request.BookId,
                Tittle = request.Tittle,
                FirstName = request.FirstName,
                LastName = request.LastName,
                TotalCopies = request.TotalCopies,
                CopiesInUse = request.CopiesInUse,
                Type = request.Type,
                Isbn = request.Isbn,
                Category = request.Category,
            };


            _IbooksUseCase.BooksChanged += _IbooksUseCase.UpdateSuscriptor;

            var result = await _IbooksUseCase.Update(book);
            return Ok(result);

        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int bookId)
        {
            var booksList = await _IbooksUseCase.Delete(bookId);
            return Ok(booksList);

        }

    }
}
