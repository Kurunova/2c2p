using System;
using System.IO;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Processing.Core.Entities;
using Processing.Core.Interfaces;
using Processing.Core.Startup;

namespace Processing.UnitTests;

public class ImportTest : BaseTest
{
	public ServiceProvider GetServiceProvider()
	{
		var serviceCollection = new ServiceCollection();
		serviceCollection.AddAutoMapper(typeof(ServiceCollectionExtension));

		var repositoryMock = new Mock<IRepository<Transaction>>();
		serviceCollection.AddSingleton(repositoryMock.Object);
		serviceCollection.AddCore();
		
		var serviceProvider = serviceCollection.BuildServiceProvider();
		return serviceProvider;
	}
	
	[TestCase("example.csv")]
	[TestCase("example.xml")]
	public void Import_Imported(string fileName)
	{
		// Arrange
		var path = Path.Combine(DirectoryName, fileName);
		var file = File.ReadAllBytes(path);

		var serviceProvider = GetServiceProvider();
		IImportService importService = serviceProvider.GetRequiredService<IImportService>();
		
		// Act
		Action importAction = () => importService.Import(fileName, file);
	
		// Assert
		importAction.Should().NotThrow();
	}
	
	[TestCase("example.json")]
	public void Import_UnknownFormat(string fileName)
	{
		// Arrange
		var path = Path.Combine(DirectoryName, fileName);
		var file = File.ReadAllBytes(path);

		var serviceProvider = GetServiceProvider();
		IImportService importService = serviceProvider.GetRequiredService<IImportService>();
		
		// Act
		Action importAction = () => importService.Import(fileName, file);
		
		// Assert
		importAction.Should().Throw<NotSupportedException>();
	}
	
	[TestCase("not_all_value.csv")]
	[TestCase("not_all_value.xml")]
	[TestCase("record_invalid.csv")]
	[TestCase("record_invalid.xml")]
	[TestCase("file_invalid.csv")]
	[TestCase("file_invalid.xml")]
	[TestCase("empty.csv")]
	[TestCase("empty.xml")]
	public void Import_NotImported(string fileName)
	{
		// Arrange
		var path = Path.Combine(DirectoryName, fileName);
		var file = File.ReadAllBytes(path);

		var serviceProvider = GetServiceProvider();
		IImportService importService = serviceProvider.GetRequiredService<IImportService>();
		
		// Act
		Action importAction = () => importService.Import(fileName, file);
		
		// Assert
		importAction.Should().Throw<Exception>();
	}
}