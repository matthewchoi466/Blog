using Microsoft.EntityFrameworkCore;
using Blog.Domain.Models;
using System;

namespace Blog.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			

			builder.Entity<User>().ToTable("Users");
			builder.Entity<User>().HasKey(p => p.Id);
			builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
			builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(100);
			builder.Entity<User>().Property(p => p.Email).IsRequired();
			builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(20);
			builder.Entity<User>().Property(p => p.Role).IsRequired();
            builder.Entity<User>().HasMany(p => p.Articles).WithOne(p => p.Author).HasForeignKey(p => p.AuthorUserID);

            builder.Entity<User>().HasData
            (
                new User
                {
                    Id = 100,
                    Name = "Superman",
                    Email = "abc@dummy.com",
                    Password = "12345",
                    Role = EUserRole.Administrator
                },
                new User
                {
                    Id = 101,
                    Name = "Wai Gor",
                    Email = "def@dummy.com",
                    Password = "12345",
                    Role = EUserRole.Administrator
                }
            );

            builder.Entity<Article>().ToTable("Articles");
            builder.Entity<Article>().HasKey(p => p.Id);
            builder.Entity<Article>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Article>().Property(p => p.Title).IsRequired().HasMaxLength(200);
            builder.Entity<Article>().Property(p => p.PublishedDateTime).IsRequired();
            builder.Entity<Article>().Property(p => p.Content).IsRequired();


            builder.Entity<Article>().HasData
            (
                new Article
                {
                    Id = 100,
                    Title = "First Article",
                    PublishedDateTime = DateTime.Now,
                    Content = "Dummy Content",
                    AuthorUserID = 100
                },
                new Article
                {
                    Id = 101,
                    Title = "Second Article",
                    PublishedDateTime = DateTime.Now,
                    Content = "Dummy Content2",
                    AuthorUserID = 101
                }
            );
        }
	}
}
