using Microsoft.EntityFrameworkCore;
using TrainersSource.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainersSource.InfrastructureServices.Gateways.Database
{
    public class TrainersContext : DbContext
    {
        public DbSet<Trainers> Trainerss { get; set; }

        public TrainersContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Trainers>().HasData(
                new
                {
                    Id = 1L,
                    Surname = "Абызова",
                    Name = "Надежда",
                    Patronymic = "Викторовна",
                    Gender = "женский",
                    Birthday = "19.01.1973",
                    Sport = "Большой спорт"
                },

                new
                {
                    Id = 2L,
                    Surname = "Алешина", Name = "Лариса", Patronymic = "Владимировна", Gender = "женский", Birthday = "01.02.1960", Sport = "Большой спорт"

                },
                new
                {
                    Id = 3L,
                   Surname = "Андрюхин", Name = "Алексей", Patronymic = "Михайлович", Gender = "мужской", Birthday = "21.11.1973", Sport = "Спортивный резерв"
                },
                new
                {
                    Id = 4L,
                    Surname = "Ануров", Name = "Александр", Patronymic = "Львович", Gender = "мужской", Birthday = "10.11.1957", Sport = "Большой спорт"

                }
            );
        }
    }
}
