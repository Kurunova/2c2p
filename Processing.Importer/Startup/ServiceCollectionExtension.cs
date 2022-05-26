using Microsoft.Extensions.DependencyInjection;
using Processing.Importer.Interfaces;
using Processing.Importer.Services;

namespace Processing.Importer.Startup;

public static class ServiceCollectionExtension
{
	public static IServiceCollection AddImporter(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddTransient<IImporterFactory, ImporterFactory>();
		serviceCollection.AddTransient<IImporter, CsvImporter>();
		serviceCollection.AddTransient<IImporter, XmlImporter>();

		return serviceCollection;
	}
}