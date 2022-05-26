using Processing.Core.Enums;
using Processing.Core.Interfaces.Filters;

namespace Processing.Core.Filers;

public class TransactionSearchRequestData : IRequestData
{
	public string? CurrencyCode { get; set; }
	
	public DateTime? From { get; set; }
	
	public DateTime? To { get; set; }
		
	public TransactionStatus? Status { get; set; }
}