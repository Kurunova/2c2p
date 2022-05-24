using System.Globalization;
using Microsoft.VisualBasic.FileIO;
using Processing.Core.Enums;
using Processing.Core.Importer.Entities;
using Processing.Core.Importer.Enums;
using Processing.Core.Importer.Interfaces;

namespace Processing.Core.Importer.Services;

public class CsvImporter : IImporter
{
	public FileFormat FileFormat => FileFormat.Csv;
	
	public IImporterResponse Process(IImporterRequest inputData)
	{
		var transactions = new List<CsvTransaction>();

		var memoryStream = new MemoryStream(inputData.File);
		
		var parser = new TextFieldParser(memoryStream);

		parser.HasFieldsEnclosedInQuotes = true;
		parser.SetDelimiters(",");

		while (!parser.EndOfData)
		{
			var row = parser.ReadFields();
			
			transactions.Add(new CsvTransaction
			{
				TransactionId = row[0],
				Amount = decimal.Parse(row[1].Replace(",", ""), CultureInfo.InvariantCulture),
				CurrencyCode = row[2],
				TransactionDate = DateTime.Parse(row[3]),
				Status = (CsvImporterResponseStatus)Enum.Parse(typeof(CsvImporterResponseStatus), row[4])
			});
		} 

		parser.Close();

		return new ImporterResponse<CsvTransaction> { Transactions = transactions };
	}
}