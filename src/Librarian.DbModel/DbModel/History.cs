using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.DbModel.DbModel
{
    public class History
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime? DateTake { get; set; }
        public DateTime? DatePut { get; set; }
        public bool Success { get; set; }
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
