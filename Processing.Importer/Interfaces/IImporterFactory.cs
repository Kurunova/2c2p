using Processing.Importer.Enums;

namespace Processing.Importer.Interfaces;

public interface IImporterFactory
{
	IImporter Create(string fileName);
}