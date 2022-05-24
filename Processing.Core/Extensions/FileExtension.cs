using Processing.Core.Enums;

namespace Processing.Core.Extensions;

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