namespace Processing.Web.Models;

public class TransactionRequest
{
	public string? CurrencyCode { get; set; }
	
	public DateTime? From { get; set; }
	
	public DateTime? To { get; set; }
		
	public TransactionStatus? Status { get; set; }
}