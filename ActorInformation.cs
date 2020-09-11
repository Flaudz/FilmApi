using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using static FilmApi.ActorProperties;

namespace FilmApi
{
    public class ActorInformation
    {
        public Root GetActor(string name)
        {
            name.Replace(" ", "%20");
            var json = new WebClient().DownloadString($@"https://api.themoviedb.org/3/search/person?api_key=0a34d1c5f077444133ab367be386561a&language=en-US&query={name}&page=1&include_adult=false");
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);
            return myDeserializedClass;
        }
    }
}
