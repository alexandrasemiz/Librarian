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
using Librarian.Services.Declarations;
using Librarian.ViewModels.Library;

namespace Librarian.Controllers
{
    public class LibraryController : Controller
    {
        private ILibraryService _libraryService;
        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        [HttpGet]
        public IActionResult Main()
        {
            List<LibraryViewModel> libsVm=_libraryService.GetAllLibraries();
            return View(libsVm);
        }
    }
}
