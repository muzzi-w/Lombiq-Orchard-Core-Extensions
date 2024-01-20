using Lombiq.Tests.UI.Constants;
using Lombiq.Tests.UI.Extensions;
using OpenQA.Selenium;
using SixLabors.ImageSharp;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Lombiq.OSOCE.Tests.UI.Tests.VisualVerificationTests;

public class VisualVerificationTests(ITestOutputHelper testOutputHelper) : UITestBase(testOutputHelper)
{
    private static readonly Size[] _visualVerificationSizes =
    [
        CommonDisplayResolutions.Standard,
    ];

    [Fact]
    public Task VerifyHomePageAndLayout() =>
        // Check the whole page so we can verify the margins and to see if header/footer is affected.
        // The threshold is necessary so the year changing in the footer doesn't cause the test to crash (or other tiny
        // changes in font rendering).
        ExecuteTestAfterSetupAsync(
            context => context.AssertVisualVerificationOnAllResolutions(
                _visualVerificationSizes,
                _ => By.TagName("body"),
                pixelErrorPercentageThreshold: 0.005,
                configurator: configuration => configuration.WithFileNameSuffix(
                    OperatingSystem.IsOSPlatform(nameof(OSPlatform.Windows)) ? "Windows" : "Unix")));
}
