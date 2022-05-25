using Processing.Importer.Interfaces;

namespace Processing.Importer.Entities;

public class ImporterRequest : IImporterRequest
{
	public byte[] File { get; set; }
}