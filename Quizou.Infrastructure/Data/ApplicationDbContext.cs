using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Quizou.Domain.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    // DbSets for your entities
    public DbSet<User> Users { get; set; }    
    public DbSet<Category> Categories { get; set; } 
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Battle> Battles { get; set; }
    public DbSet<History> Histories { get; set; }
    public DbSet<UserFriend> UserFriends { get; set; }
    public DbSet<Tag> Tags { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserFriend>()
            .HasKey(uf => new { uf.UserId, uf.FriendId });

        modelBuilder.Entity<UserFriend>()
            .HasOne(uf => uf.User)
            .WithMany(u => u.Friends)
            .HasForeignKey(uf => uf.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}