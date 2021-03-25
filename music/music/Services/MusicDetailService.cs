using System;
using System.Collections.Generic;
using System.Text;
using music.models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

using Xamarin.Essentials;
using System.Net.Http.Headers;

namespace music.Services
{
    public class MusicDetailService
    {
        public async static Task<List<Album>> GetDetails(string AlbumName)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                string key = "2189c22f65b6e4ffb56d9c3c30db7ae2";//also you can put the key string striaght to {key}..

                string url = $"https://ws.audioscrobbler.com/2.0/?method=album.getinfo&api_key={key}&artist=Cher&album={AlbumName}&format=json";
                

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
