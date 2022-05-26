using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Processing.Web.Filters;

public class ValidateModelStateFilter : ActionFilterAttribute
{
	public override void OnActionExecuted(ActionExecutedContext context)
	{
		if (!context.ModelState.IsValid)
		{
			var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
				.SelectMany(v => v.Errors)
				.Select(v => v.ErrorMessage)
				.ToList();
			
			context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

			Controller controller = context.Controller as Controller;
			controller.ViewData["Message"] = string.Join(", ", errors);
		}
	}
}