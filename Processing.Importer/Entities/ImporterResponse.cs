using Processing.Importer.Interfaces;

namespace Processing.Importer.Entities;

public class ImporterResponse<TTransaction> : IImporterResponse
	where TTransaction : class
{
	public IEnumerable<TTransaction> Transactions { get; set; }
}