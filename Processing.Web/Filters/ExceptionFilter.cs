using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Processing.Web.Filters
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class ExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
			
			string action = context.RouteData.Values["action"].ToString();
		
			var result = new ViewResult { ViewName = action };
			var modelMetadata = new EmptyModelMetadataProvider();
			result.ViewData = new ViewDataDictionary(modelMetadata, context.ModelState);
			result.ViewData.Add("Message", context.Exception.Message);
			context.Result = result;
			context.ExceptionHandled = true;
		}
	}
}