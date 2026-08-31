[![](https://img.shields.io/nuget/v/soenneker.cursor.cloudagents.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cursor.cloudagents.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cursor.cloudagents.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.cursor.cloudagents.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.cursor.cloudagents.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cursor.cloudagents.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cursor.cloudagents.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.cursor.cloudagents.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Cursor.CloudAgents.OpenApiClientUtil

Provides a lazily created, cached Cursor Cloud Agents client backed by `Soenneker.Cursor.CloudAgents.HttpClients`.

## Installation

```bash
dotnet add package Soenneker.Cursor.CloudAgents.OpenApiClientUtil
```

## Configuration and registration

```json
{
  "Cursor": {
    "ApiKey": "your-cursor-api-key"
  }
}
```

```csharp
using Soenneker.Cursor.CloudAgents.OpenApiClientUtil.Registrars;

services.AddCursorCloudAgentsOpenApiClientUtilAsScoped();
```

Use `AddCursorCloudAgentsOpenApiClientUtilAsSingleton()` when the application should share one generated client.

## Usage

```csharp
using Soenneker.Cursor.CloudAgents.OpenApiClientUtil.Abstract;

public sealed class CursorAccountReader(ICursorCloudAgentsOpenApiClientUtil clients)
{
    public async Task Read(CancellationToken cancellationToken)
    {
        var client = await clients.Get(cancellationToken);
        var keyInfo = await client.V1.Me.GetAsync(cancellationToken: cancellationToken);
    }
}
```

Each utility instance caches one generated client. Both registrations use a singleton HTTP provider, so disposing a scoped utility does not remove the shared `HttpClient`; the provider owns and disposes it when the application container shuts down.
