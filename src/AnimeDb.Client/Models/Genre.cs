using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimeDb.Client.Models
{
    public class Genre
    {
        [JsonPropertyName("_id")]
        public string Name { get; set; } = string.Empty;
    }
}
