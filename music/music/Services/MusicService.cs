using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

using Newtonsoft.Json;
using Xamarin.Essentials;

using music.models;


namespace music.Services
{
    class MusicService
    {
        
            
        public async static Task<List<Album>> GetAlbums(string AlbumName)
        {
            if (Connectivity.NetworkAccess==NetworkAccess.Internet)
            {
                string key = "2189c22f65b6e4ffb56d9c3c30db7ae2";//also you can put the key string striaght to {key}..
                
                string url = $"https://ws.audioscrobbler.com/2.0/?method=album.search&album={AlbumName}&api_key={key}&format=json";

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage message = await client.GetAsync(url);
                if (message.IsSuccessStatusCode)
                {

                    string json = await message.Content.ReadAsStringAsync();
                    Root al = JsonConvert.DeserializeObject<Root>(json);
                    return al.results.albummatches.album;

                }

            }


            return new List<Album>();




        }       
        
            
            
            

    }
}
