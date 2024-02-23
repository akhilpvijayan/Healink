using Healink.Entities;
using Healink.Xobjects.SeedScripts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Emit;

namespace Healink.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<OrganizationDetail> OrganizationDetails { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<IndustryType> IndustryTypes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserSkill> UserSkill { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Connection>()
                .HasOne(c => c.Sender)
                .WithMany(u => u.SentUser)
                .HasForeignKey(c => c.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // Specify DeleteBehavior.Restrict
            modelBuilder.Entity<Connection>()
                .HasOne(c => c.Receiver)
                .WithMany(u => u.ReceivedUser)
                .HasForeignKey(c => c.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); // Specify DeleteBehavior.Restrict

            modelBuilder.Entity<Message>()
               .HasOne(c => c.Sender)
               .WithMany(u => u.SentMessages)
               .HasForeignKey(c => c.SenderId)
               .OnDelete(DeleteBehavior.Restrict); // Specify DeleteBehavior.Restrict
            modelBuilder.Entity<Message>()
                .HasOne(c => c.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(c => c.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); // Specify DeleteBehavior.Restrict

            modelBuilder.Entity<Comment>()
               .HasOne(c => c.User)
               .WithMany(u => u.UserComment)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Restrict); // Specify DeleteBehavior.Restrict

            modelBuilder.Entity<Job>()
               .HasOne(c => c.User)
               .WithMany(u => u.UserJob)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Restrict); // Specify DeleteBehavior.Restrict

            modelBuilder.Entity<State>()
               .HasOne(c => c.UserCountry)
               .WithMany(u => u.UCountry)
               .HasForeignKey(c => c.CountryId)
               .OnDelete(DeleteBehavior.Restrict); // Specify DeleteBehavior.Restrict

            modelBuilder.Entity<UserDetail>()
               .HasOne(c => c.UserState)
               .WithMany(u => u.UState)
               .HasForeignKey(c => c.StateId)
               .OnDelete(DeleteBehavior.Restrict); // Specify DeleteBehavior.Restrict
        }
    }

}
