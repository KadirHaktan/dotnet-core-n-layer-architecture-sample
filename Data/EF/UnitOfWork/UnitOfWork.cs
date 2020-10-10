using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.UnitOfWork;

namespace Data.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleAppContext _context;

        public UnitOfWork(SampleAppContext context)
        {
            this._context = context;
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
