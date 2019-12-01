using LibraryAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
	public class InMemoryDbContext : DbContext
	{
		public InMemoryDbContext(DbContextOptions options) : base(options)
		{
		}
		//public DbSet<Book> Books { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>()
				.HasKey(c => new { c.AuthorName, c.BookName });
		}
	}
}
