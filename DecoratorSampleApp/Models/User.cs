namespace DecoratorSampleApp.Models
{
	public class User : IEntity
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
	}
}
