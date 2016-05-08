using Librarian.DbModel.DataContext;
using Librarian.DbModel.DbModel;
using Librarian.Services.Declarations;
using Librarian.ViewModels.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Services.Implementation
{
    public class LibraryService: ILibraryService
    {
        private readonly IDataContext _dataContext;
        public LibraryService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<LibraryViewModel> GetAllLibraries()
        {
            List<Library> libsEntities= _dataContext.GetQuery<Library>().ToList();
            List<LibraryViewModel> libsVm = new List<LibraryViewModel>();
            if (libsEntities != null)
            {
                foreach(var libEntity in libsEntities)
                {
                    LibraryViewModel libVm = new LibraryViewModel { Name = libEntity.Name , Id=libEntity.Id};
                    libsVm.Add(libVm);
                }
            }
            return libsVm;
        }
    }
}
