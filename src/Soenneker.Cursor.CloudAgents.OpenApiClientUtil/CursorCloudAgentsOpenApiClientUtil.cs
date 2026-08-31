using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Cursor.CloudAgents.HttpClients.Abstract;
using Soenneker.Cursor.CloudAgents.OpenApiClientUtil.Abstract;
using Soenneker.Cursor.CloudAgents.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Cursor.CloudAgents.OpenApiClientUtil;

///<inheritdoc cref="ICursorCloudAgentsOpenApiClientUtil"/>
public sealed class CursorCloudAgentsOpenApiClientUtil : ICursorCloudAgentsOpenApiClientUtil
{
    private readonly AsyncSingleton<CursorCloudAgentsOpenApiClient> _client;

    public CursorCloudAgentsOpenApiClientUtil(ICursorCloudAgentsOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<CursorCloudAgentsOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new CursorCloudAgentsOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<CursorCloudAgentsOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
