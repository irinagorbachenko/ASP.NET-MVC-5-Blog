using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Models.ViewModels
{
    public class PostsPoll
    {
        public IEnumerable<Post> Posts { get; set; }         
        public Poll Polls { get; set; }
    }
}
