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

        public IActionResult Index()
        {
            ViewBag.CurrentTime = DateTime.Now.ToString("HH:mm:ss");

            return View();
        }

        public async Task<IActionResult> Index(
            [FromQuery(Name = "p")] int pageNumber = 1,
            [FromQuery(Name = "ps")] int pageSize = 10)
        {
            var postQuery = new PostQuery()
            {
                PublishedOnly = true
            };

            var postsList = await _blogRepository
                .GetPagedPostsAsync(postQuery, pageNumber, pageSize);

            ViewBag.PostQuery = postQuery;

            return View(postsList);
        }

        public async Task<IActionResult> Index(
            [FromQuery(Name = "k")] string keyword = "",
            [FromQuery(Name = "p")] int pageNumber = 1,
            [FromQuery(Name = "ps")] int pageSize = 10)
        {
            var postQuery = new PostQuery()
            {
                PublishedOnly = true,
                Keyword = keyword
            };

            var postsList = await _blogRepository
                .GetPagedPostsAsync(postQuery, pageNumber, pageSize);

            ViewBag.PostQuery = postQuery;

            return View(postsList);
        }

        public async Task<IActionResult> Category(string slug, int pageNumber = 1, int pageSize = 10)
        {
            var postQuery = new PostQuery()
            {
                PublishedOnly = true,
                CategorySlug = slug
            };

            var postsList = await _blogRepository.GetPagedPostsAsync(postQuery, pageNumber, pageSize);

            ViewBag.PostQuery = postQuery;

            return View(postsList);
        }

        public async Task<IActionResult> Author(string slug, int pageNumber = 1, int pageSize = 10)
        {
            var postQuery = new PostQuery()
            {
                PublishedOnly = true,
                AuthorSlug = slug
            };

            var postsList = await _blogRepository.GetPagedPostsAsync(postQuery, pageNumber, pageSize);

            ViewBag.PostQuery = postQuery;

            return View(postsList);
        }

        public async Task<IActionResult> Tag(string slug, int pageNumber = 1, int pageSize = 10)
        {
            var postQuery = new PostQuery()
            {
                PublishedOnly = true,
                TagSlug = slug
            };

            var postsList = await _blogRepository.GetPagedPostsAsync(postQuery, pageNumber, pageSize);

            ViewBag.PostQuery = postQuery;

            return View(postsList);
        }

        public async Task<IActionResult> Post(int year, int month, int day, string slug)
        {
            var post = await _blogRepository.GetPostBySlugAsync(slug);

            if (post == null || !post.Published)
            {
                return NotFound();
            }

            // Tăng số lượt xem của bài viết
            post.ViewCount++;
            await _blogRepository.UpdatePostAsync(post);

            return View(post);
        }

        public async Task<IActionResult> Archives(int year, int month, int pageNumber = 1, int pageSize = 10)
        {
            var postQuery = new PostQuery()
            {
                PublishedOnly = true,
                Year = year,
                Month = month
            };

            var postsList = await _blogRepository.GetPagedPostsAsync(postQuery, pageNumber, pageSize);

            ViewBag.PostQuery = postQuery;

            return View(postsList);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Rss() => Content("Nội dung sẽ được cập nhật");
    }
}
