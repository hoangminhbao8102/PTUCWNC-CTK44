using Microsoft.AspNetCore.Mvc;
using TatBlog.Core.DTO;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        /*public IActionResult Index()
        {
            ViewBag.CurrentTime = DateTime.Now.ToString("HH:mm:ss");

            return View();
        }*/

        public async Task<IActionResult> Index([FromQuery(Name = "k")] string keyword = null, [FromQuery(Name = "p")] int pageNumber = 1, [FromQuery(Name = "ps")] int pageSize = 10)
        {
            var postQuery = new PostQuery()
            {
                PublishedOnly = true,
                Keyword = keyword
            };

            var postsList = await _blogRepository.GetPagedPostsAsync(postQuery, pageNumber, pageSize);

            ViewBag.PostQuery = postsList;

            return View(postsList);
        }

        public async Task<IActionResult> Category(string slug)
        {
            var posts = await _blogRepository.GetCategoryAsync(slug);

            return View(posts);
        }

        public async Task<IActionResult> Author(string slug)
        {
            var posts = await _blogRepository.GetAuthorAsync(slug);

            return View(posts);
        }

        public async Task<IActionResult> Tag(string slug)
        {
            var posts = await _blogRepository.GetTagAsync(slug);

            return View(posts);
        }

        public async Task<IActionResult> Post(int year, int month, int day, string slug)
        {
            var post = await _blogRepository.GetPostAsync(year, month, day, slug);

            if (post == null || !post.Published)
            {
                return NotFound();
            }

            post.ViewCount++;
            await _blogRepository.UpdatePostAsync(post);

            return View(post);
        }

        public async Task<IActionResult> Archives(int year, int month)
        {
            PostQuery query = new PostQuery
            {
                Year = year,
                Month = month
            };

            var posts = await _blogRepository.GetPostBySlugAsync("");

            ViewData["PostQuery"] = query;

            return View(posts);
        }

        public IActionResult About() => View();

        public IActionResult Contact() => View();

        public IActionResult Rss() => Content("Nội dung sẽ được cập nhật");
    }
}
