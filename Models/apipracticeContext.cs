using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PracticeAPI.Models
{
    public partial class apipracticeContext : DbContext
    {
        public apipracticeContext()
        {
        }

        public apipracticeContext(DbContextOptions<apipracticeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=apipractice;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("date")
                    .HasColumnName("expirydate");

                entity.Property(e => e.Manufacturedate)
                    .HasColumnType("date")
                    .HasColumnName("manufacturedate");

                entity.Property(e => e.Manufacturedby)
                    .IsUnicode(false)
                    .HasColumnName("manufacturedby");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
