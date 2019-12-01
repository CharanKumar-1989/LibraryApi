using LibraryAPI.Data.Models;
using System.Collections.Generic;

namespace LibraryAPI.Data
{
	public interface IService
	{
		public void AddBook(Book book);
		public IEnumerable<Book> GetBooks(string bookName, string authorName, string publisher);
	}
}
