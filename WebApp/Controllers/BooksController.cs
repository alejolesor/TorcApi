﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Buffers;
using System.Security.Cryptography.Xml;
using WebApp.Models;
using WebApp.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksServices _booksService;

        public BooksController(IBooksServices booksService)
        {
            _booksService = booksService;
        }
        public async Task<IActionResult> Index(string searchBy, string searchValue)
        {
            if (searchBy != null && searchValue != null)
            {
                var booksListFiltered = await _booksService.GetBooksByFilter(searchBy, searchValue);
                if (booksListFiltered == null) {
                    return View(new List<Books>() { new Books() { } });
                }
                return View(booksListFiltered);
            }
            else {
                var booksList = await _booksService.GetBooksAsync();
                if (booksList == null)
                {
                    return View(new List<Books>() { new Books() { } });
                }
                return View(booksList);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateBook(Books books)
        {
            var resultCreate = await _booksService.Create(books);

            return RedirectToAction("index");
        }



        public async Task<IActionResult> Edit(int bookId)
        {
            var book = await _booksService.GetBookById(bookId);
            if (book == null)
            {
                return View(new Books() {});
            }
            return View(book);
        }

        public async Task<IActionResult> Update(Books books)
        {
            var resultCreate = await _booksService.Update(books);

            return RedirectToAction("index");

        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult DeleteItem(int bookId)
        {
            _booksService.Delete(bookId);

            return RedirectToAction("index");

        }
    }
}
