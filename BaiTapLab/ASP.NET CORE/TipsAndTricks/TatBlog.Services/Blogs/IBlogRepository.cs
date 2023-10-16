using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;

namespace TatBlog.Services.Blogs
{
    public interface IBlogRepository
    {
        Task<Post> GetPostAsync(int year, int month, string slug, CancellationToken cancellationToken = default);

        Task<IList<Post>> GetPopularArticlesAsync(int numPosts, CancellationToken cancellationToken = default);

        Task<bool> IsPostSlugExistedAsync(int postId, string slug, CancellationToken cancellationToken = default);

        Task IncreaseViewCountAsync(int postId, CancellationToken cancellationToken= default);

        Task<IList<CategoryItem>> GetCategoriesAsync(bool showOnMenu = false, CancellationToken cancellationToken = default);

        Task<IPagedList<TagItem>> GetPagedTagsAsync(IPagingParams pagingParams, CancellationToken cancellationToken = default);

        Task GetTagBySlugAsync(string slug, CancellationToken cancellationToken = default);

        Task<IList<TagItem>> GetAllTagsWithPostCountAsync(CancellationToken cancellationToken = default);

        Task DeleteTagAsync(int tagId, CancellationToken cancellationToken = default);

        Task GetCategoryBySlugAsync(string slug, CancellationToken cancellationToken = default);

        Task GetCategoryByIdAsync(int categoryId, CancellationToken cancellationToken = default);
    }
}
