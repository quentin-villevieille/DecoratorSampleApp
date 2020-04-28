using DecoratorSampleApp.Models;
using System.Collections.Generic;

namespace DecoratorSampleApp.Services
{
	public class UserRepository : GenericRepository<User>
	{
		public UserRepository()
		{
			List = new List<User>
			{
				new User
				{
					Id = 1,
					Email = "someone@gmail.com",
					Username = "Someone"
				},
				new User
				{
					Id = 2,
					Email = "no.one@gmail.com",
					Username = "No One"
				}
			};
		}
	}
}
