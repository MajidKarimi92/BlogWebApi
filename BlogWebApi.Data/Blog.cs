using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Data
{
    [Table("Blog")]
    public class Blog : BaseEntity
    {
        public string? PostDescription { get; set; }
        public bool IsConfirme { get; set; }
        public string? AddedDate { get; set; }
        public string? ModifiedDate { get; set; }
    }
}
