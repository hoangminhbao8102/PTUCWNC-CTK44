using Microsoft.AspNetCore.Mvc;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApp.Components
{
    public class BestAuthorsViewComponent : ViewComponent
    {
        private readonly IBlogRepository _blogRepository;

        public BestAuthorsViewComponent(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var bestAuthors = await _blogRepository.GetBestAuthorsAsync(4);
            return View(bestAuthors);
        }
    }
}
