using LibraryApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Entites
{
    public class Member : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<BookTransaction> Transactions { get; set; }
    }
}
