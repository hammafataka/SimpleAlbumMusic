using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace music.models
{
    public class Results
    {


        [JsonProperty("opensearch:startIndex")]
        public string OpensearchStartIndex { get; set; } 

        [JsonProperty("opensearch:itemsPerPage")]
        public string OpensearchItemsPerPage { get; set; }
        public Albummatches albummatches { get; set; }

        [JsonProperty("@attr")]
        public Attr Attr { get; set; }
    }
}
