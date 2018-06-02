using Realms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IMDBSearchApp.Data.Entity
{
    public class MovieEntity: RealmObject
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

        [JsonProperty("Rated")]
        public string Rated { get; set; }

        [JsonProperty("Released")]
        public string Released { get; set; }

        [JsonProperty("Runtime")]
        public string Runtime { get; set; }

        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Writer")]
        public string Writer { get; set; }

        [JsonProperty("Actors")]
        public string Actors { get; set; }

        [JsonProperty("Plot")]
        public string Plot { get; set; }

        [JsonProperty("Poster")]
        public string Poster { get; set; }

        [JsonProperty("imdbRating")]
        public string imdbRating { get; set; }

        [JsonProperty("Production")]
        public string Production { get; set; }

        [JsonProperty("Website")]
        public string Website { get; set; }

        [JsonProperty("Ratings")]
        public IList<RatingEntity> Ratings { get; }
    }
}
