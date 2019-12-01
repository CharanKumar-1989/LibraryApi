using System.Linq;
using System.Collections.Generic;
using LibraryAPI.Data.Models;
using LibraryAPI.Data.Repos;

namespace LibraryAPI.Data
{
	public class LibraryService : IService
	{
		readonly IRepository<Book> bookRepository;
		public LibraryService(IRepository<Book> _bookRepository)
		{
			bookRepository = _bookRepository;
		}

		public void AddBook(Book book)
		{
			bookRepository.Add(book);
		}

		public IEnumerable<Book> GetBooks(string bookName, string authorName, string publisher)
		{
			var books = bookRepository.GetAll();
			if (!string.IsNullOrEmpty(bookName))
				books = books.Where(book => book.BookName.Equals(bookName));

			if(!string.IsNullOrEmpty(authorName))
				books = books.Where(book => book.AuthorName.Equals(authorName));
   
			if(!string.IsNullOrEmpty(publisher))
				books = books.Where(book => book.Publisher.Equals(publisher));

			return books.AsEnumerable();				
		}
	}
}
