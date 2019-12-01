namespace IdentityApi.Models
{
	public class User
	{
		public long UserID { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string UserRole { get; set; }
		public string Password { get; internal set; }
	}
}
