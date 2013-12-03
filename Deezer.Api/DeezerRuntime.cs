using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public async Task<Artist> GetArtist(int artistId)
        {
            string responseContent = await this.ExecuteHttpGet(string.Format("/artist/{0}", artistId));

            Artist artist = JsonConvert.DeserializeObject<Artist>(responseContent);

            artist.CurrentRuntime = this;

            return artist;
        }
        public async Task<Playlist> GetPlaylist(int playlistId)
        {
            string responseContent = await this.ExecuteHttpGet(string.Format("/playlist/{0}", playlistId));

            // There an issue with the API. We only get the first 400 tracks from the playlist
            // Working on that internally (because the /playlist/:id/tracks only has pages of 50 tracks...
            Playlist playlist = JsonConvert.DeserializeObject<Playlist>(responseContent);

            playlist.CurrentRuntime = this;
            await playlist.LoadTracksAsync();

            return playlist;
        }

        internal async Task<string> ExecuteHttpGet(string method)
        {
            HttpResponseMessage httpResponse = await this._httpClient.GetAsync(API_ENDPOINT + method);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new DeezerRuntimeException(httpResponse.ReasonPhrase);
            }

            string responseContent = await httpResponse.Content.ReadAsStringAsync();
            return responseContent;
        }
    }
}
