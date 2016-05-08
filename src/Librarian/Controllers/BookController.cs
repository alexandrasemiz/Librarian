using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using Librarian.Models;
using Librarian.Services;
using Librarian.ViewModels.Account;
using Librarian.ViewModels.Book;
using Librarian.Services.Declarations;

namespace Librarian.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        [Authorize]
       public IActionResult List(string libraryId)
        {
            List<BookViewModel> books=_bookService.GetBooksFromLibrary(libraryId);
            if (books == null) return HttpNotFound();
            return Json(new { Success = true, Data = books });
        }
        [HttpPost]
        [Authorize]
        public IActionResult Take(string bookId)
        {
            string userName = HttpContext.User.Identity.Name;
            BookTakeViewModel result=_bookService.Take(bookId, userName);
            if (result.UserNotFound == true) return HttpNotFound();
            if (result.BookNotFound == true) return HttpNotFound();
            if (result.BookInLibrary == false) {
                return Json(new { Success = false, Message = "В данный момент книга на руках." });
            }            
            return Json(new { Success = true, Message="Возьмите книгу в офисе. Приятного чтения." });
        }
        [HttpPost]
        [Authorize]
        public IActionResult Return(string bookId)
        {
            string userName = HttpContext.User.Identity.Name;
            BookReturnViewModel result = _bookService.Return(bookId, userName);
            if (result.UserNotFound == true) return HttpNotFound();
            if (result.BookNotFound == true) return HttpNotFound();
            if (result.BookInLibrary == true)
            {
                return Json(new { Success = false, Message = "Книга в библиотеке." });
            }
            return Json(new { Success = true, Message = "Спасибо, что вернули книгу." });            
        }
        [HttpPost]
        [Authorize]
        public IActionResult Estimate (string bookId, string ratingMark="", string ratingComment="")
        {
            string userName = HttpContext.User.Identity.Name;
            BookEstimateViewModel result = _bookService.Estimate(bookId, userName, ratingMark, ratingComment);
            if (result.UserNotFound == true) return HttpNotFound();
            if (result.BookNotFound == true) return HttpNotFound();
            if (result.Success == true)
                return Json(new { Success = true, Message = "Спасибо за вашу оценку!" });
            return Json(new { Success = false, Message = "Не удалось записать оценку." });
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult Add(string bookName, string bookAuthor)
        {
            string userName = HttpContext.User.Identity.Name;
            BookAddViewModel result = _bookService.Add(bookName, bookAuthor, userName);
            if (result.UserNotFound == true) return HttpNotFound();            
            if (result.Success == true)
                return Json(new { Success = true, Message = "Спасибо за новую книгу!" });
            return Json(new { Success = false, Message = "Не удалось добавить книгу." });
        }
    }
}
