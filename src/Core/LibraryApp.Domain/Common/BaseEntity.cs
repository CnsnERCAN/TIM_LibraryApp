using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{DD.MM.YYYY}")]
        public DateTime CreateDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{DD.MM.YYYY}")]
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
