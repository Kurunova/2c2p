using Processing.Importer.Enums;

namespace Processing.Importer.Entities;

public class CsvTransaction
{
	public string TransactionId { get; set; }
	
	public decimal Amount { get; set; }

	public string CurrencyCode { get; set; }
	
	public DateTime TransactionDate { get; set; }
	
	public CsvImporterResponseStatus Status { get; set; }
}