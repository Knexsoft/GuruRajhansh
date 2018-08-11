using MLM.DataLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private MLMDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public MLMDbContext DbContext
        {
            get { return dbContext ?? (dbContext = _dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
