using Microsoft.Extensions.Logging;
using System;

namespace DecoratorSampleApp.Services.Decorators
{
	public class GenericRepositoryLogDecorator<T> : IGenericRepository<T>
		where T : IEntity
	{
		private readonly IGenericRepository<T> _decorated;
		private readonly ILogger<GenericRepositoryLogDecorator<T>> _logger;
		
		public GenericRepositoryLogDecorator(
			IGenericRepository<T> decorated, 
			ILogger<GenericRepositoryLogDecorator<T>> logger)
		{
			_decorated = decorated;
			_logger = logger;
		}

		public T GetById(int id)
		{
			try
			{
				_logger.LogInformation("## GenericRepositoryLogDecorator.GetById({Id}) [{Type}]", id, _decorated.GetType());

				// appel de la méthode de l'objet décoré
				return _decorated.GetById(id);
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, "GenericRepositoryLogDecorator.GetById failed");
				throw;
			}
		}
	}
}
