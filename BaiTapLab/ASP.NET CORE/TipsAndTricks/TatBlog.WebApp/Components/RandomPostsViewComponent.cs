using Microsoft.AspNetCore.Mvc;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApp.Components
{
    public class RandomPostsViewComponent : ViewComponent
    {
        private readonly IBlogRepository _blogRepository;

        public RandomPostsViewComponent(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var randomPosts = await _blogRepository.GetRandomPostsAsync(5);
            return View(randomPosts);
        }
    }
}
