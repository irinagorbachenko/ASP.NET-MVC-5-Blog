using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Models
{

    public class Poll
    {
        public int PollId { get; set; }
        public string Question { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<PollOptions> PollOptions { get; set; }

        //public Poll()
        //{
        //    PollOptions = new List<PollOptions>();
        //}
    }
}
