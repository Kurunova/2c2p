using Processing.Core.Extensions;
using Processing.Core.Interfaces.Importers;

namespace Processing.Core.Services.Importers;

public class ImportService : IImportService
{
	public Task Import(string fileName, byte[] file)
	{
		var fileFormat = FileExtension.GetFileFormat(fileName);

		throw new NotImplementedException();
	}
}