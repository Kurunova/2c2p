using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Processing.Importer.Entities;
using Processing.Importer.Enums;
using Processing.Importer.Interfaces;
using Processing.Importer.Services;

namespace Processing.UnitTests;

public class CsvImporterTest : BaseTest
{
	[TestCase("example.csv")]
	public void Import_Imported(string fileName)
	{
		// Arrange
		var path = Path.Combine(DirectoryName, fileName);
		var file = File.ReadAllBytes(path);
		IImporter importService = new CsvImporter();
		
		// Act
		var result = importService.Process(new ImporterRequest { File = file });
		
		// Assert
		result.GetType().Should().Be(typeof(ImporterResponse<CsvTransaction>));
		
		var importerResponse = result as ImporterResponse<CsvTransaction>;
		
		importerResponse.Transactions.ToList()[0].TransactionId.Should().Be("Invoice0000001");
		importerResponse.Transactions.ToList()[0].Amount.Should().Be(1000);
		importerResponse.Transactions.ToList()[0].CurrencyCode.Should().Be("USD");
		importerResponse.Transactions.ToList()[0].TransactionDate.Should().Be(new DateTime(2019, 02, 20, 12, 33, 16));
		importerResponse.Transactions.ToList()[0].Status.Should().Be(CsvImporterResponseStatus.Approved);
		
		importerResponse.Transactions.ToList()[1].TransactionId.Should().Be("Invoice0000002");
		importerResponse.Transactions.ToList()[1].Amount.Should().Be(300);
		importerResponse.Transactions.ToList()[1].CurrencyCode.Should().Be("USD");
		importerResponse.Transactions.ToList()[1].TransactionDate.Should().Be(new DateTime(2019, 02, 21, 02, 04, 59));
		importerResponse.Transactions.ToList()[1].Status.Should().Be(CsvImporterResponseStatus.Failed);
	}
}