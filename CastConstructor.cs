﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FilmApi
{
    public class CastConstructor
    {
        public class Cast
        {
            public int cast_id { get; set; }
            public string character { get; set; }
            public string credit_id { get; set; }
            public int gender { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int order { get; set; }
            public string profile_path { get; set; }
        }

        public class Root
        {
            public int id { get; set; }
            public List<Cast> cast { get; set; }
        }


    }
}
