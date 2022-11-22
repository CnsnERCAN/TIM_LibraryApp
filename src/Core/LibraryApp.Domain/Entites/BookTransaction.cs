using LibraryApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Entites
{
    public class BookTransaction : BaseEntity
    {
        public Book Book { get; set; }

        public int BookId { get; set; }

        public Member Member { get; set; }

        public int MemberId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{DD.MM.YYYY}")]
        public DateTime CheckInDate { get; set; }
    }
}
