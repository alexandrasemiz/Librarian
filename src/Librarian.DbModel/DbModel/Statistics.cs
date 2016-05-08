using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.DbModel.DbModel
{
    public class Statistics
    {
        public Guid Id { get; set; }
        public Guid UserId {get;set;}
        public Guid BookId { get; set; }
        public DateTime Date { get; set; }
        public decimal SpeedRead { get; set; }
        public virtual User User { get; set; }
        public virtual  Book Book { get; set; }

    }
}
