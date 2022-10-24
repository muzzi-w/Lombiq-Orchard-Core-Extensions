using Lombiq.ChartJs.Tests.UI.Extensions;
using Lombiq.Tests.UI.Attributes;
using Lombiq.Tests.UI.Services;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Lombiq.OSOCE.Tests.UI.Tests;

public class BehaviorChartJsTests : UITestBase
{
    public BehaviorChartJsTests(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    [Theory, Chrome]
    public Task RecipeDataShouldBeDisplayedCorrectly(Browser browser) =>
        ExecuteTestAfterSetupAsync(
            context => context.TestChartJsSampleBehaviorAsync(),
            browser,
            configuration =>
            {
                configuration.CounterConfiguration.Running.DbReaderReadThreshold = 404;
                configuration.CounterConfiguration.Running.DbReaderReadPerNavigationThreshold = 70;
                return Task.CompletedTask;
            });
}
