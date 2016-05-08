using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Librarian.DbModel.DbModel
{
    public class DbModelConfiguration : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=ALEXASHA-PK;user id=sa;password=123456;initial catalog=Librarian");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Statistics> Statisticses { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Books
            modelBuilder.Entity<Book>().ToTable("Books").HasKey(x => x.Id).HasName("PK_Books");
            modelBuilder.Entity<Book>().HasOne(x => x.Library).WithMany(x => x.Books).HasForeignKey(x => x.LibraryId);
            modelBuilder.Entity<Book>().HasMany(x => x.Histories).WithOne(x => x.Book);
            modelBuilder.Entity<Book>().HasMany(x => x.Statisticses).WithOne(x => x.Book);
            modelBuilder.Entity<Book>().HasMany(x => x.Ratings).WithOne(x => x.Book);
            #endregion
            #region Libraries
            modelBuilder.Entity<Library>().ToTable("Libraries").HasKey(x => x.Id).HasName("PK_Libraries");
            modelBuilder.Entity<Library>().HasMany(x => x.Books).WithOne(x => x.Library);
            #endregion
            #region Users
            modelBuilder.Entity<User>().ToTable("Users").HasKey(x => x.Id).HasName("PK_Users");
            modelBuilder.Entity<User>().HasMany(x => x.Histories).WithOne(x => x.User);
            modelBuilder.Entity<User>().HasMany(x => x.Statisticses).WithOne(x => x.User);
            modelBuilder.Entity<User>().HasMany(x => x.Ratings).WithOne(x => x.User);
            #endregion
            #region Histories
            modelBuilder.Entity<History>().ToTable("Histories").HasKey(x => x.Id).HasName("PK_Histories");
            modelBuilder.Entity<History>().HasOne(x => x.User).WithMany(x => x.Histories).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<History>().HasOne(x => x.Book).WithMany(x => x.Histories).HasForeignKey(x => x.BookId);
            #endregion
            #region Statisticses
            modelBuilder.Entity<Statistics>().ToTable("Statisticses").HasKey(x => x.Id).HasName("PK_Statisticses");
            modelBuilder.Entity<Statistics>().HasOne(x => x.User).WithMany(x => x.Statisticses).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Statistics>().HasOne(x => x.Book).WithMany(x => x.Statisticses).HasForeignKey(x => x.BookId);
            #endregion
            #region Ratings
            modelBuilder.Entity<Rating>().ToTable("Ratings").HasKey(x => x.Id).HasName("PK_Ratings");
            modelBuilder.Entity<Rating>().HasOne(x => x.User).WithMany(x => x.Ratings).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Rating>().HasOne(x => x.Book).WithMany(x => x.Ratings).HasForeignKey(x => x.BookId);
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
