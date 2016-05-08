using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.ViewModels.Book
{
    public class BookViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }        
        public bool IsInLibrary { get; set; }
    }
}
