using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LGBTQ_Cinemedia_Back_End.Models;

public partial class LgbtqcontentdbContext : DbContext
{
    public LgbtqcontentdbContext()
    {
    }

    public LgbtqcontentdbContext(DbContextOptions<LgbtqcontentdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cinemedium> Cinemedia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=LGBTQCONTENTDB; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cinemedium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cinemedi__3214EC0711C54A0E");

            entity.Property(e => e.Genre).HasMaxLength(255);
            entity.Property(e => e.Img)
                .HasMaxLength(255)
                .HasColumnName("IMG");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
