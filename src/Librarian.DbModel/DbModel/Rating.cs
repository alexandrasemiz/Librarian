using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.DbModel.DbModel
{
    public class Rating
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public int RatingMark { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
