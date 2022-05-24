using Processing.Core.Enums;
using Processing.Core.Importer.Entities;

namespace Processing.Core.Importer.Interfaces;

public interface IImporter
{
	FileFormat FileFormat { get; }

	IImporterResponse Process(IImporterRequest inputData);
}