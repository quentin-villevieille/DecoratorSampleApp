using Microsoft.Extensions.Caching.Memory;
using System;

namespace DecoratorSampleApp.Services.Decorators
{
	public class GenericRepositoryCacheDecorator<T> : IGenericRepository<T>
		where T : IEntity
	{
		private readonly IGenericRepository<T> _decorated;
		private readonly IMemoryCache _cache;
		
		public GenericRepositoryCacheDecorator(
			IGenericRepository<T> decorated,
			IMemoryCache cache)
		{
			_decorated = decorated;
			_cache = cache;
		}

		public T GetById(int id)
		{
			var cacheKey = $"{_decorated.GetType()}_{id}";
			return _cache.GetOrCreate(cacheKey, entry =>
			{
				entry.SetSlidingExpiration(TimeSpan.FromSeconds(60));

				// appel de la méthode de l'objet décoré
				return _decorated.GetById(id);
			});
		}
	}
}
