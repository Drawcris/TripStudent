﻿using TripStudent.Models;
using Microsoft.EntityFrameworkCore;

namespace TripStudent.Data
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options) 
        {
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().ToTable("Trip");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<Student>().ToTable("Student");
        }



    }
}
