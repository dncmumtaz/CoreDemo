﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfUserRepository : GenericRepository<AppUser>, IUserDal
	{
		public EfUserRepository( Context dbContext ) : base(dbContext)
		{
		}
	}
}
