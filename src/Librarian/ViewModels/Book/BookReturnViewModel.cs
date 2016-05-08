using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.ViewModels.Book
{
    public class BookReturnViewModel
    {
        public bool BookInLibrary { get; set; }
        public bool BookNotFound { get; set; }
        public bool UserNotFound { get; set; }
    }
}
