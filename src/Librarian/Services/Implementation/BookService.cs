using Librarian.DbModel.DataContext;
using Librarian.DbModel.DbModel;
using Librarian.Services.Declarations;
using Librarian.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IDataContext _dataContext;
        public BookService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<BookViewModel> GetBooksFromLibrary(string libraryId)
        {
            Guid libraryGuid;
            Guid.TryParse(libraryId, out libraryGuid);
            List<Book> booksEntity = _dataContext.GetQuery<Book>().Where(x => x.LibraryId == libraryGuid).ToList();
            List<BookViewModel> booksVm = new List<BookViewModel>();
            if (booksEntity != null)
            {
                foreach (Book bookEntity in booksEntity)
                {
                    BookViewModel bookVm = new BookViewModel { Id = bookEntity.Id.ToString(), Name = bookEntity.Name, Author = bookEntity.Author, IsInLibrary = bookEntity.IsInLibrary };
                    booksVm.Add(bookVm);
                }
            }
            return booksVm;
        }
        public BookTakeViewModel Take(string bookId, string userName)
        {
            User user = _dataContext.GetQuery<User>().Where(x => x.Email == userName).FirstOrDefault();
            if (user == null) return new BookTakeViewModel { UserNotFound = true };
            Guid bookGuid;
            Guid.TryParse(bookId, out bookGuid);
            Book book = _dataContext.GetQuery<Book>().Where(x => x.Id == bookGuid).FirstOrDefault();
            if (book == null) return new BookTakeViewModel { BookNotFound = true };
            if (book.IsInLibrary == false)
            {
                History newRecord = new History { UserId = user.Id, BookId = book.Id, DateTake = DateTime.UtcNow, Success = false };
                _dataContext.Add<History>(newRecord);
                _dataContext.Commit();
                return new BookTakeViewModel { BookInLibrary = false, BookNotFound = false, UserNotFound = false };
            }
            else
            {
                book.IsInLibrary = false;
                History newRecord = new History { UserId = user.Id, BookId = book.Id, DateTake = DateTime.UtcNow, Success = true };
                _dataContext.Add<History>(newRecord);
                _dataContext.Commit();
                return new BookTakeViewModel { BookInLibrary = true, BookNotFound = false, UserNotFound = false };
            }
        }
        public BookReturnViewModel Return(string bookId, string userName)
        {
            User user = _dataContext.GetQuery<User>().Where(x => x.Email == userName).FirstOrDefault();
            if (user == null) return new BookReturnViewModel { UserNotFound = true };
            Guid bookGuid;
            Guid.TryParse(bookId, out bookGuid);
            Book book = _dataContext.GetQuery<Book>().Where(x => x.Id == bookGuid).FirstOrDefault();
            if (book == null) return new BookReturnViewModel { BookNotFound = true };
            if (book.IsInLibrary == true)
            {
                History newHistory = new History { UserId = user.Id, BookId = book.Id, DatePut = DateTime.UtcNow, Success = false };
                _dataContext.Add<History>(newHistory);
                _dataContext.Commit();
                return new BookReturnViewModel { BookInLibrary = true, BookNotFound = false, UserNotFound = false };
            }
            else
            {
                book.IsInLibrary = true;
                History newHistory = new History { UserId = user.Id, BookId = book.Id, DatePut = DateTime.UtcNow, Success = true };
                _dataContext.Add<History>(newHistory);
                DateTime? dateTake = _dataContext.GetQuery<History>().Where(x => x.UserId == user.Id && (x.BookId == book.Id) && (x.DateTake != null) && (x.Success == true)).Select(x => x.DateTake).FirstOrDefault();
                if (dateTake != null)
                {
                    Decimal speedRead = ((DateTime)newHistory.DatePut).Subtract((DateTime)dateTake).Days;
                    Statistics newStatistic = new Statistics { UserId = user.Id, BookId = book.Id, Date = DateTime.UtcNow, SpeedRead = speedRead };
                    _dataContext.Add<Statistics>(newStatistic);
                }
                _dataContext.Commit();
                return new BookReturnViewModel { BookInLibrary = false, BookNotFound = false, UserNotFound = false, BookId = book.Id, BookName = book.Name, BookAuthor = book.Author };
            }
        }
        public BookEstimateViewModel Estimate(string bookId, string userName, string ratingMark = "", string ratingComment = "")
        {
            User user = _dataContext.GetQuery<User>().Where(x => x.Email == userName).FirstOrDefault();
            if (user == null) return new BookEstimateViewModel { UserNotFound = true };
            Guid bookGuid;
            Guid.TryParse(bookId, out bookGuid);
            Book book = _dataContext.GetQuery<Book>().Where(x => x.Id == bookGuid).FirstOrDefault();
            if (book == null) return new BookEstimateViewModel { BookNotFound = true };
            Rating newRating = new Rating { BookId = book.Id, UserId = user.Id, Date = DateTime.UtcNow, RatingMark = Convert.ToInt32(ratingMark), Comment = ratingComment };
            _dataContext.Add<Rating>(newRating);
            _dataContext.Commit();
            return new BookEstimateViewModel { Success = true, BookNotFound = false, UserNotFound = false };
        }
        public BookAddViewModel Add(string bookName, string bookAuthor, string userName)
        {
            User user = _dataContext.GetQuery<User>().Where(x => x.Email == userName).FirstOrDefault();
            if (user == null) return new BookAddViewModel { UserNotFound = true };
            Library konig = _dataContext.GetQuery<Library>().Where(x => x.Name == "KONIG-LABS").FirstOrDefault();
            if (konig == null) return new BookAddViewModel { LibraryNotFound = true };
            Book newBook = new Book { Name = bookName, Author = bookAuthor, IsInLibrary = true, LibraryId = konig.Id };
            _dataContext.Add<Book>(newBook);
            _dataContext.Commit();
            return new BookAddViewModel { Success = true, UserNotFound = false, Id = newBook.Id, BookInLibrary = true };
        }
        public BookRatingViewModel GetRating(string bookId, string userName)
        {
            User user = _dataContext.GetQuery<User>().Where(x => x.Email == userName).FirstOrDefault();
            if (user == null) return new BookRatingViewModel { UserNotFound = true };
            Guid bookGuid;
            Guid.TryParse(bookId, out bookGuid);
            Book book = _dataContext.GetQuery<Book>().Where(x => x.Id == bookGuid).FirstOrDefault();
            if (book == null) return new BookRatingViewModel { BookNotFound = true };            
            List<Rating> ratings = _dataContext.GetQuery<Rating>().Where(x => x.BookId == bookGuid).ToList();
            if (ratings == null) return new BookRatingViewModel {BookName=book.Name, BookAuthor=book.Author, NoRating = true };
            List<RatingViewModel> ratingsVm = new List<RatingViewModel>();
            foreach (var rating in ratings)
            {
                RatingViewModel ratingVm = new RatingViewModel { RatingMark = rating.RatingMark, RatingComment = rating.Comment };
                ratingsVm.Add(ratingVm);
            }
            return new BookRatingViewModel { BookId=book.Id.ToString(),BookName = book.Name, BookAuthor = book.Author,IsInLibrary=book.IsInLibrary, NoRating = false, ratings = ratingsVm };
        }
    }
}
