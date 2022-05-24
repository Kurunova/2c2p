using System.IO;
using System.Reflection;

namespace Processing.UnitTests;

public class BaseTest
{
	private string? _directoryName;
	protected string DirectoryName => _directoryName ??= Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Source");
}