using EVOffice_BE.Common;
using EVOffice_BE.Entities.Exceptions;
using EVOffice_BE.Exceptions;

using Newtonsoft.Json;

namespace EVOffice_BE.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private Task HandleException(HttpContext context, Exception ex)
    {
        _logger.LogError(ex.Message);

        var code = StatusCodes.Status500InternalServerError;
        var errors = new List<string> { ex.Message };

        code = ex switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            ResourceNotFoundException => StatusCodes.Status404NotFound,
            BadRequestException => StatusCodes.Status400BadRequest,
            UnprocessableRequestException => StatusCodes.Status422UnprocessableEntity,
            _ => code
        };

        var result = JsonConvert.SerializeObject(ApiResult<string>.Failure(errors));

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = code;

        return context.Response.WriteAsync(result);
    }
}
