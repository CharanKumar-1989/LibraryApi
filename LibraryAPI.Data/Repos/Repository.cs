using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryAPI.Data.Repos
{
	public class Repository<T> : IRepository<T> where T : class
	{
		protected readonly DbContext dbContext;
		public Repository(DbContext _dbContext)
		{
			dbContext = _dbContext;
		}
		public void Add(T item)
		{
			dbContext.Set<T>().Add(item);
			dbContext.SaveChanges();
		}

		public IQueryable<T> GetAll()
		{
			return dbContext.Set<T>();
		}
	}
}
