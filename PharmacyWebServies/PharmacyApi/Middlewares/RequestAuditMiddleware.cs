namespace PharmacyApi.Middlewares
{
    public class RequestAuditMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly ILogger<RequestAuditMiddleware> _logger;

        public RequestAuditMiddleware(RequestDelegate requestDelegate, ILogger<RequestAuditMiddleware> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var method = request.Method;
            var path = request.Path;
            _logger.LogInformation("Incoming Request: {Method} request for {Path} at {Time}", method, path, DateTime.UtcNow);
            await _next(context);
            _logger.LogInformation("Outgoing Request: {StatusCode} for {Method} request for {Path} at {Time}", context.Response.StatusCode, method, path, DateTime.UtcNow);

        }
    }
}
