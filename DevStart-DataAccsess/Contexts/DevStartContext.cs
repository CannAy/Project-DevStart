using Azure;
using DevStart_DataAccsess.Identity;
using DevStart_Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStart_DataAccsess.Contexts
{
	public class DevStartContext : IdentityDbContext<AppUser, AppRole, Guid>
	{
		public DevStartContext(DbContextOptions<DevStartContext> options) : base(options) { } //constructor tanımlıyoruz..
		public DbSet<Category> Categories { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<CourseSale> CoursesSales { get; set; }
		public DbSet<CourseSaleDetail> CoursesSalesDetails { get; set; }
		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Video> Videos { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			// Fluent API Validation
			builder.Entity<Course>().Property("CourseTitle").IsRequired().HasMaxLength(200);
			builder.Entity<Course>().Property("CourseDescription").IsRequired().HasMaxLength(500);
			builder.Entity<Lesson>().Property("LessonTitle").IsRequired().HasMaxLength(200);
			builder.Entity<Lesson>().Property("LessonContent").IsRequired().HasMaxLength(500);
			builder.Entity<Review>().Property("ReviewComment").IsRequired().HasMaxLength(500);
			builder.Entity<Category>().Property("CategoryName").IsRequired().HasMaxLength(50);
			builder.Entity<Category>().Property("CategoryDescription").IsRequired().HasMaxLength(500);
			builder.Entity<Tag>().Property("TagName").IsRequired().HasMaxLength(50);
			builder.Entity<Tag>().Property("TagDescription").IsRequired().HasMaxLength(200);
			builder.Entity<Video>().Property("VideoLink").IsRequired().HasMaxLength(500);

			base.OnModelCreating(builder);


		}
	}
}
