namespace Processing.Core.Importer.Entities;

public class ImporterResponse<TTransaction> : IImporterResponse
	where TTransaction : class
{
	public IEnumerable<TTransaction> Transactions { get; set; }
}