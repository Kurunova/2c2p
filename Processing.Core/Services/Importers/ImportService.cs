using Processing.Core.Extensions;
using Processing.Core.Importer.Entities;
using Processing.Core.Importer.Interfaces;
using Processing.Core.Importer.Services;
using Processing.Core.Interfaces.Importers;

namespace Processing.Core.Services.Importers;

public class ImportService : IImportService
{
	public Task Import(string fileName, byte[] file)
	{
		var fileFormat = FileExtension.GetFileFormat(fileName);

		IImporterFactory factory = new ImporterFactory(new List<IImporter>(){ new CsvImporter(), new XmlImporter() });
		var importer = factory.Create(fileFormat);
		
		var data = importer.Process(new ImporterRequest(){ File = file });
		
		// map to db
		
		// Save to DB
		
		return Task.CompletedTask;
	}
}