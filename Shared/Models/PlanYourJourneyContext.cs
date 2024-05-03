using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JourneyPlanner.Shared.Models
{
    public partial class PlanYourJourneyContext : DbContext
    {
        public PlanYourJourneyContext()
        {
        }

        public PlanYourJourneyContext(DbContextOptions<PlanYourJourneyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
