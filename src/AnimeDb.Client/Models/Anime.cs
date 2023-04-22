using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimeDb.Client.Models
{
    public class Anime
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public IEnumerable<string> AlternativeTitles { get; set; } = Enumerable.Empty<string>();

        public int Ranking { get; set; }

        public IEnumerable<string> Genres { get; set; } = Enumerable.Empty<string>();

        public int Episodes { get; set; }

        public bool HasEpisode { get; set; }

        public bool HasRanking { get; set; }

        public string Image { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Synopsis { get; set; } = string.Empty;

        public string Thumb { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Link { get; set; } = string.Empty;

        public string Page => $"ViewerPage.xaml?Id={Id}";

    }
}
