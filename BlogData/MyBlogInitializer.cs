using MyBlog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL

{     // Seeding database after creation

    public class MyBlogInitializer: DropCreateDatabaseIfModelChanges<MyBlogContext>
    {
        protected override void Seed(MyBlogContext context)
        {            
            Post firstPost = new Post { AuthorName = "Jaap Schekkerman ", PostId = 1, Title = "How to survive in enterprise", PostDate = new DateTime(2018, 10 , 10), PostBody = "Several times in my Enterprise Architecture(EA) practice,people asked me which framework shall I adopt or what are the benefits of the Zachman framework over TOGAF etc.Others asked me to help them to define their own corporate EA framework.Before answering these types of questions,      it is important to know what the differences and commonalities are of these frameworks and standards.Several times in my Enterprise Architecture(EA) practice,people asked me which framework shall I adopt or what are the benefits of the Zachman framework over TOGAF etc.Others asked me to help them to define their own corporate EA framework.Before answering these types of questions,      it is important to know what the differences and commonalities are of these frameworks and standards.",PostTag="Enterprice"};
            Post secondPost = new Post { AuthorName = "Mark Gibbs", PostId = 2, Title = "How to survive in IT", PostDate = new DateTime(2018, 10 ,10), PostBody = "So you have decided on a career in IT instead of, say, being a dancer on Broadway or becoming a fugu chef in Japan. Given that you consider IT more interesting than appearing in 50,000 performances of Oliver and less risky than serving up potentially lethal sushi, what should you know about not just surviving but prospering in the fast paced and exciting world of information technology?So you have decided on a career in IT instead of, say, being a dancer on Broadway or becoming a fugu chef in Japan. Given that you consider IT more interesting than appearing in 50,000 performances of Oliver and less risky than serving up potentially lethal sushi, what should you know about not just surviving ", PostTag = "IT" };

            context.Posts.Add(firstPost); 
            context.Posts.Add(secondPost);
            
            Comment firstComment = new Comment { CommentAuthorName = "Jane Doe", CommentDate = new DateTime(2018 ,10 , 10), CommentId = 1,PostID=1, CommentBody = "Thanks for a good useful post!" };
            Comment secondComment = new Comment { CommentAuthorName = "John Dow", CommentDate = new DateTime(2018 ,10 ,10), CommentId = 2, PostID=2,CommentBody = "Really useful,thanks.Cheers!" };

            context.Comments.Add(firstComment);
            context.Comments.Add(secondComment);

            Poll poll = new Poll { Question = "Котики или собачки?" };

            context.Polls.Add(poll);

            PollOptions polloptions = new PollOptions { Answer="Котики", Votes=0, Polls=poll };
            context.PollsOptions.Add(polloptions);
            polloptions = new PollOptions { Answer="Собачки", Votes=0, Polls=poll };

            context.PollsOptions.Add(polloptions);

            base.Seed(context);
            context.SaveChanges();


        }
    }
}
