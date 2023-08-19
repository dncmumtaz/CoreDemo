using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BlogRrepository : IBlogDal
    {
        DbContextOptions<Context>  dbContext;
        public void AddBlog( Blog blog )
        {
            using var c = new Context(dbContext);
            c.Add(blog);
            c.SaveChanges();
        }

        public void Delete( Blog item )
        {
            throw new NotImplementedException();
        }

        public void DeleteBlog( Blog blog )
        {
            using var c = new Context(dbContext);
            c.Remove(blog);
            c.SaveChanges();
        }

        public Blog GetById( int id )
        {
            using var c = new Context(dbContext);
            return c.Blogs.Find(id);
        }

        public List<Blog> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert( Blog item )
        {
            throw new NotImplementedException();
        }

        public List<Blog> ListAllBlog()
        {
            using var c = new Context(dbContext);
            return c.Blogs.ToList();
        }

        public void Update( Blog item )
        {
            throw new NotImplementedException();
        }

        public void UpdateBlog( Blog blog )
        {
            using var c = new Context(dbContext);
            c.Update(blog);
            c.SaveChanges();
        }
    }
}
