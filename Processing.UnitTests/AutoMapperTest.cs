using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Processing.Core.Startup;

namespace Processing.UnitTests;

public class AutoMapperTest
{
	[TestCase]
	public void CheckAutoMapper()
	{
		var serviceCollection = new ServiceCollection();
		serviceCollection.AddAutoMapper(typeof(ServiceCollectionExtension));
		serviceCollection.BuildServiceProvider();
		
		var configuration = new MapperConfiguration(
			cfg => cfg.AddMaps(typeof(ServiceCollectionExtension))
		);

		configuration.AssertConfigurationIsValid();
	}
}

