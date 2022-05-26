using Processing.Importer.Interfaces;

namespace Processing.Importer.Entities;

public class ImporterResponse : IImporterResponse
{
	public IEnumerable<ITransaction> Transactions { get; set; }
}