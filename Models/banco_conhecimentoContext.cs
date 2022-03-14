using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace base_conhecimento.Models
{
    public partial class banco_conhecimentoContext : DbContext
    {
        public banco_conhecimentoContext()
        {
        }

        public banco_conhecimentoContext(DbContextOptions<banco_conhecimentoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Documento> Documentos { get; set; } = null!;
        public virtual DbSet<DocumentoTag> DocumentoTags { get; set; } = null!;
        public virtual DbSet<Historico> Historicos { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER1;Database=banco_conhecimento;Trusted_Connection=True;TrustServerCertificate=True;User Id=sa;Password=P@ssw0rdsenac;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documento>(entity =>
            {
                entity.ToTable("documento");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasColumnType("text")
                    .HasColumnName("descricao");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_documento_usuario");
            });

            modelBuilder.Entity<DocumentoTag>(entity =>
            {
                entity.ToTable("documento_tag");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.IdDocument).HasColumnName("id_document");

                entity.Property(e => e.IdTag).HasColumnName("id_tag");

                entity.HasOne(d => d.IdDocumentNavigation)
                    .WithMany(p => p.DocumentoTags)
                    .HasForeignKey(d => d.IdDocument)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_documento_tag_documento");

                entity.HasOne(d => d.IdTagNavigation)
                    .WithMany(p => p.DocumentoTags)
                    .HasForeignKey(d => d.IdTag)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_documento_tag_tag");
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.ToTable("historico");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.DataHora)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("data_hora");

                entity.Property(e => e.Descricao)
                    .HasColumnType("text")
                    .HasColumnName("descricao");

                entity.Property(e => e.IdDocumento).HasColumnName("id_documento");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdDocumentoNavigation)
                    .WithMany(p => p.Historicos)
                    .HasForeignKey(d => d.IdDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__userdocum__id_do__267ABA7A");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Historicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_historico_usuario");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tag");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("login");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("senha");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
