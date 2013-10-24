using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Deezer.Api
{
    [DebuggerDisplay("Artist({Id},{Name})")]
    public class Artist : DeezerEntity
    {
        private List<Album> albums;

        public int Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("link")]
        public string WebUri { get; set; }
        
        [JsonProperty("picture")]
        public Uri ArtistImageUri { get; set; }

        [JsonProperty("nb_fan")]
        public int FansCount { get; set; }
        
        public int AlbumsCount { get; set; }

        [JsonProperty("radio")]
        public bool HasArtistRadio { get; set; }

        public List<Album> Albums
        {
            get
            {
                return this.albums;
            }
            set
            {
                SetProperty(ref albums, value);
            }
        }

        public Artist()
        {
            Albums = new List<Album>();
            AlbumsCount = -1;
        }

        public async Task<List<Album>>  LoadAlbums()
        {
            string responseContent = await CurrentRuntime.ExecuteHttpGet(string.Format("/artist/{0}/albums", Id));

            var jsonResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);

            Albums = JsonConvert.DeserializeObject<List<Album>>(jsonResult["data"].ToString());

            foreach (Album album in Albums)
            {
                album.CurrentRuntime = CurrentRuntime;    
            }

            AlbumsCount = Albums.Count;

            return Albums;
        }
    }
}
