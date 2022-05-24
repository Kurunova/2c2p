using Processing.Core.Enums;
using Processing.Core.Importer.Interfaces;

namespace Processing.Core.Importer.Services;

public class ImporterFactory : IImporterFactory
{
	private readonly IEnumerable<IImporter> _importers;

	public ImporterFactory(IEnumerable<IImporter> importers)
	{
		_importers = importers;
	}

	public IImporter Create(FileFormat fileFormat)
	{
		var importer = _importers.Single(x => x.FileFormat == fileFormat);
		return importer;
	}
}