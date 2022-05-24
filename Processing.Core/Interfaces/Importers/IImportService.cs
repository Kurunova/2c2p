namespace Processing.Core.Interfaces.Importers;

public interface IImportService
{
	Task Import(string fileName, byte[] file);
}