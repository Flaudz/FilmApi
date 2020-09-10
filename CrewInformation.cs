using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using static FilmApi.CastConstructor;

namespace FilmApi
{
    public class CrewInformation
    {
        public Root GetCrew(string movie_id)
        {
            var json = new WebClient().DownloadString($@"https://api.themoviedb.org/3/movie/{movie_id}/credits?api_key=0a34d1c5f077444133ab367be386561a");
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);
            return myDeserializedClass;
        }
    }
}
