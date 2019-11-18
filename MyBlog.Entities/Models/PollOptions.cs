using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Models
{
    public class PollOptions
    {
        public int PollOptionsId { get; set; }
        public int PollId { get; set; }
        public virtual Poll Polls { get; set; }
        public string Answer { get; set; }
        public int Votes { get; set; }
    }
}
