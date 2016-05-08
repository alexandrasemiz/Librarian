using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.DbModel.DataContext
{
    public interface IDataContext
    {
        IQueryable<T> GetQuery<T>() where T: class;
        void Add<T>(T item) where T : class;
        void Remove<T>(T item) where T : class;
        void Commit();        
    }
}
