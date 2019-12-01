using LibraryAPI.Data.Models;

namespace LibraryAPI.Data.Repos
{
	public class BookRepository : Repository<Book>
	{
		//private readonly InMemoryDbContext inMememoryDbContext;
		public BookRepository(InMemoryDbContext _dbContext) : base(_dbContext)
		{
		}		
	}
}
