using Microsoft.EntityFrameworkCore;
using Montrac.API.Domain.Models;

namespace Montrac.API.Persistence
{
    public class MontracDbContext : DbContext
    {
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Domain.Models.Program> Programs { get; set; }
        public DbSet<Screenshot> Screenshots { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<User> User { get; set; }

        public MontracDbContext(DbContextOptions<MontracDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Invitation>().HasKey(x => x.Id);
            builder.Entity<Invitation>().Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Entity<Domain.Models.Program>().HasKey(x => x.Id);
            builder.Entity<Domain.Models.Program>().Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Entity<Domain.Models.Program>().HasOne(x => x.User)
                .WithMany(x => x.Programs)
                .HasForeignKey(x => x.UserId);

            builder.Entity<Screenshot>().HasKey(x => x.Id);
            builder.Entity<Screenshot>().Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Entity<Screenshot>().HasOne(x => x.User)
                .WithMany(x => x.Screenshots)
                .HasForeignKey(x => x.UserId);

            builder.Entity<Url>().HasKey(x => x.Id);
            builder.Entity<Url>().Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Entity<Url>().HasOne(x => x.User)
                .WithMany(x => x.Urls)
                .HasForeignKey(x => x.UserId);

            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<User>().Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            //builder.ApplySnakeCaseNamingConvention();
        }
    }
}