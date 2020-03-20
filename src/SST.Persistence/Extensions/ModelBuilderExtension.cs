using Microsoft.EntityFrameworkCore;
using SST.Domain.Entities;

namespace SST.Persistence.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedUser(modelBuilder);
            SeedStudent(modelBuilder);
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

        private static void SeedStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    FirstName = "Володимир",
                    LastName = "Мільчановський",
                    Group = "ПМІ-32"
                },
                new Student
                {
                    FirstName = "Марта",
                    LastName = "Шуяк",
                    Group = "ПМІ-32"
                },
                new Student
                {
                    FirstName = "Оксана",
                    LastName = "Пилипович",
                    Group = "ПМІ-32"
                },
                new Student
                {
                    FirstName = "Доскач",
                    LastName = "Денис",
                    Group = "ПМІ-31"
                },
                new Student
                {
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
                    FirstName = "Анатолій",
                    LastName = "Музичук",
                    AcademicStatus = "Доцент" 
                },
                new Lector
                {
                    FirstName = "Андрій",
                    LastName = "Глова",
                    AcademicStatus = "Асистент"
                },
                new Lector
                {
                    FirstName = "Юрій",
                    LastName = "Щербина",
                    AcademicStatus = "Професор"
                },
                new Lector
                {
                    FirstName = "Віталій",
                    LastName = "Горлач",
                    AcademicStatus = "Доцент"
                },
                new Lector
                {
                    FirstName = "Любомир",
                    LastName = "Галамага",
                    AcademicStatus = "Асистент"
                }
            );
        }

    }
}
