using System.ComponentModel.DataAnnotations;

namespace IdentityApi.Models
{
	public class AuthenticationRequest
	{
		[Required]
		[EmailAddress]
		public string EmailID { get;set;}
		
		[Required]
		public string Password { get; set; }
	}
}
