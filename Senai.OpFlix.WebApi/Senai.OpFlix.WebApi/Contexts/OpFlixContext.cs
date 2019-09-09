using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Diretor> Diretor { get; set; }
        public virtual DbSet<Favorito> Favorito { get; set; }
        public virtual DbSet<Lancamento> Lancamento { get; set; }
        public virtual DbSet<Plataforma> Plataforma { get; set; }
        public virtual DbSet<TipoMidia> TipoMidia { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        // Unable to generate entity type for table 'dbo.Favorito'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=M_OpFlix;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorito>().HasKey(p => new { p.IdUsuario, p.IdLancamento });

            modelBuilder.Entity<Favorito>()
            .HasOne<Usuario>(sc => sc.Usuarios)
            .WithMany(s => s.Favoritos)
            .HasForeignKey(sc => sc.IdUsuario);


            modelBuilder.Entity<Favorito>()
                .HasOne<Lancamento>(sc => sc.Lancamentos)
                .WithMany(s => s.Favoritos)
                .HasForeignKey(sc => sc.IdLancamento);

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.HasIndex(e => e.Categoria1)
                    .HasName("UQ__Categori__08015F8BE448A381")
                    .IsUnique();

                entity.Property(e => e.Categoria1)
                    .IsRequired()
                    .HasColumnName("Categoria")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Diretor>(entity =>
            {
                entity.HasKey(e => e.IdDiretor);

                entity.HasIndex(e => e.Diretor1)
                    .HasName("UQ__Diretor__2DF1C016D2F9C3D4")
                    .IsUnique();

                entity.Property(e => e.Diretor1)
                    .IsRequired()
                    .HasColumnName("Diretor")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lancamento>(entity =>
            {
                entity.HasKey(e => e.IdLancamento);

                entity.HasIndex(e => e.NomeMidia)
                    .HasName("UQ__Lancamen__2A1D5AE668D89AC6")
                    .IsUnique();

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeMidia)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse).HasColumnType("text");

                entity.Property(e => e.TempoDuracao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Lancamento)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Lancament__IdCat__5224328E");

                entity.HasOne(d => d.IdDiretorNavigation)
                    .WithMany(p => p.Lancamento)
                    .HasForeignKey(d => d.IdDiretor)
                    .HasConstraintName("FK__Lancament__IdDir__531856C7");

                entity.HasOne(d => d.IdPlataformaNavigation)
                    .WithMany(p => p.Lancamento)
                    .HasForeignKey(d => d.IdPlataforma)
                    .HasConstraintName("FK__Lancament__IdPla__540C7B00");

                entity.HasOne(d => d.IdTipoMidiaNavigation)
                    .WithMany(p => p.Lancamento)
                    .HasForeignKey(d => d.IdTipoMidia)
                    .HasConstraintName("FK__Lancament__IdTip__51300E55");
            });

            modelBuilder.Entity<Plataforma>(entity =>
            {
                entity.HasKey(e => e.IdPlataforma);

                entity.HasIndex(e => e.Plataforma1)
                    .HasName("UQ__Platafor__3FCED092F997289D")
                    .IsUnique();

                entity.Property(e => e.Plataforma1)
                    .IsRequired()
                    .HasColumnName("Plataforma")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoMidia>(entity =>
            {
                entity.HasKey(e => e.IdTipoMidia);

                entity.HasIndex(e => e.TipoMidia1)
                    .HasName("UQ__TipoMidi__5A95DFD87F2BDE1C")
                    .IsUnique();

                entity.Property(e => e.TipoMidia1)
                    .IsRequired()
                    .HasColumnName("TipoMidia")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.HasIndex(e => e.TipoUsuario1)
                    .HasName("UQ__TipoUsua__52F7E3AA5C72301B")
                    .IsUnique();

                entity.Property(e => e.TipoUsuario1)
                    .IsRequired()
                    .HasColumnName("TipoUsuario")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Usuario__C1F8973163E18013")
                    .IsUnique();

                entity.HasIndex(e => e.EmailUsuario)
                    .HasName("UQ__Usuario__59FA3B65822311CE")
                    .IsUnique();

                entity.HasIndex(e => e.Telefone)
                    .HasName("UQ__Usuario__4EC504B69E9E2781")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DataDeNascimento).HasColumnType("date");

                entity.Property(e => e.EmailUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.TipoUsuario)
                    .HasConstraintName("FK__Usuario__TipoUsu__59C55456");
            });
        }
    }
}
