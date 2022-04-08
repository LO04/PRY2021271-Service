using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Montrac.api.DataObjects.User;
using Montrac.Domain.DataObjects.Invitation;
using Montrac.Domain.DataObjects.Url;
using Montrac.Domain.Models;
using Montrac.Persistence.Extensions;

namespace Montrac.Persistence
{
    public class MontracDbContext : DbContext
    {
        //public DbSet<Area> Areas { get; set; }
        public DbSet<Screenshot> Details { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<UrlReceived> UrlReceiveds { get; set; }
        public DbSet<InvitationRequest> Invitations { get; set; }

        public MontracDbContext(DbContextOptions<MontracDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Area>().HasKey(x => x.Id);
            //builder.Entity<Area>().Property(x => x.Id)
            //    .IsRequired()
            //    .ValueGeneratedOnAdd();
            //builder.Entity<Area>().HasMany(x => x.Users)
            //    .WithMany(x => x.Areas);

            builder.Entity<Screenshot>().HasKey(x => x.Id);
            builder.Entity<Screenshot>().Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Entity<Program>().HasKey(x => x.Id);
            builder.Entity<Program>().Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Entity<Url>().HasKey(x => x.Id);
            builder.Entity<Url>().Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Entity<UrlReceived>().HasKey(x => x.Id);
            builder.Entity<UrlReceived>().Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<User>().Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Entity<User>().HasMany(x => x.Programs)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId);
            builder.Entity<User>().HasMany(x => x.Screenshots)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.Entity<InvitationRequest>().HasKey(x => x.Id);
            builder.Entity<InvitationRequest>().Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.ApplySnakeCaseNamingConvention();
        }
    }
}