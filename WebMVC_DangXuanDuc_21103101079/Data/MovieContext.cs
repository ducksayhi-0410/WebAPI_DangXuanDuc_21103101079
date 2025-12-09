using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMVC_DangXuanDuc_21103101079.Models;
namespace WebMVC_DangXuanDuc_21103101079.Data
{

    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<WebMVC_DangXuanDuc_21103101079.Models.Movie> Movie { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Director = "Christopher Nolan",
                    Title = "Inception",
                    ReleaseYear = 2010,
                    Rating = 9
                },
                new Movie
                {
                    Id = 2,
                    Director = "Steven Spielberg",
                    Title = "Jurassic Park",
                    ReleaseYear = 1993,
                    Rating = 8
                },
                new Movie
                {
                    Id = 3,
                    Director = "Quentin Tarantino",
                    Title = "Pulp Fiction",
                    ReleaseYear = 1994,
                    Rating = 9
                }
                );
        }
    }
}