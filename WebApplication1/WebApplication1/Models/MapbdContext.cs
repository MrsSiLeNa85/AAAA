using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class MapbdContext : DbContext
{
    public MapbdContext()
    {
    }

    public MapbdContext(DbContextOptions<MapbdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Government> Governments { get; set; }

    public virtual DbSet<Img> Imgs { get; set; }

    public virtual DbSet<Inhabitant> Inhabitants { get; set; }

    public virtual DbSet<Kingdom> Kingdoms { get; set; }

    public virtual DbSet<Landscape> Landscapes { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<NeighRegion> NeighRegions { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Settlement> Settlements { get; set; }

    public virtual DbSet<Temperature> Temperatures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Government>(entity =>
        {
            entity.Property(e => e.GovernmentId).HasColumnName("GovernmentID");
            entity.Property(e => e.KingdomId).HasColumnName("KingdomID");
            entity.Property(e => e.LeaderName).HasMaxLength(70);

            entity.HasOne(d => d.Kingdom).WithMany(p => p.Governments)
                .HasForeignKey(d => d.KingdomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Governments_﻿﻿kingdoms");
        });

        modelBuilder.Entity<Img>(entity =>
        {
            entity.HasKey(e => e.ImageId);

            entity.ToTable("Img");

            entity.Property(e => e.ImageId).HasColumnName("ImageID");
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.RegionId).HasColumnName("RegionID");

            entity.HasOne(d => d.Region).WithMany(p => p.Imgs)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Img_Regions");
        });

        modelBuilder.Entity<Inhabitant>(entity =>
        {
            entity.Property(e => e.InhabitantId).HasColumnName("InhabitantID");
            entity.Property(e => e.KingdomId).HasColumnName("KingdomID");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Kingdom).WithMany(p => p.Inhabitants)
                .HasForeignKey(d => d.KingdomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inhabitants_﻿﻿kingdoms");
        });

        modelBuilder.Entity<Kingdom>(entity =>
        {
            entity.ToTable("﻿﻿kingdoms");

            entity.Property(e => e.KingdomId).HasColumnName("KingdomID");
            entity.Property(e => e.GovernmentId).HasColumnName("GovernmentID");
            entity.Property(e => e.KingdomName)
                .HasMaxLength(50)
                .HasColumnName("kingdomName");
            entity.Property(e => e.Language).HasMaxLength(20);
            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.Trading).HasMaxLength(270);

            entity.HasOne(d => d.Region).WithMany(p => p.Kingdoms)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_﻿﻿kingdoms_Regions");
        });

        modelBuilder.Entity<Landscape>(entity =>
        {
            entity.Property(e => e.LandscapeId).HasColumnName("LandscapeID");
            entity.Property(e => e.LandscapeType).HasMaxLength(150);
            entity.Property(e => e.RegionId).HasColumnName("RegionID");

            entity.HasOne(d => d.Region).WithMany(p => p.Landscapes)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Landscapes_Regions");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.KingdomId).HasColumnName("KingdomID");
            entity.Property(e => e.LanguageName).HasMaxLength(50);

            entity.HasOne(d => d.Kingdom).WithMany(p => p.Languages)
                .HasForeignKey(d => d.KingdomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Languages_﻿﻿kingdoms");
        });

        modelBuilder.Entity<NeighRegion>(entity =>
        {
            entity.HasKey(e => e.RegionId);

            entity.Property(e => e.RegionId)
                .ValueGeneratedNever()
                .HasColumnName("RegionID");
            entity.Property(e => e.RegionId1).HasColumnName("RegionID1");
            entity.Property(e => e.RegionId2).HasColumnName("RegionID2");
            entity.Property(e => e.RegionId3).HasColumnName("RegionID3");

            entity.HasOne(d => d.RegionId1Navigation).WithMany(p => p.NeighRegions)
                .HasForeignKey(d => d.RegionId1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NeighRegions_Regions1");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.Climate).HasMaxLength(30);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.RegionName).HasMaxLength(50);
        });

        modelBuilder.Entity<Settlement>(entity =>
        {
            entity.Property(e => e.SettlementId).HasColumnName("SettlementID");
            entity.Property(e => e.KingdomId).HasColumnName("KingdomID");
            entity.Property(e => e.SettlementName).HasMaxLength(50);

            entity.HasOne(d => d.Kingdom).WithMany(p => p.Settlements)
                .HasForeignKey(d => d.KingdomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Settlements_﻿﻿kingdoms");
        });

        modelBuilder.Entity<Temperature>(entity =>
        {
            entity.Property(e => e.TemperatureId).HasColumnName("TemperatureID");
            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.Season).HasMaxLength(30);

            entity.HasOne(d => d.Region).WithMany(p => p.Temperatures)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Temperatures_Regions");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
