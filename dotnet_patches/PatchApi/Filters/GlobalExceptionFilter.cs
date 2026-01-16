using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PatchApi.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var errorResponse = new
        {
            error = "Internal Server Error",
            message = context.Exception.Message
        };

        context.Result = new ObjectResult(errorResponse)
        {
            StatusCode = 500
        };
    }
}
