using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Deezer.Api.Tests
{

    [TestClass]
    public class DeezerRuntimeTest
    {

        [TestMethod]
        [TestCategory("API Call")]
        [TestProperty("EntityType", "Country")]
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
        [TestCategory("API Call")]
        [TestProperty("EntityType", "Artist")]
        public async Task GetExistingArtist()
        {
            // Arrange
            Deezer.Api.DeezerRuntime runtime = new DeezerRuntime();

            // Act
            Artist apiCallResult = await runtime.GetArtist(144227);

            // Assert
            Assert.IsNotNull(apiCallResult);
            Assert.AreEqual(144227, apiCallResult.Id);
            Assert.AreEqual("Katy Perry", apiCallResult.Name);
            Assert.AreEqual("http://www.deezer.com/artist/144227", apiCallResult.WebUri);
            Assert.AreEqual(new Uri("http://api.deezer.com/artist/144227/image"), apiCallResult.ArtistImageUri);
            Assert.AreEqual(true, apiCallResult.HasArtistRadio);
            Assert.IsTrue(apiCallResult.FansCount > 23000);
            Assert.IsTrue(apiCallResult.AlbumsCount > 70);
        }

        [TestMethod]
        [TestCategory("API Call")]
        [TestProperty("EntityType", "Artist")]
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

        [TestMethod]
        [TestCategory("API Call")]
        public async Task GetArtistAlbums()
        {
            // Arrange
            Deezer.Api.DeezerRuntime runtime = new DeezerRuntime();

            // Act
            Artist testedArtist = await runtime.GetArtist(144227);
            Assert.IsNotNull(testedArtist);

            await testedArtist.LoadAlbums();

            // Assert
            Assert.IsTrue(testedArtist.Albums.Count > 0);
        }
    }
}
