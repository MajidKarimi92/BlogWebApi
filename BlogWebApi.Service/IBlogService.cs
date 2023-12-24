using BlogWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Service
{
    public interface IBlogService
    {
        IEnumerable<Blog> GetAllPosts();
        void Insert(Blog blog);
        void Update(Blog blog);
        void Delete(Blog blog);
        void IsConfirmUpdate(bool isConfirm, int Id);
    }
}
