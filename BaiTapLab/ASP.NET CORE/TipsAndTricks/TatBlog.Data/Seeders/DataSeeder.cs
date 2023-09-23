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
                    FullName = "Nguyễn Văn A",
                    UrlSlug = "nguyen-van-a",
                    ImageUrl = "",
                    JoinedDate = DateTime.Now,
                    Email = "johndoe@example.com",
                    Notes = ""
                },
                new()
                {
                    FullName = "Nguyễn Văn A",
                    UrlSlug = "nguyen-van-a",
                    ImageUrl = "",
                    JoinedDate = DateTime.Now,
                    Email = "johndoe@example.com",
                    Notes = ""
                },
                new()
                {
                    FullName = "Nguyễn Văn A",
                    UrlSlug = "nguyen-van-a",
                    ImageUrl = "",
                    JoinedDate = DateTime.Now,
                    Email = "johndoe@example.com",
                    Notes = ""
                },
                new()
                {
                    FullName = "Trần Văn B",
                    UrlSlug = "tran-van-b",
                    ImageUrl = "",
                    JoinedDate = DateTime.Now,
                    Email = "johndoe@example.com",
                    Notes = ""
                },
                new()
                {
                    FullName = "Nguyễn Thị C",
                    UrlSlug = "nguyen-thi-c",
                    ImageUrl = "",
                    JoinedDate = DateTime.Now,
                    Email = "johndoe@example.com",
                    Notes = ""
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
                    Name = ".NET Core",
                    UrlSlug = ".NET Core",
                    Description = "A category related to the .NET Core framework, which is a cross-platform development framework for building modern, cloud-based applications.",
                    ShowOnMenu = true
                },
                new()
                {
                    Name = "Architecture",
                    UrlSlug = "Architecture",
                    Description = "A category that focuses on software architecture principles, patterns, and best practices for designing scalable and maintainable systems.",
                    ShowOnMenu = true
                },
                new()
                {
                    Name = "Messaging",
                    UrlSlug = "Messaging",
                    Description = "A category that covers various messaging technologies and patterns, such as message queues, publish-subscribe systems, and event-driven architectures.",
                    ShowOnMenu = true
                },
                new()
                {
                    Name = "OOP",
                    UrlSlug = "Object-Oriented Program",
                    Description = "A category that explores the concepts, principles, and techniques of object-oriented programming, which is a programming paradigm based on the concept of objects.",
                    ShowOnMenu = true
                },
                new()
                {
                    Name = "Design Pattern",
                    UrlSlug = "Design Pattern",
                    Description = "A category that discusses different design patterns, which are reusable solutions to common software design problems, helping to improve code organization, flexibility, and maintainability.",
                    ShowOnMenu = true
                },
                new()
                {
                    Name = "CPP",
                    UrlSlug = "C Plus Plus",
                    Description = "A category dedicated to the C++ programming language, covering topics such as language features, libraries, and best practices.",
                    ShowOnMenu = true
                },
                new()
                {
                    Name = "HTML",
                    UrlSlug = "Hypertext Markup Language",
                    Description = "A category focused on HTML (Hypertext Markup Language), the standard markup language for creating web pages and web applications.",
                    ShowOnMenu = true
                },
                new()
                {
                    Name = "CSS",
                    UrlSlug = "Cascading Style Sheets",
                    Description = "A category that deals with CSS, a stylesheet language used to describe the presentation and formatting of HTML documents.",
                    ShowOnMenu = true
                },
                new()
                {
                    Name = "Flutter",
                    UrlSlug = "Flutter",
                    Description = " A category related to the Flutter framework, which is a cross-platform UI toolkit for building natively compiled applications for mobile, web, and desktop from a single codebase.",
                    ShowOnMenu = true
                },
                new()
                {
                    Name = "JavaScript",
                    UrlSlug = "JavaScript",
                    Description = "A category that covers JavaScript, a programming language commonly used for client-side web development, enabling interactivity and dynamic content on websites.",
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
                    Name = "Google",
                    UrlSlug = "Google",
                    Description = "A tag related to Google, a multinational technology company known for its internet-related services and products, including search engines, online advertising technologies, and cloud computing."
                },
                new()
                {
                    Name = "ASP.NET MVC",
                    UrlSlug = "ASP.NET MVC",
                    Description = "A tag referring to ASP.NET MVC (Model-View-Controller), a web application framework developed by Microsoft that follows the MVC architectural pattern for building scalable and maintainable web applications."
                },
                new()
                {
                    Name = "Razor Page",
                    UrlSlug = "Razor Page",
                    Description = "A tag associated with Razor Pages, a feature of ASP.NET Core that allows developers to build web pages using a combination of HTML markup and server-side C# code."
                },
                new()
                {
                    Name = "Blazor",
                    UrlSlug = "Blazor",
                    Description = "A tag related to Blazor, a web framework developed by Microsoft that enables developers to build interactive web UIs using C# instead of JavaScript, leveraging WebAssembly technology."
                },
                new()
                {
                    Name = "Deep Learning",
                    UrlSlug = "Deep Learning",
                    Description = "A tag referring to deep learning, a subset of machine learning that focuses on artificial neural networks with multiple layers, enabling the learning of complex patterns and representations from data."
                },
                new()
                {
                    Name = "Neural Network",
                    UrlSlug = "Neural Network",
                    Description = "A tag associated with neural networks, a computational model inspired by the structure and function of the human brain, used for solving complex problems by learning from example data."
                },
                new()
                {
                    Name = "Programming",
                    UrlSlug = "Programming",
                    Description = "A tag that encompasses the general concept of programming, including coding, software development, and problem-solving using various programming languages and techniques."
                },
                new()
                {
                    Name = "React",
                    UrlSlug = "React",
                    Description = "A tag related to React, a JavaScript library for building user interfaces, known for its component-based architecture and virtual DOM rendering."
                },
                new()
                {
                    Name = "Create Website",
                    UrlSlug = "Create Website",
                    Description = "A tag indicating the process or concept of creating a website, including designing the layout, implementing functionality, and deploying it on the internet."
                },
                new()
                {
                    Name = "HTML",
                    UrlSlug = "Hypertext Markup Language",
                    Description = "A tag referring to HTML (Hypertext Markup Language), the standard markup language for creating web pages and web applications."
                },
                new()
                {
                    Name = "CSS",
                    UrlSlug = "Cascading Style Sheets",
                    Description = "A tag associated with CSS (Cascading Style Sheets), a stylesheet language used for describing the presentation and visual styling of HTML elements."
                },
                new()
                {
                    Name = "JavaScript",
                    UrlSlug = "JavaScript",
                    Description = "A tag related to JavaScript, a programming language commonly used for client-side web development, enabling interactivity and dynamic content on websites."
                },
                new()
                {
                    Name = "CPP",
                    UrlSlug = "C Plus Plus",
                    Description = "A tag referring to C++, a versatile and powerful programming language commonly used for system-level programming, game development, and high-performance applications."
                },
                new()
                {
                    Name = "Java Programming",
                    UrlSlug = "Java Programming",
                    Description = "A tag associated with Java, a popular programming language known for its platform independence, object-oriented nature, and extensive libraries, widely used for building enterprise-level software and Android applications."
                },
                new()
                {
                    Name = "C#",
                    UrlSlug = "C Sharp",
                    Description = "A tag related to C#, a modern programming language developed by Microsoft, designed for building a wide range of applications on the .NET platform, including desktop, web, and mobile applications."
                },
                new()
                {
                    Name = "Flutter",
                    UrlSlug = "Flutter",
                    Description = "A tag associated with Flutter, a UI toolkit developed by Google for building natively compiled applications for mobile, web, and desktop platforms from a single codebase, using the Dart programming language."
                },
                new()
                {
                    Name = "Vue",
                    UrlSlug = "Vue",
                    Description = "A tag referring to Vue.js, a progressive JavaScript framework used for building user interfaces, known for its simplicity, flexibility, and easy integration with existing projects."
                },
                new()
                {
                    Name = "Ionic",
                    UrlSlug = "Ionic",
                    Description = "A tag related to Ionic, a popular open-source framework for building cross-platform mobile applications using web technologies such as HTML, CSS, and JavaScript."
                },
                new()
                {
                    Name = "Angular",
                    UrlSlug = "Angular",
                    Description = "A tag associated with Angular, a powerful JavaScript framework developed by Google for building web applications, providing a comprehensive set of features for building scalable and maintainable applications."
                },
                new()
                {
                    Name = "Kotlin",
                    UrlSlug = "Kotlin",
                    Description = "A tag referring to Kotlin, a modern programming language developed by JetBrains, designed to be fully interoperable with Java, known for its conciseness, safety features, and Android development support."
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
                },
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
                    Category = categories[1],
                    Author = authors[1],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
