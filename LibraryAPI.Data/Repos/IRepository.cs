using System.Linq;

namespace LibraryAPI.Data.Repos
{
	public interface IRepository <T> where T : class
	{
		void Add(T item);
		IQueryable<T> GetAll();
	}
}
