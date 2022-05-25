using Processing.Importer.Enums;

namespace Processing.Importer.Extensions;

public static class FileExtension
{
	public static FileFormat GetFileFormat(string fileName)
	{
		var extension = Path.GetExtension(fileName);

		var fileFormat = extension switch
		{
			".csv" => FileFormat.Csv,
			".xml" => FileFormat.Xml,
			_ => throw new NotSupportedException($"Type {extension} is not supported")
		};
		return fileFormat;
	}
}