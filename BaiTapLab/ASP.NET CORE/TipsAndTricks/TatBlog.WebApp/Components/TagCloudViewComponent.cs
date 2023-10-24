using Microsoft.AspNetCore.Mvc;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApp.Components
{
    public class TagCloudViewComponent : ViewComponent
    {
        private readonly IBlogRepository _blogRepository;

        public TagCloudViewComponent(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tags = await _blogRepository.GetAllTagsAsync();
            return View(tags);
        }
    }
}
