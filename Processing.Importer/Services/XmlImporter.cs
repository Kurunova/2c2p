using System.Globalization;
using System.Xml.Serialization;
using Processing.Importer.Entities;
using Processing.Importer.Enums;
using Processing.Importer.Interfaces;

namespace Processing.Importer.Services;

public class XmlImporter : IImporter
{
	public FileFormat FileFormat => FileFormat.Xml;
	
	public IImporterResponse Process(IImporterRequest inputData)
	{
		var ms = new MemoryStream(inputData.File);
		
		var serializer = new XmlSerializer(typeof(Transactions));
		var deserialized = (Transactions)serializer.Deserialize(ms);

		var transactions = deserialized.Items.Select(x => new XmlTransaction
		{
			TransactionId = x.id,
			Amount = decimal.Parse(x.PaymentDetails[0].Amount, CultureInfo.InvariantCulture),
			CurrencyCode = x.PaymentDetails[0].CurrencyCode,
			TransactionDate = DateTime.SpecifyKind(DateTime.Parse(x.TransactionDate), DateTimeKind.Utc),
			Status = (XmlImporterResponseStatus)Enum.Parse(typeof(XmlImporterResponseStatus), x.Status)
		}).ToList();

		return new ImporterResponse { Transactions = transactions };
	}
}