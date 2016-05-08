using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.DbModel.DbModel
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Statistics> Statisticses { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
