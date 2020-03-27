using Microsoft.EntityFrameworkCore;
using SST.Persistence;
using System;

namespace SST.Application.Tests.Common
{
    public class SSTContextFactory
    {
        public static SSTDbContext Create()
        {
            var options = new DbContextOptionsBuilder<SSTDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new SSTDbContext(options);

            context.Database.EnsureCreated();

            return context;
        }

        public static void Destroy(SSTDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
