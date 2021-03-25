using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace music.models
{
    public class Image
    {
        [JsonProperty("#text")]
        public string Text { get; set; }
        public string size { get; set; }
    }
}
