using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Deezer.Api.Tests
{

    [TestClass]
    public class DeezerRuntimeTest
    {

        [TestMethod]
        public async Task GetCurrentCountryInfos()
        {
            // Arrange
            Deezer.Api.DeezerRuntime runtime = new DeezerRuntime();

            // Act
            CountryInfos apiCallResult = await runtime.GetCountryInfos();

            // Assert
            Assert.IsNotNull(apiCallResult);
            Assert.IsTrue(apiCallResult.IsDeezerServiceOpen);
        }

        [TestMethod]
        public async Task GetExistingArtist()
        {
            // Arrange
            Deezer.Api.DeezerRuntime runtime = new DeezerRuntime();

            // Act
            Artist apiCallResult = await runtime.GetArtist(144227);

            // Assert
            Assert.IsNotNull(apiCallResult);
            Assert.AreEqual("Katy Perry", apiCallResult.Name);
        }

        [TestMethod]
        public async Task GetUnknownArtistById()
        {
            try
            {
                // Arrange
                Deezer.Api.DeezerRuntime runtime = new DeezerRuntime();

                // Act
                Artist apiCallResult = await runtime.GetArtist(9999999);
            }
            catch (DeezerRuntimeException)
            {
                // Assert
                Assert.IsTrue(true);
            }
        }
    }
}
