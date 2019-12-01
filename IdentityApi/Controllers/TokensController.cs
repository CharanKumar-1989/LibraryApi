using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityApi.Models;
using IdentityApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IdentityApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TokensController : ControllerBase
	{
		private readonly IUserRepository userRepository;
		private readonly IConfiguration config;
		public TokensController(IUserRepository _userRepository, IConfiguration _config)
		{
			userRepository = _userRepository;
			config = _config;
		}

		[HttpGet]
		public IActionResult GetToken([FromQuery]AuthenticationRequest authenticationRequest)
		{
			User user = ValidateUser(authenticationRequest.EmailID, authenticationRequest.Password);
			if (user == null)
				return new UnauthorizedResult();

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(config["secretKey"]);
			var signCreds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.UserName),
					new Claim(ClaimTypes.Role, user.UserRole)
				}),
				Expires = DateTime.UtcNow.AddHours(14),
				SigningCredentials = signCreds
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return Ok(new
			{
				Token = tokenHandler.WriteToken(token)
			});
		}

		private User ValidateUser(string emailID, string password)
		{
			User user = userRepository.GetUserByEmail(emailID);
			if (user != null && user.Password.Equals(password))
			{
				return user;
			}
			return null;
		}
	}
}