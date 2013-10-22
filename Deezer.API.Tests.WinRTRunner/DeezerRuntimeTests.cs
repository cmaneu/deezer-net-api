using Deezer.Api;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Deezer.API.Tests.WinRTRunner
{
    using System.Threading.Tasks;

    [TestClass]
    public class DeezerRuntimeTests
    {
        [TestClass]
        public class GetCountryInfosTests
        {
            [TestMethod]
            public async Task TestMethod1()
            {
                // Arrange
                Deezer.Api.DeezerRuntime runtime = new DeezerRuntime();

                // Act
                CountryInfos apiCallResult = await runtime.GetCountryInfos();

                // Assert
                Assert.IsNotNull(apiCallResult);
                Assert.IsTrue(apiCallResult.IsDeezerServiceOpen);
            }
        }
    }
}
