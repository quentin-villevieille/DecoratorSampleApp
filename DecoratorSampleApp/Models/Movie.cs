using System;

namespace DecoratorSampleApp.Models
{
	public class Movie : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
	}
}
