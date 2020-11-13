using System;
using System.Collections.Generic;
using System.Text;

namespace PU.Core.Entities
{
    public class Post: BaseEntity
    {
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
