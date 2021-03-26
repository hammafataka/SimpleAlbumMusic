using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using music.ViewModels;
using music.models;

namespace music.models
{
    public class Track
    {
        public string name { get; set; }
        public string url { get; set; }
        public string duration { get; set; }
        public Artist artist { get; set; }

        [JsonProperty("@attr")]
        public Attr Attr { get; set; }
        public Streamable streamable { get; set; }



    }
}
