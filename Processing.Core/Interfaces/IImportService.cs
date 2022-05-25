namespace Processing.Core.Interfaces;

public interface IImportService
{
	Task Import(string fileName, byte[] file);
}