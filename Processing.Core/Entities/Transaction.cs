namespace Processing.Core.Entities;

public class Transaction : IEntity
{
	public long Id { get; set; }
	
	public decimal Amount { get; set; }

	public string CurrencyCode { get; set; }
	
	public DateTime TransactionDate { get; set; }
	
	public int Status { get; set; }
}