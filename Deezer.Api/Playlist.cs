using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Deezer.Api
{
    [DebuggerDisplay("Playlist({Id},{Title})")]
    public class Playlist : DeezerEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [JsonProperty("duration")]
        private double InternalDuration
        {
            get
            {
                return Duration.TotalSeconds;
            }
            set
            {
                Duration = TimeSpan.FromSeconds(value);
            }
        }

        [JsonIgnore]
        public TimeSpan Duration { get; set; }
        [JsonProperty("public")]
        public bool IsPublic { get; set; }
        [JsonProperty("collaborative")]
        public bool IsCollaborative { get; set; }
        public Uri Link { get; set; }
        public Uri Picture { get; set; }
        public string Checksum { get; set; }

        [JsonProperty("tracks")]
        private TracksContainer InternalTracks { get; set; }

        [JsonIgnore]
        public List<Track> Tracks
        {
            get { return InternalTracks.Data; }
        }

        internal class TracksContainer
        {
            public List<Track> Data { get; set; } 
        }
    }
}
