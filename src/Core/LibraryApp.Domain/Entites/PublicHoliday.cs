using LibraryApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Entites
{
    public class PublicHoliday : BaseEntity
    {
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{DD.MM.YYYY}")]
        public DateTime Holiday { get; set; }
        public string Description { get; set; }
    }
}
