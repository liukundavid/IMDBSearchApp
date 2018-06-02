using System.Collections.Generic;
using Newtonsoft.Json;

namespace IMDBSearchApp.Data.Entity
{
    public class SearchResultEntity
    {
        [JsonProperty("Search")]
        public List<MovieSummaryEntity> SearchResults;
    }
}
