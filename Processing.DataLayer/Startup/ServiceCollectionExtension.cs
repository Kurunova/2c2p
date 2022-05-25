using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Processing.Core.Interfaces;

namespace Processing.DataLayer.Startup;

public static class ServiceCollectionExtension
{
	public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
	{
		serviceCollection.AddDbContextFactory<ProcessingDataContext>(builder =>
			{
				builder.UseNpgsql(
					configuration.GetConnectionString("ProcessingNpgsqlConnection"),
					x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName));
			})
			.AddSingleton<DbContext, ProcessingDataContext>();
		
		serviceCollection.AddSingleton(typeof(IRepository<>), typeof(Repository<>));

		return serviceCollection;
	}
}