using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
	public class Book
	{
		[Required(ErrorMessage = "{0} field cannot be empty")]
		[StringLength(150, ErrorMessage = "{0} field should not exceed {1} characters")]
		public string BookName { get; set; }
		
		[Required(ErrorMessage = "{0} field cannot be empty")]
		[StringLength(100, ErrorMessage = "{0} field should not exceed {1} characters")]
		public string AuthorName { get; set; }

		[Required]
		[Range(0, 5000, ErrorMessage = "{0} cannot exceed {2}")]
		public double Price { get; set; }
		public string Category { get; set; }
		public string Edition { get; set; }
		public string Publisher { get; set; }
	}
}
