using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Persistence;
using Xunit;

namespace SST.Application.Tests.Common
{
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture>
    {
    }
}
