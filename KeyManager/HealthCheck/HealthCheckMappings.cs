using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace KeyManager.HealthCheck;

public static class HealthCheckMappings
{
    // This dictionary maps health statuses to HTTP status codes for the health check endpoint
    // When Healthy -> 200 OK
    // When Degraded -> 206 Partial Content
    // When Unhealthy -> 503 Service Unavailable
    public static readonly Dictionary<HealthStatus, int> ResultStatusCodes = new()
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status206PartialContent,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    };
}
