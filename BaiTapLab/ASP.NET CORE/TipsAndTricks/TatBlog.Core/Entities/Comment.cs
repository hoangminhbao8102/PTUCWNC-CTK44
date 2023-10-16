﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;

namespace TatBlog.Core.Entities
{
    public class Comment : IEntity
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsApproved { get; set; }

        public string AuthorName { get; set; }

        public string AuthorEmail { get; set; }

        public IList<Post> Posts { get; set; }
    }
}
