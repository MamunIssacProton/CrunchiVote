using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CrunchiVote.Api.ExceptionHanlder;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> Logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) => this.Logger = logger;
    
  
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
                                          Exception exception,
                                          CancellationToken cancellationToken)
    {
        this.Logger.LogError(exception,"An Exception has occured: {message}",exception.Message);
        var problemDetals = new ProblemDetails()
        {
            Status =StatusCodes.Status500InternalServerError,
            Title ="Invalid request",
            
        };
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(problemDetals, cancellationToken);
        return true;
    }
}