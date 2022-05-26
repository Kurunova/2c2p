using Processing.Importer.Enums;
using Processing.Importer.Interfaces;

namespace Processing.Importer.Entities;

public class XmlTransaction : ITransaction
{
	public string TransactionId { get; set; }
	
	public decimal Amount { get; set; }

	public string CurrencyCode { get; set; }
	
	public DateTime TransactionDate { get; set; }
	
	public XmlImporterResponseStatus Status { get; set; }
}