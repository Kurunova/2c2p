using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Processing.Core.Entities;
using Processing.Core.Filers;
using Processing.Core.Interfaces;
using Processing.Web.Models;

namespace Processing.Web.Controllers;

public class HomeController : Controller
{
	private readonly IImportService _importService;
	private readonly IRepository<Transaction> _repository;
	private readonly IMapper _mapper;
	
	private int _maxFileSizeMb = 1;
	
	public HomeController(
		IImportService importService, 
		IRepository<Transaction> repository, 
		IMapper mapper)
	{
		_importService = importService;
		_repository = repository;
		_mapper = mapper;
	}

	[HttpGet]
	public ViewResult Index([FromQuery] TransactionRequest transactionRequest)
	{
		var requestData = _mapper.Map<TransactionSearchRequestData>(transactionRequest);
	
		var transactions = _repository.Find<TransactionFilterSpecification, TransactionSearchRequestData>(requestData).ToList();
		
		var model = _mapper.Map<List<TransactionModel>>(transactions);
		
		return View(model);
	}
	
	[HttpGet]
	public IActionResult Upload()
	{
		return View();
	}
	
	[HttpPost]
	public ViewResult Upload(IFormFile file)
	{
		if (file == null || file.Length == 0)
		{
			ModelState.AddModelError("General", "File not selected!");
			return View();
		}

		if (file.Length > _maxFileSizeMb * 1000 * 1000)
		{
			ModelState.AddModelError("General", "File should not exceeded 1Mb!");
			return View();
		}

		using var ms = new MemoryStream();
		file.CopyTo(ms);
		var fileBytes = ms.ToArray();
		_importService.Import(file.FileName, fileBytes);
		
		ViewData["Message"] = "File uploaded successfully";
		return View();
	}
}