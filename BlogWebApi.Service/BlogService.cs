using BlogWebApi.Data;
using BlogWebApi.Repo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Service
{
    public class BlogService : IBlogService
    {
        private IRepository<Blog> _blogRepository;
        public BlogService(IRepository<Blog> blogRepository)
        {
                _blogRepository = blogRepository;
        }
        public void Delete(Blog blog)
        {
            _blogRepository.Delete(blog);
        }

        public IEnumerable<Blog> GetAllPosts()
        {
            return _blogRepository.GetAllData();
        }

        public void Insert(Blog blog)
        {
            _blogRepository.Insert(blog);
        }

        public void IsConfirmUpdate(bool isConfirm, int Id)
        {
            var Post = _blogRepository.Get(Id);
            Post.IsConfirme = isConfirm;
            _blogRepository.Update(Post);
        }

        public void Update(Blog blog)
        {
            _blogRepository.Update(blog);
        }
    }
}
