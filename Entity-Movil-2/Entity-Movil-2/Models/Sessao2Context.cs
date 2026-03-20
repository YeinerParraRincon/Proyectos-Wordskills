using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entity_Movil_2.Models;

public partial class Sessao2Context : DbContext
{
    public Sessao2Context()
    {
    }

    public Sessao2Context(DbContextOptions<Sessao2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Estadio> Estadios { get; set; }

    public virtual DbSet<Imagen> Imagens { get; set; }

    public virtual DbSet<Jogador> Jogadors { get; set; }

    public virtual DbSet<Jogo> Jogos { get; set; }

    public virtual DbSet<Selecao> Selecaos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estadio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estadio__3214EC0723D41ADC");

            entity.ToTable("Estadio");

            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Imagens__06370DADEAD179B5");

            entity.Property(e => e.Codigo).ValueGeneratedNever();
            entity.Property(e => e.Arquivo).HasColumnType("image");

            entity.HasOne(d => d.CodigoNavigation).WithOne(p => p.Imagen)
                .HasForeignKey<Imagen>(d => d.Codigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Imagens_Jogador");
        });

        modelBuilder.Entity<Jogador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Jogador__3214EC0776BBDC69");

            entity.ToTable("Jogador");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Informacoes).HasColumnType("text");
            entity.Property(e => e.Nascimento).HasColumnType("datetime");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Posicao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.QtdecartoesAmarelo)
                .HasDefaultValue(0)
                .HasColumnName("QTDECartoesAmarelo");
            entity.Property(e => e.QtdecartoesVermelho)
                .HasDefaultValue(0)
                .HasColumnName("QTDECartoesVermelho");
            entity.Property(e => e.Qtdefaltas)
                .HasDefaultValue(0)
                .HasColumnName("QTDEFaltas");
            entity.Property(e => e.Qtdegols)
                .HasDefaultValue(0)
                .HasColumnName("QTDEGols");
            entity.Property(e => e.SelecaoId).HasColumnName("SelecaoID");

            entity.HasOne(d => d.Selecao).WithMany(p => p.Jogadors)
                .HasForeignKey(d => d.SelecaoId)
                .HasConstraintName("FK__Jogador__Selecao__4222D4EF");
        });

        modelBuilder.Entity<Jogo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Jogo__3214EC07C2251C83");

            entity.ToTable("Jogo");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Data).HasColumnType("datetime");

            entity.HasOne(d => d.EstadioNavigation).WithMany(p => p.Jogos)
                .HasForeignKey(d => d.Estadio)
                .HasConstraintName("FK__Jogo__Estadio__4316F928");

            entity.HasOne(d => d.SelecaoCasaNavigation).WithMany(p => p.JogoSelecaoCasaNavigations)
                .HasForeignKey(d => d.SelecaoCasa)
                .HasConstraintName("FK__Jogo__SelecaoCas__440B1D61");

            entity.HasOne(d => d.SelecaoVisitanteNavigation).WithMany(p => p.JogoSelecaoVisitanteNavigations)
                .HasForeignKey(d => d.SelecaoVisitante)
                .HasConstraintName("FK__Jogo__SelecaoVis__44FF419A");
        });

        modelBuilder.Entity<Selecao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Selecao__3214EC072A6B933C");

            entity.ToTable("Selecao");

            entity.Property(e => e.Bandeira).HasColumnType("image");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC079B71290C");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Apelido, "UQ__Usuario__571DBAE6B4932FFB").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105348D7DE5A0").IsUnique();

            entity.Property(e => e.Apelido)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Perfil)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Normal");
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
