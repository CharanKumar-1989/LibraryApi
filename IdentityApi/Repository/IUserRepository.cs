using IdentityApi.Models;

namespace IdentityApi.Repository
{
	public interface IUserRepository
	{
		User GetUserByEmail(string emailID);
	}
}
