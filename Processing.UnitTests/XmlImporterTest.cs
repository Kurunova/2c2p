using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Processing.Core.Importer.Entities;
using Processing.Core.Importer.Enums;
using Processing.Core.Importer.Interfaces;
using Processing.Core.Importer.Services;

namespace Processing.UnitTests;

public class XmlImporterTest : BaseTest
{
	[TestCase("example.xml")]
	public void Import_Imported(string fileName)
	{
		// Arrange
		var path = Path.Combine(DirectoryName, fileName);
		var file = File.ReadAllBytes(path);
		IImporter importService = new XmlImporter();
		
		// Act
		var result = importService.Process(new ImporterRequest { File = file });
	
		// Assert
		result.GetType().Should().Be(typeof(ImporterResponse<XmlTransaction>));
		
		var importerResponse = result as ImporterResponse<XmlTransaction>;
		
		importerResponse.Transactions.ToList()[0].TransactionId.Should().Be("Inv00001");
		importerResponse.Transactions.ToList()[0].Amount.Should().Be(200);
		importerResponse.Transactions.ToList()[0].CurrencyCode.Should().Be("USD");
		importerResponse.Transactions.ToList()[0].TransactionDate.Should().Be(new DateTime(2019, 01, 23, 13, 45, 10));
		importerResponse.Transactions.ToList()[0].Status.Should().Be(XmlImporterResponseStatus.Done);
		
		importerResponse.Transactions.ToList()[1].TransactionId.Should().Be("Inv00002");
		importerResponse.Transactions.ToList()[1].Amount.Should().Be(10000);
		importerResponse.Transactions.ToList()[1].CurrencyCode.Should().Be("EUR");
		importerResponse.Transactions.ToList()[1].TransactionDate.Should().Be(new DateTime(2019, 01, 24, 16, 09, 15));
		importerResponse.Transactions.ToList()[1].Status.Should().Be(XmlImporterResponseStatus.Rejected);
	}
}