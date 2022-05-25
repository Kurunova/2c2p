using Processing.Importer.Enums;

namespace Processing.Importer.Interfaces;

public interface IImporter
{
	FileFormat FileFormat { get; }

	IImporterResponse Process(IImporterRequest inputData);
}