using Desafio.BLL.Infra.Infra;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Desafio.API.Infra
{
    public class ErrorActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                if (context.Exception is BusinessException)
                {
                    context.ExceptionHandled = true;
                    var businessException = context.Exception as BusinessException;
                    var result = JsonConvert.SerializeObject(new { error = businessException.Message });
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    var json = UTF8Encoding.Default.GetBytes(result);
                    context.HttpContext.Response.Body.Write(json);
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
