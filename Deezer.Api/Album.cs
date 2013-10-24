using System;
using System.Diagnostics;

using Newtonsoft.Json;

namespace Deezer.Api
{

    [DebuggerDisplay("Album({Id},{Title})")]
    public class Album : DeezerEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [JsonProperty("cover")]
        public Uri AlbumImageUri { get; set; }

        [JsonProperty("genre_id")]
        public MusicGenre Genre { get; set; }
    }
}
