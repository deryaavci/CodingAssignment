using Newtonsoft.Json;

namespace CodingAssignment.src.Models.GetBikeThefts
{
    public class SearchCountResponse
    {
        [JsonProperty("non")]
        public long Non { get; set; }

        [JsonProperty("stolen")]
        public long Stolen { get; set; }

        [JsonProperty("proximity")]
        public long Proximity { get; set; }
    }
}
