using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
	public class SearchRequest : IValidatableObject
	{
		[StringLength(150, ErrorMessage = "{0} field cannot exceed {1} characters")]
		public string BookName { get; set; }
		[StringLength(100, ErrorMessage = "{0} field should not exceed {1} characters")]
		public string Author { get; set; }
		public string Publisher { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if(string.IsNullOrEmpty(BookName) && string.IsNullOrEmpty(Author) && string.IsNullOrEmpty(Publisher))
			{
				yield return new ValidationResult("Either one of the field is required", new string[] { "(BookName, Author, Publisher)" });
			}
		}
	}
}
