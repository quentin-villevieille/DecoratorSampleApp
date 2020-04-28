using DecoratorSampleApp.Models;
using DecoratorSampleApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorSampleApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MovieController : ControllerBase
	{
		private readonly IGenericRepository<Movie> _repo;

		public MovieController(IGenericRepository<Movie> repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_repo.GetById(2));
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
