using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using static FilmApi.MovieConstructor;

namespace FilmApi
{
    public class Information
    {
        public Root GetMovies(string url)
        {
            url.Replace(" ", "%20");
            var json = new WebClient().DownloadString($@"https://api.themoviedb.org/3/search/movie?api_key=0a34d1c5f077444133ab367be386561a&language=en-US&query={url}&page=1&include_adult=false");
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);
            return myDeserializedClass;
        }

        
    }
}
