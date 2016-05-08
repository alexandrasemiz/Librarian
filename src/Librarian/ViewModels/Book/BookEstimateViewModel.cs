using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.ViewModels.Book
{
    public class BookEstimateViewModel
    {        
        public bool BookNotFound { get; set; }
        public bool UserNotFound { get; set; }
        public bool Success { get; set; }
    }
}
