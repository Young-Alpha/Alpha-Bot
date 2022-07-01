using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public struct configjson
    {
        [JsonProperty("Token")]
        public string Token { get; private set; }
        [JsonProperty("Prefix")]
        public string Prefix { get; private set; }
    }
}
