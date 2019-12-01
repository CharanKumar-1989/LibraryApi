using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace LibraryAPI.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/{controller}")]
	public class BooksController : ControllerBase
	{
		private readonly ILogger<BooksController> logger;
		private readonly IService libraryService;
		public BooksController(ILogger<BooksController> _logger, IService _libraryService)
		{
			logger = _logger;
			libraryService = _libraryService;
		}

		/// <summary>
		/// Used to add book to the store
		/// </summary>
		/// <param name="bookToBeAdded">The book that needs to be added</param>
		/// <returns></returns>
		/// <response code="201">Returns the newly created item</response>
		/// <response code="400">If the item is null or if there is any validation error</response>            
		[HttpPost]
		[Authorize(Roles = "Admin")]
		[ProducesResponseType(typeof(Book),201)]
		public IActionResult AddBook(Book bookToBeAdded)
		{
			IActionResult actionResult;
			try
			{
				libraryService.AddBook(new Data.Models.Book()
				{
					AuthorName = bookToBeAdded.AuthorName,
					BookName = bookToBeAdded.BookName,
					Category = bookToBeAdded.Category,
					Edition = bookToBeAdded.Edition,
					Price = bookToBeAdded.Price,
					Publisher = bookToBeAdded.Publisher
				});
				actionResult = Created($"api/Books?bookName={bookToBeAdded.BookName}&author={bookToBeAdded.AuthorName}&publisher={bookToBeAdded.Publisher}",
					bookToBeAdded);
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Exception has occured");
				actionResult = new StatusCodeResult(500);
			}
			return actionResult;
		}

		/// <summary>
		/// Used to get the books that match the seach criteria
		/// </summary>
		/// <param name="searchRequest">search criteria to filter the books</param>
		/// <returns></returns>
		/// <response code="200">When the search is successfull</response>
		/// <response code="400">When there are no search parameters or validation errors</response>
		[HttpGet]
		[Authorize(Roles = "Admin,Customer")]
		[ProducesResponseType(typeof(IEquatable<Book>),200)]
		public IActionResult GetBook([FromQuery]SearchRequest searchRequest)
		{
			IActionResult actionResult;
			try
			{
				var filteredBooks = libraryService.GetBooks(searchRequest.BookName, searchRequest.Author, searchRequest.Publisher);
				actionResult = new OkObjectResult(filteredBooks);
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Exception has occured");
				actionResult = new StatusCodeResult(500);
			}
			return actionResult;
		}
	}
}
