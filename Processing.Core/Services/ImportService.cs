using Processing.Core.Interfaces;
using Processing.Importer.Entities;
using Processing.Importer.Interfaces;
using Processing.Importer.Services;

namespace Processing.Core.Services;

public class ImportService : IImportService
{
	public Task Import(string fileName, byte[] file)
	{
		IImporterFactory factory = new ImporterFactory(new List<IImporter>(){ new CsvImporter(), new XmlImporter() });
		var importer = factory.Create(fileName);
		
		var data = importer.Process(new ImporterRequest(){ File = file });
		
		// map to db
		
		// Save to DB
		
		return Task.CompletedTask;
	}
}