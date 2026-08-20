using LeadFlow.Api.Exceptions;
using Microsoft.AspNetCore.Mvc;


namespace LeadFlow.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
           _logger.LogWarning(ex, "Not found");
            await WriteProblemAsync(context, 404, "Resource not found", ex.Message);
        }
        catch (ValidationException ex)
        {
            _logger.LogWarning(ex, "Not found");
            await WriteProblemAsync(context, 400, "Validation failed", ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");
            await WriteProblemAsync(context, 500, "Internal server error", "An unexpected error occurred");
        }

    }

    private static async Task WriteProblemAsync(HttpContext context, int statusCode, string title, string detail)
    {
        context.Response.StatusCode = statusCode;
        var problem = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Instance = context.Request.Path
        };

       await context.Response.WriteAsJsonAsync(problem,options:null,  contentType:"application/problem+json");
    }
}