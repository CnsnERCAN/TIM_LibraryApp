using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Dto
{
    public class TransactionViewDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public BookReadDto Book { get; set; }
        public MemberReadDto Member { get; set; }
        public DateTime CheckInDate { get; set; }

    }
}
