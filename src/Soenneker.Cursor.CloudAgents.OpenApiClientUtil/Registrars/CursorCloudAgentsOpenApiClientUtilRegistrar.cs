using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Cursor.CloudAgents.HttpClients.Registrars;
using Soenneker.Cursor.CloudAgents.OpenApiClientUtil.Abstract;

namespace Soenneker.Cursor.CloudAgents.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class CursorCloudAgentsOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="CursorCloudAgentsOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddCursorCloudAgentsOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddCursorCloudAgentsOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ICursorCloudAgentsOpenApiClientUtil, CursorCloudAgentsOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="CursorCloudAgentsOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddCursorCloudAgentsOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddCursorCloudAgentsOpenApiHttpClientAsSingleton()
                .TryAddScoped<ICursorCloudAgentsOpenApiClientUtil, CursorCloudAgentsOpenApiClientUtil>();

        return services;
    }
}
