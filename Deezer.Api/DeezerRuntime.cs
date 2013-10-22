using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Deezer.Api
{
    public class DeezerRuntime
    {
        private const string API_ENDPOINT = "http://api.deezer.com/";

        private HttpClient _httpClient;

        private Tuple<string, string> _applicationCredentials;


        /// <summary>
        /// Initializes a new instance of the <see cref="DeezerRuntime"/> class.
        /// </summary>
        public DeezerRuntime()
        {
            _applicationCredentials = null;
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeezerRuntime"/> class.
        /// Sets the application credentials for use with needed requests.
        /// </summary>
        /// <param name="applicationId">Your Application ID.</param>
        /// <param name="applicationSecretKey">Your Application secret key.</param>
        public DeezerRuntime(string applicationId, string applicationSecretKey)
        {
            _applicationCredentials = new Tuple<string, string>(applicationId, applicationSecretKey);
            _httpClient = new HttpClient();
        }


        public async Task<CountryInfos> GetCountryInfos()
        {
            HttpResponseMessage httpResponse = await _httpClient.GetAsync(string.Format("{0}/infos", API_ENDPOINT));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new DeezerRuntimeException(httpResponse.ReasonPhrase);
            }

            string responseContent = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CountryInfos>(responseContent);
        }
    }
}
