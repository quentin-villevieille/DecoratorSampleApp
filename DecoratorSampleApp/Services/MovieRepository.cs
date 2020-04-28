using DecoratorSampleApp.Models;
using System;
using System.Collections.Generic;

namespace DecoratorSampleApp.Services
{
	public class MovieRepository : GenericRepository<Movie>
	{
		public MovieRepository() : base()
		{
			List = new List<Movie>
			{
				new Movie
				{
					Id = 1,
					Name = "Bienvenue chez les Ch'tis",
					Date = new DateTime(2007, 7, 22)
				},
				new Movie
				{
					Id = 2,
					Name = "Félins",
					Date = new DateTime(2012, 4, 22)
				},
			};
		}
	}
}
