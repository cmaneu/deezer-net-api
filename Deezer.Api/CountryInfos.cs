using Newtonsoft.Json;

namespace Deezer.Api
{
    using System.Diagnostics;

    /// <summary>
    /// This class contains informations about the service availability in a country.
    /// </summary>
    [DebuggerDisplay("CountryInfos({IsoCode},{IsDeezerServiceOpen})")]
    public class CountryInfos
    {
        /// <summary>
        /// Gets the country ISO code.
        /// </summary>
        [JsonProperty("country_iso")]
        public string IsoCode { get; internal set; }

        /// <summary>
        /// Gets the country name.
        /// </summary>
        public string Country { get; internal set; }
        
        /// <summary>
        /// Gets a value indicating whether the Deezer service is open in the country.
        /// </summary>
        [JsonProperty("open")]
        public bool IsDeezerServiceOpen { get; internal set; }
        
        // TODO: Add offers node support
    }
}
