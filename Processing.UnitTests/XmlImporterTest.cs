using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Processing.Importer.Entities;
using Processing.Importer.Enums;
using Processing.Importer.Interfaces;
using Processing.Importer.Services;

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
		result.Transactions.GetType().Should().Be(typeof(List<XmlTransaction>));
		
		var transactions = result.Transactions as List<XmlTransaction>;
		
		transactions.ToList()[0].TransactionId.Should().Be("Inv00001");
		transactions.ToList()[0].Amount.Should().Be(200);
		transactions.ToList()[0].CurrencyCode.Should().Be("USD");
		transactions.ToList()[0].TransactionDate.Should().Be(new DateTime(2019, 01, 23, 13, 45, 10));
		transactions.ToList()[0].Status.Should().Be(XmlImporterResponseStatus.Done);
		
		transactions.ToList()[1].TransactionId.Should().Be("Inv00002");
		transactions.ToList()[1].Amount.Should().Be(10000);
		transactions.ToList()[1].CurrencyCode.Should().Be("EUR");
		transactions.ToList()[1].TransactionDate.Should().Be(new DateTime(2019, 01, 24, 16, 09, 15));
		transactions.ToList()[1].Status.Should().Be(XmlImporterResponseStatus.Rejected);
	}
}