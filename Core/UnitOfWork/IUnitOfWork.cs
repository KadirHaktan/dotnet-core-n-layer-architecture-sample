using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;
using Core.Repository;

namespace Core.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        Task<int> CommitAsync();

        int Commit();
    }
}
