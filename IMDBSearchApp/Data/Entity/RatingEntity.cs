using Newtonsoft.Json;
using Realms;

namespace IMDBSearchApp.Data.Entity
{
    public class RatingEntity: RealmObject
    {
        [JsonProperty("Source")]
        public string RatingSource { get; set; }

        [JsonProperty("Value")]
        public string RatingValue { get; set; }

    }
}
