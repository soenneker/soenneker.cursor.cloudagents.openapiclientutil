using Soenneker.Cursor.CloudAgents.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Cursor.CloudAgents.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class CursorCloudAgentsOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly ICursorCloudAgentsOpenApiClientUtil _openapiclientutil;

    public CursorCloudAgentsOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<ICursorCloudAgentsOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
