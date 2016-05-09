using Librarian.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Services.Declarations
{
    public interface IBookService
    {
        List<BookViewModel> GetBooksFromLibrary(string libraryId);
        BookTakeViewModel Take(string bookId, string userName);
        BookReturnViewModel Return(string bookId, string userName);
        BookEstimateViewModel Estimate(string bookId, string userName, string ratingMark="", string ratingComment="");
        BookAddViewModel Add(string bookName, string bookAuthor, string userName);
        BookRatingViewModel GetRating(string bookId, string userName);
    }
}
