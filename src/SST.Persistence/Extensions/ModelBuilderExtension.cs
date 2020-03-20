using Microsoft.EntityFrameworkCore;
using SST.Domain.Entities;
using System;

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
        }

        private static void SeedUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Email = "admin@email.com",
                    PasswordHash = "Yh+CEuxWzPTw0y2M9zgFEw1stxAwoa1mvyaoI2157nY=", //admin
                    IsAdmin = true,
                }
            );
        }

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
        }

        private static void SeedStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Володимир",
                    LastName = "Мільчановський",
                    Group = "ПМІ-32"
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Марта",
                    LastName = "Шуяк",
                    Group = "ПМІ-32"
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Оксана",
                    LastName = "Пилипович",
                    Group = "ПМІ-32"
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Доскач",
                    LastName = "Денис",
                    Group = "ПМІ-31"
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Левкович",
                    LastName = "Роман",
                    Group = "ПМІ-33"
                }

            );
        }

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
                }
            );
        }

    }
}
