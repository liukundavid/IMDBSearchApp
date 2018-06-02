using Newtonsoft.Json;
using Realms;

namespace IMDBSearchApp.Data.Entity
{
    public class MovieSummaryEntity: RealmObject
    {
        [PrimaryKey]
        [JsonProperty("imdbID")]
        public string imdbID { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Poster")]
        public string Poster { get; set; }
    }
}
