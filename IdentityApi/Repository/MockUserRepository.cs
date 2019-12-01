using IdentityApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentityApi.Repository
{
	public class MockUserRepository : IUserRepository
	{
		readonly IEnumerable<User> UserCollection;
		public MockUserRepository()
		{
			UserCollection = new List<User>()
			{
				new User() { UserID =1, UserName ="Tony Stark", Email ="tony_stark@gmail.com", UserRole = "Customer" , Password = "Abcd@123"},
				new User() { UserID =10, UserName ="Steven Rogers", Email ="steven_rogers@gmail.com", UserRole = "Customer" , Password = "Abcd@123"},
				new User() { UserID =100, UserName ="Bruce Banner", Email ="bruce_banner@gmail.com", UserRole = "Customer" , Password = "Abcd@123"},
				new User() { UserID =1000, UserName ="Scott Lang", Email ="scott_lang@gmail.com", UserRole = "Customer" , Password = "Abcd@123"},
				new User() { UserID =10000, UserName ="Natasha Romanoff", Email ="natasha_romanoff@heritagebooks.com", UserRole = "Admin" , Password = "Pass@123"},
			};
		}

		public User GetUserByEmail(string emailID)
		{
			return UserCollection.FirstOrDefault(usr => usr.Email.Equals(emailID, StringComparison.InvariantCultureIgnoreCase));
		}
	}
}
