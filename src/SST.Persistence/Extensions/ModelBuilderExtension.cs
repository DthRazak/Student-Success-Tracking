using System;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Hashing;
using SST.Domain.Entities;

namespace SST.Persistence.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedUser(modelBuilder);
            SeedRequest(modelBuilder);
            SeedStudent(modelBuilder);
            SeedLector(modelBuilder);
            SeedSubject(modelBuilder);
            SeedGroup(modelBuilder);
            SeedGroupSubject(modelBuilder);
            SeedSecondaryGroup(modelBuilder);
            SeedJournalColumn(modelBuilder);
            SeedGrade(modelBuilder);
        }

        // USER
        private static void SeedUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Email = "admin@email.com",
                    PasswordHash = new PasswordHasher().GetPasswordHash("admin"),
                    IsAdmin = true,
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    PasswordHash = new PasswordHasher().GetPasswordHash("Password"),
                    Email = "martashuyak@gmail.com"
                }
            );
        }

        // REQUEST
        private static void SeedRequest(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>().HasData(
                new Request
                {
                    Id = 1,
                    CreationDate = DateTime.Now,
                    IsApproved = true,
                    UserRef = "admin@email.com"
                }
            );

            modelBuilder.Entity<Request>().HasData(
                new Request
                {
                    Id = 2,
                    CreationDate = DateTime.Now,
                    IsApproved = true,
                    UserRef = "martashuyak@gmail.com"
                }
            );
        }

        // STUDENT
        private static void SeedStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Володимир",
                    LastName = "Мільчановський",
                    GroupRef = 2
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Марта",
                    LastName = "Шуяк",
                    GroupRef = 2,
                    UserRef = "martashuyak@gmail.com",
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Оксана",
                    LastName = "Пилипович",
                    GroupRef = 2
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Денис",
                    LastName = "Доскач",
                    GroupRef = 1
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Роман",
                    LastName = "Левкович",
                    GroupRef = 3
                }
            );
        }

        // LECTOR
        private static void SeedLector(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lector>().HasData(
                new Lector
                {
                    Id = 1,
                    FirstName = "Анатолій",
                    LastName = "Музичук",
                    AcademicStatus = "Доцент"
                },
                new Lector
                {
                    Id = 2,
                    FirstName = "Андрій",
                    LastName = "Глова",
                    AcademicStatus = "Асистент"
                },
                new Lector
                {
                    Id = 3,
                    FirstName = "Юрій",
                    LastName = "Щербина",
                    AcademicStatus = "Професор"
                },
                new Lector
                {
                    Id = 4,
                    FirstName = "Віталій",
                    LastName = "Горлач",
                    AcademicStatus = "Доцент"
                },
                new Lector
                {
                    Id = 5,
                    FirstName = "Любомир",
                    LastName = "Галамага",
                    AcademicStatus = "Асистент"
                },
                new Lector
                {
                    Id = 6,
                    FirstName = "Софія",
                    LastName = "Грабовська",
                    AcademicStatus = "Професор"
                }
            );
        }

        // GRADE
        private static void SeedGrade(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>().HasData(
                new Grade
                {
                    Id = 1,
                    Mark = 20,
                    StudentRef = 1,
                    JournalColumnRef = 4
                },
                new Grade
                {
                    Id = 2,
                    Mark = 15,
                    StudentRef = 2,
                    JournalColumnRef = 3
                },
                new Grade
                {
                    Id = 3,
                    Mark = 18,
                    StudentRef = 3,
                    JournalColumnRef = 2
                },
                new Grade
                {
                    Id = 4,
                    Mark = 14,
                    StudentRef = 2,
                    JournalColumnRef = 1
                },
                new Grade
                {
                    Id = 5,
                    Mark = 20,
                    StudentRef = 3,
                    JournalColumnRef = 5
                }
            );
        }

        // SUBJECT
        private static void SeedSubject(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    Name = "Програмна інженерія",
                    LectorRef = 1
                },
                new Subject
                {
                    Id = 2,
                    Name = "Дискретна математика",
                    LectorRef = 3
                },
                new Subject
                {
                    Id = 3,
                    Name = "Програмування",
                    LectorRef = 5
                },
                new Subject
                {
                    Id = 4,
                    Name = "Теорія ймовірності та математична статистика",
                    LectorRef = 3
                },
                new Subject
                {
                    Id = 5,
                    Name = "Психологія примирення",
                    LectorRef = 6
                }
            );
        }

        // GROUP SUBJECT
        private static void SeedGroupSubject(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupSubject>().HasData(
                new GroupSubject
                {
                    Id = 1,
                    SubjectRef = 1,
                    GroupRef = 1
                },
                new GroupSubject
                {
                    Id = 2,
                    SubjectRef = 1,
                    GroupRef = 2
                },
                new GroupSubject
                {
                    Id = 3,
                    SubjectRef = 2,
                    GroupRef = 3
                },
                new GroupSubject
                {
                    Id = 4,
                    SubjectRef = 4,
                    GroupRef = 3
                },
                new GroupSubject
                {
                    Id = 5,
                    SubjectRef = 5,
                    GroupRef = 5
                }
            );
        }

        // GROUP
        private static void SeedGroup(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasData(
                new Group
                {
                    Id = 1,
                    Name = "ПМІ-31",
                    Faculty = "Факультет прикладної математики та інформатики",
                    IsMain = true
                },
                new Group
                {
                    Id = 2,
                    Name = "ПМІ-32",
                    Faculty = "Факультет прикладної математики та інформатики",
                    IsMain = true
                },
                new Group
                {
                    Id = 3,
                    Name = "ПМІ-33",
                    Faculty = "Факультет прикладної математики та інформатики",
                    IsMain = true
                },
                new Group
                {
                    Id = 4,
                    Name = "ЖРН-11с",
                    Faculty = "Факультет журналістики",
                    IsMain = true
                },
                new Group
                {
                   Id = 5,
                   Name = "ФФП-42с",
                   Faculty = "Філософський факультет",
                   IsMain = true
                }
            );
        }

        // SECONDARY GROUP
        private static void SeedSecondaryGroup(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<SecondaryGroup>().HasData(
                new SecondaryGroup
                {
                    Id = 1,
                    GroupRef = 2,
                },
                new SecondaryGroup
                {
                    Id = 2,
                    GroupRef = 2,
                }
            );*/
        }

        // JOURNAL COLUMN
        private static void SeedJournalColumn(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JournalColumn>().HasData(
                new JournalColumn
                {
                    Id = 1,
                    Date = new DateTime(2020, 03, 03),
                    GroupSubjectRef = 2
                },
                new JournalColumn
                {
                    Id = 2,
                    Date = new DateTime(2020, 03, 10),
                    GroupSubjectRef = 2
                },
                new JournalColumn
                {
                    Id = 3,
                    Date = new DateTime(2020, 03, 16),
                    GroupSubjectRef = 2
                },
                new JournalColumn
                {
                    Id = 4,
                    Date = new DateTime(2020, 03, 20),
                    GroupSubjectRef = 2
                },
                new JournalColumn
                {
                    Id = 5,
                    Date = new DateTime(2020, 04, 02),
                    GroupSubjectRef = 2
                }
            );
        }
    }
}
