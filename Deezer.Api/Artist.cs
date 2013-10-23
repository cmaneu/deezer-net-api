using System;
using Newtonsoft.Json;

namespace Deezer.Api
{
    public class Artist : DeezerEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("link")]
        public string WebUri { get; set; }
        
        [JsonProperty("picture")]
        public Uri ArtistImageUri { get; set; }

        [JsonProperty("nb_fan")]
        public int FansCount { get; set; }
        
        [JsonProperty("nb_album")]
        public int AlbumsCount { get; set; }

        [JsonProperty("radio")]
        public bool HasArtistRadio { get; set; }
    }
}
