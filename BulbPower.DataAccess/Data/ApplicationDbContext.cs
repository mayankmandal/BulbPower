using BulbPower.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BulbPower.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
               
        }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<ExperimentBulbState> ExperimentBulbStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experiment>().HasData(
                new Experiment
                {
                    ExperimentId = 4,
                    NumberOfPeople = 2,
                    NumberOfBulbs = 2,
                    ExperimentName = "2-people-2-bulbs",
                    ExperimentStatus = Utility.Constants.ExperimentStatus.NotStarted,
                    LastExitedPersonNumber =0,
                    LastExitedDateTime = DateTime.Now,
                    CreatedDateTime = DateTime.Now,
                }
            );
            modelBuilder.Entity<ExperimentBulbState>().HasData(
            new ExperimentBulbState
            {
                ExperimentBulbStateId = 4,
                ExperimentId = 4,  
                BulbNumber = 1,
                BulbState = false,
                ToggledOnDateTime = DateTime.UtcNow
            },
            new ExperimentBulbState
            {
                ExperimentBulbStateId = 5,
                ExperimentId = 4,
                BulbNumber = 2,
                BulbState = false,
                ToggledOnDateTime = DateTime.UtcNow
            }
        );
        }
    }
}
