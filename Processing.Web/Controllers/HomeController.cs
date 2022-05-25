using Microsoft.AspNetCore.Mvc;
using Processing.Core.Entities;
using Processing.Core.Interfaces;
using Processing.Web.Models;

namespace Processing.Web.Controllers;

public class HomeController : Controller
{
	private readonly IImportService _importService;
	private readonly IRepository<Transaction> _repository;
	private int _maxFileSizeMb = 1;
	
	public HomeController(IImportService importService, IRepository<Transaction> repository)
	{
		_importService = importService;
		_repository = repository;
	}

	public ViewResult Index()
	{
		var stubModel = new List<TransactionModel>()
		{
		};
		
		//var transactions = _repository.Find();
		
		return View(stubModel);
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

		var message = "File uploaded successfully";
		try
		{
			using var ms = new MemoryStream();
			file.CopyTo(ms);
			var fileBytes = ms.ToArray();
			_importService.Import(file.FileName, fileBytes);
		}
		catch (Exception e)
		{
			message = e.Message;
		}
		
		ViewData["Message"] = message;
		return View();
	}
}