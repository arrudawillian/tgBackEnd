//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//#nullable disable

//namespace Sge.Domain.Entities
//{
//    public partial class motofreteo3Context : DbContext
//    {
//        public motofreteo3Context()
//        {
//        }

//        public motofreteo3Context(DbContextOptions<motofreteo3Context> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Curso> Cursos { get; set; }
//        public virtual DbSet<Documento> Documentos { get; set; }
//        public virtual DbSet<Pacote> Pacotes { get; set; }
//        public virtual DbSet<Pagamento> Pagamentos { get; set; }
//        public virtual DbSet<Status> Statuses { get; set; }
//        public virtual DbSet<Unidade> Unidades { get; set; }
//        public virtual DbSet<UnidadePacote> UnidadePacotes { get; set; }
//        public virtual DbSet<Usuario> Usuarios { get; set; }
//        public virtual DbSet<UsuarioDocumento> UsuarioDocumentos { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseSqlServer("Name=DefaultConnection");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP850_CI_AI");

//            modelBuilder.Entity<Curso>(entity =>
//            {
//                entity.ToTable("Curso");

//                entity.Property(e => e.Nome)
//                    .HasMaxLength(200)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<Documento>(entity =>
//            {
//                entity.ToTable("Documento");

//                entity.Property(e => e.Descricao)
//                    .IsRequired()
//                    .HasMaxLength(50)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<Pacote>(entity =>
//            {
//                entity.ToTable("Pacote");

//                entity.Property(e => e.Descricao)
//                    .IsRequired()
//                    .HasMaxLength(50)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<Pagamento>(entity =>
//            {
//                entity.ToTable("Pagamento");

//                entity.Property(e => e.Valor).HasColumnType("money");

//                entity.HasOne(d => d.Usuario)
//                    .WithMany(p => p.Pagamentos)
//                    .HasForeignKey(d => d.UsuarioId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Pagamento_UsuarioId");
//            });

//            modelBuilder.Entity<Status>(entity =>
//            {
//                entity.ToTable("Status");

//                entity.Property(e => e.Descricao)
//                    .IsRequired()
//                    .HasMaxLength(50)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<Unidade>(entity =>
//            {
//                entity.ToTable("Unidade");

//                entity.Property(e => e.Nome)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<UnidadePacote>(entity =>
//            {
//                entity.ToTable("UnidadePacote");

//                entity.HasIndex(e => new { e.UnidadeId, e.PacoteId }, "UK_UnidadePacote")
//                    .IsUnique();

//                entity.Property(e => e.Valor).HasColumnType("money");

//                entity.HasOne(d => d.Pacote)
//                    .WithMany(p => p.UnidadePacotes)
//                    .HasForeignKey(d => d.PacoteId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_UnidadePacote_PacoteId");

//                entity.HasOne(d => d.Unidade)
//                    .WithMany(p => p.UnidadePacotes)
//                    .HasForeignKey(d => d.UnidadeId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_UnidadePacote_UnidadeId");
//            });

//            modelBuilder.Entity<Usuario>(entity =>
//            {
//                entity.ToTable("Usuario");

//                entity.Property(e => e.Celular)
//                    .HasMaxLength(15)
//                    .IsUnicode(false);

//                entity.Property(e => e.Email)
//                    .IsRequired()
//                    .HasMaxLength(100)
//                    .IsUnicode(false);

//                entity.Property(e => e.Identidade)
//                    .HasMaxLength(25)
//                    .IsUnicode(false);

//                entity.Property(e => e.Img)
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.Nome)
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.Senha)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.Sexo)
//                    .HasMaxLength(1)
//                    .IsUnicode(false)
//                    .IsFixedLength(true);

//                entity.HasOne(d => d.Curso)
//                    .WithMany(p => p.Usuarios)
//                    .HasForeignKey(d => d.CursoId)
//                    .HasConstraintName("FK_Usuario_CursoId");

//                entity.HasOne(d => d.Unidade)
//                    .WithMany(p => p.Usuarios)
//                    .HasForeignKey(d => d.UnidadeId)
//                    .HasConstraintName("FK_Usuario_UnidadeId");

//                entity.HasOne(d => d.UnidadePacote)
//                    .WithMany(p => p.Usuarios)
//                    .HasForeignKey(d => d.UnidadePacoteId)
//                    .HasConstraintName("FK_Usuario_PacoteId");
//            });

//            modelBuilder.Entity<UsuarioDocumento>(entity =>
//            {
//                entity.ToTable("UsuarioDocumento");

//                entity.Property(e => e.Path)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.Titulo)
//                    .IsRequired()
//                    .HasMaxLength(100)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.Documento)
//                    .WithMany(p => p.UsuarioDocumentos)
//                    .HasForeignKey(d => d.DocumentoId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_UsuarioDocumento_DocumentoId");

//                entity.HasOne(d => d.Status)
//                    .WithMany(p => p.UsuarioDocumentos)
//                    .HasForeignKey(d => d.StatusId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_UsuarioDocumento_StatusId");

//                entity.HasOne(d => d.Usuario)
//                    .WithMany(p => p.UsuarioDocumentos)
//                    .HasForeignKey(d => d.UsuarioId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_UsuarioDocumento_UsuarioId");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
