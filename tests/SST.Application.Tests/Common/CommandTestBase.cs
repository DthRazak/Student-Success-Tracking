using System;
using SST.Persistence;

namespace SST.Application.Tests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly SSTDbContext _context;

        public CommandTestBase()
        {
            _context = SSTContextFactory.Create();
        }

        public void Dispose()
        {
            SSTContextFactory.Destroy(_context);
        }
    }
}
