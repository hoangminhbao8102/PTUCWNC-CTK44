using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;

namespace TatBlog.Core.Entities
{
    public class Subscriber : IEntity
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? UnsubscribeDate { get; set; }

        public string UnsubscribeReason { get; set; }

        public bool IsUserInitiated { get; set; }

        public string AdminNote { get; set; }
    }
}
