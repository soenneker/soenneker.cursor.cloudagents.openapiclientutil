using Soenneker.Cursor.CloudAgents.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Cursor.CloudAgents.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ICursorCloudAgentsOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<CursorCloudAgentsOpenApiClient> Get(CancellationToken cancellationToken = default);
}
