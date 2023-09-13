using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        private Context _dbContext;

        public EfBlogRepository( Context dbContext ) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Blog> GetListWithCategory()
        {
            return _dbContext.Blogs.Include( b => b.Category ).ToList();
        }

        public List<Blog> GetListWithCategoryByWriter( int id )
        {
            return _dbContext.Blogs.Include(b => b.Category).Where(x => x.WriterId == id).ToList();

        }
    }
}
