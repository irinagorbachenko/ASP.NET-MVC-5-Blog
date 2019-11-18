using MyBlog.Entities.Models;
using MyBlog.Entities.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL

{
    //Creating a class variables for the database context and each repository.For the context variable,
    //a new context is instantiated.

    public class UnitOfWork : IDisposable
    {
        private MyBlogContext _context = new MyBlogContext();
        private Repository<Post> _postRepository;
        private Repository <Comment> _commentRepository;
        private Repository<Poll> _pollRepository;
        private Repository<PollOptions> _polloptionsRepository;

        //Each repository property checks whether the repository already exists. If not, it instantiates the repository,
        //passing in the context instance. As a result, all repositories share the same context instance.

        public Repository<Post> PostRepository
        {
            get
            {
                if (_postRepository == null)
                {
                    _postRepository = new Repository<Post>(_context);
                }
                return _postRepository;
            }
        }

        public Repository <Comment> CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new Repository<Comment>(_context);
                }
                return _commentRepository;
            }
        }

        public Repository<Poll> PollRepository
        {
            get
            {
                if (_pollRepository == null)
                {
                    _pollRepository = new Repository<Poll>(_context);
                }
                return _pollRepository;
            }
        }
        public Repository<PollOptions> PollOptionsRepository
        {
            get
            {
                if (_polloptionsRepository == null)
                {
                    _polloptionsRepository = new Repository<PollOptions>(_context);
                }
                return _polloptionsRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
