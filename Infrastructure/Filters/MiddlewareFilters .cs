using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Threading.Tasks;

namespace Infrastructure.Filters
{
    public class MiddlewareFilters : IAsyncAuthorizationFilter, IAsyncResourceFilter, IExceptionFilter, IAsyncActionFilter, IAsyncResultFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }

            // //some logic  bla bla

            await next();
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //some logic
            return;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BussnessException))
            {
                var exception = (BussnessException)context.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = exception.Message
                };
                var json = new
                {
                    errors = new[] { validation }
                };
                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            //some logic
            await next();
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            //some logic
            await next();
        }
    }
}