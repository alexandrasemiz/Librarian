using Librarian.Services.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Librarian.DbModel.DataContext;
using Librarian.ViewModels.Account;
using Librarian.ViewModels.User;
using Librarian.DbModel.DbModel;

namespace Librarian.Services.Implementation
{    
    public class UserService: IUserService
    {
        private IDataContext _dataContext;
        public UserService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Guid Create (RegisterViewModel model)
        {
            CreateViewModel createModel = new CreateViewModel
            {
                Email = model.Email,
                Password = model.Password
            };
            User user = new User
            {
                Email = createModel.Email,
                Token = createModel.Password
            };
            _dataContext.Add<User>(user);
            _dataContext.Commit();
            return user.Id;
        }
    }
}
