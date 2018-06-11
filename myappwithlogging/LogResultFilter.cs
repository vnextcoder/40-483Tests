using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace myappwithlogging {
    public class LogResultFilter : IAsyncResourceFilter {
        public async Task OnResourceExecutionAsync (
            ResourceExecutingContext context, ResourceExecutionDelegate next) {
            await next ();

            var data = new {
                Action = context.ActionDescriptor.RouteValues["action"],
                Controller = context.ActionDescriptor.RouteValues["controller"],
                Url = context.HttpContext.Request.Path,
                StatusCode = context.HttpContext.Response.StatusCode
            };

            Log.Information ("Request completed: {@data}", data);
        }
    }
}