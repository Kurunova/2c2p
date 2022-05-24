using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using Processing.Core.Enums;
using Processing.Core.Importer.Entities;
using Processing.Core.Importer.Enums;
using Processing.Core.Importer.Interfaces;

namespace Processing.Core.Importer.Services;

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
			TransactionDate = DateTime.Parse(x.TransactionDate),
			Status = (XmlImporterResponseStatus)Enum.Parse(typeof(XmlImporterResponseStatus), x.Status)
		});

		return new ImporterResponse<XmlTransaction> { Transactions = transactions };
	}
}