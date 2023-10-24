using Microsoft.AspNetCore.Mvc;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApp.Components
{
    public class ArchivesViewComponent : ViewComponent
    {
        private readonly IBlogRepository _blogRepository;

        public ArchivesViewComponent(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var archives = await _blogRepository.GetArchivesAsync();
            return View(archives);
        }
    }
}
