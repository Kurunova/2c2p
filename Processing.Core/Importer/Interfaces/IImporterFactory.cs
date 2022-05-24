using Processing.Core.Enums;

namespace Processing.Core.Importer.Interfaces;

public interface IImporterFactory
{
	IImporter Create(FileFormat fileFormat);
}