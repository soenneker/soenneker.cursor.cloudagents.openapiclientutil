using Soenneker.Cursor.CloudAgents.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Cursor.CloudAgents.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CursorCloudAgentsOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ICursorCloudAgentsOpenApiClientUtil _openapiclientutil;

    public CursorCloudAgentsOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ICursorCloudAgentsOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
