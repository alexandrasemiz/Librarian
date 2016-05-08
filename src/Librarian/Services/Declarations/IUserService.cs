using Librarian.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Services.Declarations
{
    public interface IUserService
    {
        Guid Create(RegisterViewModel model);
    }
}
