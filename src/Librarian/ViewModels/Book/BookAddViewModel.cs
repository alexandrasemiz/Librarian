using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.ViewModels.Book
{
    public class BookAddViewModel
    {
        public bool LibraryNotFound { get; set; }
        public bool BookInLibrary { get; set; }        
        public bool UserNotFound { get; set; }
        public bool Success { get; set; }
        public Guid Id { get; set; }
    }
}
