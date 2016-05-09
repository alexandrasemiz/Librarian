using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.ViewModels.Book
{
    public class BookRatingViewModel
    {
        public string BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public bool IsInLibrary { get; set; }
        public List<RatingViewModel> ratings { get; set; }
        public bool UserNotFound { get; set; }
        public bool BookNotFound { get; set; }
        public bool NoRating { get; set; }
    }
}
