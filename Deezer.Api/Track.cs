using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Deezer.Api
{
    public class Track : DeezerEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

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
        public Uri Preview { get; set; }
        public Artist Artist { get; set; }
    }
}
