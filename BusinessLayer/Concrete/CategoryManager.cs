using BusinessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public void AddCategory( Category category )
        {
            throw new NotImplementedException();
        }

        public Category GetById( int id )
        {
            throw new NotImplementedException();
        }

        public List<Category> GetList()
        {
            throw new NotImplementedException();
        }

        public void RemoveCategory( Category category )
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory( Category category )
        {
            throw new NotImplementedException();
        }
    }
}
