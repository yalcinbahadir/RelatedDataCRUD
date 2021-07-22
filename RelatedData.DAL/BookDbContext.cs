using Microsoft.EntityFrameworkCore;
using RelatedData.Domein;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelatedData.Data
{
    public class BookDbContext:DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AuthorBook> AuthorBook { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStoreDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .UsingEntity<AuthorBook>(
                    ab => ab.HasOne<Book>().WithMany(),
                    ab => ab.HasOne<Author>().WithMany())
                .Property(ab => ab.CreatedAt)
                .HasDefaultValueSql("getdate()");
        }
    }
}
