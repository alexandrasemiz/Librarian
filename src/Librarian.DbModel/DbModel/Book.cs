using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.DbModel.DbModel
{
    public class Book
    {        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }        
        public bool IsInLibrary { get; set; }
        public Guid LibraryId { get; set; }
        public virtual Library Library { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Statistics> Statisticses{ get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
