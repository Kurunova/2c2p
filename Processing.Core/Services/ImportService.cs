using AutoMapper;
using Processing.Core.Entities;
using Processing.Core.Interfaces;
using Processing.Importer.Entities;
using Processing.Importer.Interfaces;

namespace Processing.Core.Services;

public class ImportService : IImportService
{
	private readonly IRepository<Transaction> _repository;
	private readonly IMapper _mapper;
	private readonly IImporterFactory _importerFactory;

	public ImportService(
		IRepository<Transaction> repository, 
		IMapper mapper, 
		IImporterFactory importerFactory)
	{
		_repository = repository;
		_mapper = mapper;
		_importerFactory = importerFactory;
	}

	public Task Import(string fileName, byte[] file)
	{
		var importer = _importerFactory.Create(fileName);
		
		var data = importer.Process(new ImporterRequest(){ File = file });

		var transactions = _mapper.Map<List<Transaction>>(data.Transactions);
		
		_repository.Add(transactions);
		
		return Task.CompletedTask;
	}
}