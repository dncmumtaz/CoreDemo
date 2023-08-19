using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private Context _dbContext;

        public GenericRepository(Context dbContext )
        {
            this._dbContext = dbContext;
        }
        public void Delete( T item )
        {
            _dbContext.Remove( item );
            _dbContext.SaveChanges();
        }

        public T GetById( int id )
        {
            return _dbContext.Set<T>().Find( id);
        }

        public List<T> GetListAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Insert( T item )
        {
            _dbContext.Add(item);
            _dbContext.SaveChanges();
        }

        public void Update( T item )
        {
            _dbContext.Update( item );
            _dbContext.SaveChanges();
        }
    }
}
