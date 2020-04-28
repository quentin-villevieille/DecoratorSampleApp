using DecoratorSampleApp.Models;
using DecoratorSampleApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorSampleApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IGenericRepository<User> _userRepository;

		public UserController(IGenericRepository<User> userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_userRepository.GetById(1));
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
