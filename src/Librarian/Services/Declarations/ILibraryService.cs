using Librarian.ViewModels.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Services.Declarations
{
    public interface ILibraryService
    {
        List<LibraryViewModel> GetAllLibraries();
    }
}
