using AutoMapper;
using Shouldly;
using SST.Application.Lectors.Queries.GetNotLinkedLectors;
using SST.Application.Students.Queries.GetStudentsByGroup;
using SST.Application.Subjects.Queries;
using SST.Application.Grades.Queries.GetGradeInfoByGroupAndSubject;
using SST.Application.Users.Queries.GetUser;
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

        [Fact]
        public void ShouldMapUserToUserVm()
        {
            var entity = new User()
            {
                Email = "example@email.com",
                IsAdmin = false,
                PasswordHash = "password",
                Request = new Request(),
                Student = new Student()
            };

            var result = _mapper.Map<UserVm>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<UserVm>();
            result.Role.ShouldBe("Student");
        }
        
        [Fact]
        public void ShouldMapSubjectToSubjectDto()
        {
            var entity = new Subject()
            {
                Id = 1,
                Name = "Програмна інженерія",
                Lector = new Lector()
                {
                    Id = 2,
                    FirstName = "Анатолій",
                    LastName = "Музичук",
                    AcademicStatus = "доцент"
                },
            };

            var result = _mapper.Map<SubjectDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<SubjectDto>();
            result.Id.ShouldBe(1);
            result.Name.ShouldBe("Програмна інженерія");
            result.LectorFullName.ShouldBe("Анатолій Музичук");
        }

        [Fact]
        public void ShouldMapStudentSubjectToSubjectDto()
        {
            var entity = new StudentSubject()
            {
                Id = 1,
                Student = new Student()
                {
                    Id = 2,
                    FirstName = "Віталій",
                    LastName = "Пистун",
                    Group = "ПМІ-32"
                },
                Subject = new Subject()
                {
                    Id = 3,
                    Name = "Програмна інженерія",
                    Lector = new Lector()
                    {
                        Id = 4,
                        FirstName = "Анатолій",
                        LastName = "Музичук",
                        AcademicStatus = "доцент"
                    },
                }
            };

            var result = _mapper.Map<SubjectDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<SubjectDto>();
            result.Id.ShouldBe(3);
            result.Name.ShouldBe("Програмна інженерія");
            result.LectorFullName.ShouldBe("Анатолій Музичук");
        }

        [Fact]
        public void ShouldMapStudentSubjectToGradeInfoDto()
        {
            var entity = new StudentSubject()
            {
                Id = 1,
                Student = new Student()
                {
                    Id = 2,
                    FirstName = "Віталій",
                    LastName = "Пистун",
                    Group = "ПМІ-32"
                },
                Subject = new Subject()
                {
                    Id = 3,
                    Name = "Програмна інженерія",
                    Lector = new Lector()
                    {
                        Id = 4,
                        FirstName = "Анатолій",
                        LastName = "Музичук",
                        AcademicStatus = "доцент"
                    },
                }
            };

            var result = _mapper.Map<GradesInfoDto>(entity);
            result.ShouldNotBeNull();
            result.ShouldBeOfType<GradesInfoDto>();
            result.StudentFullName.ShouldBe("Віталій Пистун");
            result.Total.ShouldBe(0);
        }
    }
}
