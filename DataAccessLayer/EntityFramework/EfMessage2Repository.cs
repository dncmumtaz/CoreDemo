using BusinessLayer.Abstract;
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
    public class EfMessage2Repository: GenericRepository<Message2>, IMessage2Dal
    {
        private Context context;
        public EfMessage2Repository( Context context ) : base(context)
        {
            this.context = context;
        }

        public List<Message2> GetListWithMessageByWriter( int id )
        {
            return context.Message2s.Include(x => x.SenderUser).Where(x => x.RecieverId == id).ToList();

        }
    }
}
