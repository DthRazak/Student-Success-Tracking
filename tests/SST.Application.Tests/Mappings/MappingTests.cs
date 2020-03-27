using AutoMapper;
using Shouldly;
using SST.Application.Lectors.Queries.GetNotLinkedLectors;
using SST.Application.Students.Queries.GetStudentsByGroup;
using SST.Domain.Entities;
using Xunit;

namespace SST.Application.Tests.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapLectorToLectorDto()
        {
            var entity = new Lector();

            var result = _mapper.Map<LectorDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<LectorDto>();
        }

        [Fact]
        public void ShouldMapStudentToStudentDto()
        {
            var entity = new Student()
            {
                FirstName = "Володимир",
                LastName = "Мільчановський",
                Group = "ПМІ-32"
            };

            var result = _mapper.Map<StudentDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<StudentDto>();
            result.FullName.ShouldBe("Володимир Мільчановський");
        }
    }
}
