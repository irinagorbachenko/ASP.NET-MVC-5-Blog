using MyBlog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL

{    // Represents the collection of all entities in the context, or that can be queried from the database,
    //of a given type. 
    public class MyBlogContext:DbContext
    {
        public  DbSet<Comment> Comments { get; set; }
        public  DbSet<Post> Posts { get; set; }
        public  DbSet<Poll> Polls { get; set; }
        public  DbSet<PollOptions>  PollsOptions { get; set; }
 

        public MyBlogContext() : base("name=MyBlogContext") { }

        static MyBlogContext()
        {
            Database.SetInitializer<MyBlogContext>(new MyBlogInitializer());
            
        }

        
    }
}
