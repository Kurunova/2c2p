using Microsoft.Extensions.DependencyInjection;
using Processing.Core.Interfaces;
using Processing.Core.Services;
using Processing.Importer.Startup;

namespace Processing.Core.Startup;

public static class ServiceCollectionExtension
{
	public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddImporter();
		serviceCollection.AddTransient<IImportService, ImportService>();

		return serviceCollection;
	}
}