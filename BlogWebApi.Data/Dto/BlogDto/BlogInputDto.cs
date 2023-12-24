using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Data.Dto.BlogDto
{
    public class BlogInputDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PostDescription { get; set; }
    }
}
