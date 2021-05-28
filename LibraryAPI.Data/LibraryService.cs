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
			AddFewBooks();
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

		private void AddFewBooks()
		{
			bookRepository.Add(new Book() { BookName = "CLR VIA C#", AuthorName = "Jeffrey Richter", Category = "Technical", Edition = "Fourth", Price = 1429.99, Publisher = "Microsoft Press" });
			bookRepository.Add(new Book() { BookName = "C# 9 and .NET 5 – Modern Cross-Platform Development", AuthorName = "Mark J Price", Category = "Technical", Edition = "fifth", Price = 2943, Publisher = "Packt" });
			bookRepository.Add(new Book() { BookName = "Artificial Intelligence", AuthorName = "Russell", Category = "Technical", Edition = "Third", Price = 792, Publisher = "Pearson" });
			
		}
	}
}
