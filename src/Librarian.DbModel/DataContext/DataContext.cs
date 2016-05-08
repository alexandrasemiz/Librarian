using Librarian.DbModel.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.DbModel.DataContext
{
    public class DataContext: IDataContext
    {
        private DbModelConfiguration _entities;
        public DataContext()
        {
            _entities = new DbModelConfiguration();
        }
        public IQueryable<T> GetQuery<T>() where T : class
        {
            return _entities.Set<T>();
        }
        public void Add<T>(T item) where T : class
        {
            _entities.Add<T>(item);            
        }
        public void Remove<T>(T item) where T : class
        {
            _entities.Remove<T>(item);
        }
        public void Commit()
        {
            _entities.SaveChanges();
        }
    }
}
