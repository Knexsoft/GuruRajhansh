using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.Abstracts
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
