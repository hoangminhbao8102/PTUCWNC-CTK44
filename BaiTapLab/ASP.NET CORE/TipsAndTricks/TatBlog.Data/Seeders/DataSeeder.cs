using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly BlogDbContext _dbContext;

        public DataSeeder(BlogDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }
        
        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Posts.Any()) return;

            var authors = AddAuthors();
            var categories = AddCategories();
            var tags = AddTags();
            var posts = AddPosts(authors, categories, tags);
        }

        private IList<Author> AddAuthors()
        {
            var authors = new List<Author>()
            {
                new()
                {
                    FullName = "John Doe",
                    UrlSlug = "john-doe",
                    ImageUrl = "john-doe.jpg",
                    JoinedDate = DateTime.Now,
                    Email = "johndoe@example.com",
                    Notes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                }
            };

            _dbContext.Authors.AddRange(authors);
            _dbContext.SaveChanges();

            return authors;
        }

        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new()
                {
                    Name = "Technology",
                    UrlSlug = "technology",
                    Description = "Category for technology-related posts.",
                    ShowOnMenu = true
                }
            };

            _dbContext.AddRange(categories);
            _dbContext.SaveChanges();

            return categories;
        }

        private IList<Tag> AddTags() 
        {
            var tags = new List<Tag>()
            {
                new()
                {
                    Name = "Programming",
                    UrlSlug = "programming",
                    Description = "Tag for programming-related posts."
                }
            };
            return tags;
        }

        private IList<Post> AddPosts(
            IList<Author> authors, 
            IList<Category> categories, 
            IList<Tag> tags) 
        {
            var posts = new List<Post>()
            {
                new()
                {
                    Title = "First Post",
                    ShortDescription = "Short description for the first post.",
                    Description = "Full description for the first post.",
                    Meta = "meta, tags, keywords",
                    UrlSlug = "first-post",
                    ImageUrl = "first-post.jpg",
                    ViewCount = 100,
                    Published = true,
                    PostedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Category = categories[0],
                    Author = authors[0],
                    Tags = new List<Tag>() 
                    { 
                        tags[0] 
                    }
                }
            };

            _dbContext.AddRange(posts); 
            _dbContext.SaveChanges();

            return posts;
        }
    }
}
