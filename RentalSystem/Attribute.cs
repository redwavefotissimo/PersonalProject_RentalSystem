using Newtonsoft.Json;

namespace RentalSystem
{
    class Attribute
    {
        [JsonProperty(PropertyName = "type")]
        public string type { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string url { get; set; }
    }
}
