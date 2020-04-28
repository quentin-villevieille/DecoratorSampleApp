using System.Collections.Generic;
using System.Linq;

namespace DecoratorSampleApp.Services
{
	public class GenericRepository<T> : IGenericRepository<T> where T : IEntity
	{
		protected List<T> List;

		public GenericRepository()
		{
		}

		public T GetById(int id)
		{
			return List.FirstOrDefault(t => t.Id == id);
		}
	}
}
