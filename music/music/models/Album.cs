using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace music.models
{
    public  class Album
    {
        public string name { get; set; }
        public string artist { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
        public  List<Image> image { get; set; }
        public Tracks tracks { get; set; }
        public string listeners { get; set; }
        public string playcount { get; set; }
        
        public string imageUrl { get; set; }
        public Tags tags { get; set; }
        public wiki wiki { get; set; }



    }
}
