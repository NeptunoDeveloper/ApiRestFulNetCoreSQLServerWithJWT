using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PrjLibraryDemo.Models
{
    public partial class BdLibraryContext : DbContext
    {
        public BdLibraryContext()
        {
        }

        public BdLibraryContext(DbContextOptions<BdLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=neptunosqlserver.database.windows.net;Database=BdLibrary;User Id=usrsql;Password=us1sq2lxA7");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor);

                entity.Property(e => e.IdAuthor)
                    .HasColumnName("Id_Author")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.IdBook);

                entity.Property(e => e.IdBook)
                    .HasColumnName("Id_Book")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Genre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdAuthor)
                    .HasColumnName("Id_Author")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Section)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.IdAuthor)
                    .HasConstraintName("FK_BooksAuthors");
            });
        }
    }
}
