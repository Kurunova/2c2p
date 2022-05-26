namespace Processing.Importer.Interfaces;

public interface IImporterResponse
{
	IEnumerable<ITransaction> Transactions { get; set; }
}