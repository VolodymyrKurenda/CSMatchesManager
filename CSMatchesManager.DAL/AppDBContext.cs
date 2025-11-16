using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSMatchesManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSMatchesManager.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Teams> Teams { get; set; }

        public DbSet<Matches> Matches { get; set; }

        public DbSet<Players> Players { get; set; }

        public DbSet<Teams_Match> Teams_Matches { get; set; }

        public DbSet<Statistic> Statistics { get; set; }

        public DbSet<Rewards> Rewards { get; set; }

        private string ConectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CSManager;Integrated Security=True;Connect Timeout=30;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Matches>()
            .Property(m => m.Date)
            .HasConversion(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d));

            modelBuilder.Entity<Players>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.Team_id);

            modelBuilder.Entity<Players>()
                .HasOne(p => p.Rewards)
                .WithOne(r => r.Player)
                .HasForeignKey<Rewards>(r => r.Player_id);

            modelBuilder.Entity<Statistic>()
                .HasOne(s => s.Player)
                .WithMany(p => p.Statistics)
                .HasForeignKey(s => s.Player_id);

            modelBuilder.Entity<Statistic>()
                .HasOne(s => s.Match)
                .WithMany(m => m.Stats)
                .HasForeignKey(s => s.Match_id);

            modelBuilder.Entity<Teams_Match>()
            .HasOne(cm => cm.Team1)
            .WithMany(c => c.Team1_Matches)
            .HasForeignKey(cm => cm.Team1_id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teams_Match>()
                .HasOne(cm => cm.Team2)
                .WithMany(c => c.Team2_Matches)
                .HasForeignKey(cm => cm.Team2_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teams_Match>()
                .HasOne(cm => cm.Matches)
                .WithMany(m => m.Teams_Matches)
                .HasForeignKey(cm => cm.MatchID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
