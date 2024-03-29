﻿using CinemaExplorer.Persisted.Configurations;
using CinemaExplorer.Persisted.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaExplorer.Persisted.Context
{
    public sealed class CinemaContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public CinemaContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FilmConfiguration());
        }
    }
}
