using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Persistence;

namespace SST.Application.Tests.Common
{
    public class QueryTestFixture
    {
        public QueryTestFixture()
        {
            Context = SSTContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public SSTDbContext Context { get; private set; }

        public IMapper Mapper { get; private set; }

        public void Dispose()
        {
            SSTContextFactory.Destroy(Context);
        }
    }
}
