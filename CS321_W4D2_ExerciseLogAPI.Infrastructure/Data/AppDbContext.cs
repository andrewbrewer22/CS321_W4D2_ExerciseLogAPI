using CS321_W4D2_ExerciseLogAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityType>().HasData(
                new ActivityType { Id = 1, Name = "Running", RecordType = RecordType.DurationAndDistance },
                new ActivityType { Id = 2, Name = "Weights", RecordType = RecordType.DurationOnly },
                new ActivityType { Id = 3, Name = "Yelling", RecordType = RecordType.DurationAndDistance });

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John Doe" });

            modelBuilder.Entity<Activity>().HasData(
                new Activity { Id = 1, ActivityTypeId = 1, Date = new DateTime(2021, 4, 22), Distance = 10, Duration = 120, Notes = "To easy, not enough sweat" });
        }
    }
}