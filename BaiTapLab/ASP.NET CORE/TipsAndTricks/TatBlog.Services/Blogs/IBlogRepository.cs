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

        Task<Author> GetAuthorAsync(string slug, CancellationToken cancellationToken = default);

        Task<Author> GetAuthorByIdAsync(int authorId);

        Task<IList<AuthorItem>> GetAuthorsAsync(CancellationToken cancellationToken = default);

        Task<IList<Post>> GetPostsAsync(PostQuery condition, int pageNumber, int pageSize, CancellationToken cancellationToken = default);

        Task<int> CountPostsAsync(PostQuery condition, CancellationToken cancellationToken = default);

        Task<IList<MonthlyPostCountItem>> CountMonthlyPostsAsync(int numMonths, CancellationToken cancellationToken = default);

        Task<Category> GetCategoryAsync(string slug, CancellationToken cancellationToken = default);

        Task<Category> GetCategoryByIdAsync(int categoryId);

        Task<IPagedList<CategoryItem>> GetPagedCategoriesAsync(IPagingParams pagingParams, CancellationToken cancellationToken = default);

        Task<Category> CreateOrUpdateCategoryAsync(Category category, CancellationToken cancellationToken = default);

        Task<bool> IsCategorySlugExistedAsync(int categoryId, string categorySlug, CancellationToken cancellationToken = default);

        Task<bool> DeleteCategoryAsync(int categoryId, CancellationToken cancellationToken = default);

        Task<Tag> GetTagAsync(string slug, CancellationToken cancellationToken = default);

        Task<IList<TagItem>> GetTagsAsync(CancellationToken cancellationToken = default);

        Task<bool> DeleteTagAsync(int tagId, CancellationToken cancellationToken = default);

        Task<Post> GetPostByIdAsync(int postId, bool includeDetails = false, CancellationToken cancellationToken = default);

        Task<bool> TogglePublishedFlagAsync(int postId, CancellationToken cancellationToken = default);

        Task<IList<Post>> GetRandomArticlesAsync(int numPosts, CancellationToken cancellationToken = default);

        Task<IPagedList<Post>> GetPagedPostsAsync(PostQuery condition, int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default);

        Task<IPagedList<T>> GetPagedPostsAsync<T>(PostQuery condition, IPagingParams pagingParams, Func<IQueryable<Post>, IQueryable<T>> mapper);

        Task<Post> CreateOrUpdatePostAsync(Post post, IEnumerable<string> tags, CancellationToken cancellationToken = default);

        Task<Post> GetPostBySlugAsync(string slug, CancellationToken cancellationToken = default);

        Task UpdatePostAsync(Post post, CancellationToken cancellationToken = default);
        Task<string> GetArchivesAsync();
        Task<string> GetBestAuthorsAsync(int v);
        Task<string> GetFeaturedPostsAsync(int v);
        Task<string> GetRandomPostsAsync(int v);
        Task<string> GetAllTagsAsync();
    }
}
