using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GrumingAPI.Models;

public partial class DBGruming : DbContext
{
    public DBGruming()
    {
    }

    public DBGruming(DbContextOptions<DBGruming> options)
        : base(options)
    {
    }

    public virtual DbSet<Breed> Breeds { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientPet> ClientPets { get; set; }

    public virtual DbSet<Complex> Complexes { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<TypeAnimal> TypeAnimals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Gruming;Username=postgres;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Breed>(entity =>
        {
            entity.HasKey(e => e.IdBreed).HasName("newtable_pk");

            entity.ToTable("breed");

            entity.Property(e => e.IdBreed)
                .UseIdentityByDefaultColumn()
                .HasColumnName("id_breed");
            entity.Property(e => e.AddTime)
                .HasComment("Доп время")
                .HasColumnName("add_time");
            entity.Property(e => e.Markup)
                .HasComment("Наценка")
                .HasColumnName("markup");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("client_pk");

            entity.ToTable("client");

            entity.Property(e => e.IdClient)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_client");
            entity.Property(e => e.Comment).HasColumnType("character varying");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("fio");
            entity.Property(e => e.Role)
                .HasDefaultValueSql("USER")
                .HasColumnType("character varying");
            entity.Property(e => e.VkId).HasColumnName("vk_id");
        });

        modelBuilder.Entity<ClientPet>(entity =>
        {
            entity.HasKey(e => e.IdPet).HasName("client_pets_pk");

            entity.ToTable("client_pets");

            entity.Property(e => e.IdPet)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_pet");
            entity.Property(e => e.Comment).HasColumnType("character varying");
            entity.Property(e => e.IdBreed).HasColumnName("id_breed");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.Name).HasColumnType("character varying");

            entity.HasOne(d => d.IdBreedNavigation).WithMany(p => p.ClientPets)
                .HasForeignKey(d => d.IdBreed)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_pets_breed_fk");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.ClientPets)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_pets_client_fk");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.ClientPets)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_pets_type_animal_fk");
        });

        modelBuilder.Entity<Complex>(entity =>
        {
            entity.HasKey(e => e.IdComp).HasName("complexes_pk");

            entity.ToTable("complexes");

            entity.Property(e => e.IdComp)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_comp");

            entity.HasMany(d => d.IdServices).WithMany(p => p.IdComps)
                .UsingEntity<Dictionary<string, object>>(
                    "ComplexService",
                    r => r.HasOne<Service>().WithMany()
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("complex_services_services_fk_1"),
                    l => l.HasOne<Complex>().WithMany()
                        .HasForeignKey("IdComp")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("complex_services_complexes_fk"),
                    j =>
                    {
                        j.HasKey("IdComp", "IdService").HasName("complex_services_pk");
                        j.ToTable("complex_services");
                        j.IndexerProperty<int>("IdComp").HasColumnName("id_comp");
                        j.IndexerProperty<int>("IdService").HasColumnName("id_service");
                    });
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.IdHistory).HasName("history_pk");

            entity.ToTable("history");

            entity.Property(e => e.IdHistory)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_history");
            entity.Property(e => e.Comment).HasColumnType("character varying");
            entity.Property(e => e.IdComp).HasColumnName("id_comp");
            entity.Property(e => e.IdPet).HasColumnName("id_pet");
            entity.Property(e => e.IsComplete)
                .HasColumnType("bit(1)")
                .HasColumnName("is_complete");
            entity.Property(e => e.PlanDate).HasColumnName("plan_date");

            entity.HasOne(d => d.IdCompNavigation).WithMany(p => p.Histories)
                .HasForeignKey(d => d.IdComp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("history_complexes_fk");

            entity.HasOne(d => d.IdPetNavigation).WithMany(p => p.Histories)
                .HasForeignKey(d => d.IdPet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("history_client_pets_fk");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdService).HasName("services_pk");

            entity.ToTable("services");

            entity.Property(e => e.IdService)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_service");
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<TypeAnimal>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("type_animal_pk");

            entity.ToTable("type_animal");

            entity.Property(e => e.IdType)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_type");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
