namespace DecoratorSampleApp.Services
{
	public interface IGenericRepository<T> where T : IEntity
	{
		T GetById(int id);
	}
}
