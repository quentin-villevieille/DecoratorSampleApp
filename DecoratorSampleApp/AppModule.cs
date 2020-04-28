using Autofac;
using DecoratorSampleApp.Models;
using DecoratorSampleApp.Services;
using DecoratorSampleApp.Services.Decorators;

namespace DecoratorSampleApp
{
	public class AppModule:Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			// Register individual components
			builder
				.RegisterType<UserRepository>()
				.As<IGenericRepository<User>>()
				.InstancePerLifetimeScope();

			builder
				.RegisterType<MovieRepository>()
				.As<IGenericRepository<Movie>>()
				.InstancePerLifetimeScope();

			// Decorators
			builder.RegisterGenericDecorator(
				typeof(GenericRepositoryLogDecorator<>),
				typeof(IGenericRepository<>)
			);
			builder.RegisterGenericDecorator(
				typeof(GenericRepositoryCacheDecorator<>),
				typeof(IGenericRepository<>)
			);
		}
	}
}
