using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI_DangXuanDuc_21103101079.Models;
namespace WebAPI_DangXuanDuc_21103101079.Data
{

    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 10.99m, PublicationYear = 1925 },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 7.99m, PublicationYear = 1960 },
                new Book { Id = 3, Title = "1984", Author = "George Orwell", Price = 8.99m, PublicationYear = 1949 }
                );
        }

        public DbSet<WebAPI_DangXuanDuc_21103101079.Models.Book> Book { get; set; } = default!;
    }
}
