using LibraryApp.Domain.Entites;
using LibraryApp.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookTransaction> BookTransactions { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<PublicHoliday> Holidays { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Library");
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable(name: "Books");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable(name: "Members");
            });

            modelBuilder.Entity<BookTransaction>(entity =>
            {
                entity.ToTable(name: "BookTransactions");
            });

            //modelBuilder.Entity<BookTransaction>().HasKey(bt => new { bt.MemberId, bt.BookId });
            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = "Server=DESKTOP-RNMH4P1\\CNSN_SQLEXPRESS;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True";
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}




