using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace DecoratorSampleApp
{
	public class Program
	{
		internal static readonly string Namespace = typeof(Program).Namespace;
		internal static readonly string AppName = "DecoratorSampleApp";

		public static int Main(string[] args)
		{
			IConfiguration configuration = GetConfiguration();

			Log.Logger = CreateSerilogLogger(configuration);

			try
			{
				Log.Information("Configuring web host ({ApplicationContext})...", AppName);
				var host = BuildWebHost(configuration, args);

				Log.Information("Starting web host ({ApplicationContext})...", AppName);
				host.Run();

				return 0;
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
				return 1;
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}

		private static IConfiguration GetConfiguration()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddEnvironmentVariables()
			;
			return builder.Build();
		}
		private static IHost BuildWebHost(IConfiguration configuration, string[] args)
		{
			return Host
				.CreateDefaultBuilder(args)
				.UseServiceProviderFactory(new AutofacServiceProviderFactory())
				.ConfigureWebHostDefaults(webHostBuilder => webHostBuilder
					.UseStartup<Startup>()
					.UseContentRoot(Directory.GetCurrentDirectory())
					.UseConfiguration(configuration)
					.UseSerilog())
				.Build();
		}
		private static Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
		{
			return new LoggerConfiguration()
				.MinimumLevel.Verbose()
				.Enrich.FromLogContext()
				.WriteTo.Console()
				.ReadFrom.Configuration(configuration)
				.CreateLogger();
		}
	}
}
