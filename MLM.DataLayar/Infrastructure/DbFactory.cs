using MLM.DataLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.Infrastructure
{
    public class DbFactory : IDbFactory
    {
        MLMDbContext _dbContext;
        public DbFactory(MLMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MLMDbContext Init()
        {
            return _dbContext;
        }

        public void Dispose()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
