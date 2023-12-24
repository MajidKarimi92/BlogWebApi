using BlogWebApi.Data;
using BlogWebApi.Data.Dto.BlogDto;
using BlogWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }


        
        [Route("AllPosts")]
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IEnumerable<Blog> AllPosts()
        { 
            return _blogService.GetAllPosts();
        }

        [Route("ChangeStatePost")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public BlogOutputDto ChangeStatePost(int id, bool state)
        {
            _blogService.IsConfirmUpdate(state, id);
            return new BlogOutputDto() { Message = "تغییر وضعیت پست با موفقیت انجام شد"};
        }

        [Route("InsertPost")]
        [HttpPost]
        [Authorize(Roles = "Administrator, User")]
        public BlogOutputDto InsertPost(Blog blog)
        {
            _blogService.Insert(blog);
            return new BlogOutputDto() { Message = "اضافه سازی پست با موفقیت انجام شد" };
        }

        [Route("UpdatePost")]
        [HttpPost]
        [Authorize(Roles = "Administrator, User")]
        public BlogOutputDto UpdatePost(Blog blog)
        {
            _blogService.Update(blog);
            return new BlogOutputDto() { Message = "اضافه سازی پست با موفقیت انجام شد" };
        }

        [Route("DeletePost")]
        [HttpPost]
        [Authorize(Roles = "Administrator, User")]
        public BlogOutputDto DeletePost(Blog blog)
        {
            _blogService.Insert(blog);
            return new BlogOutputDto() { Message = "اضافه سازی پست با موفقیت انجام شد" };
        }
    }

   
}
