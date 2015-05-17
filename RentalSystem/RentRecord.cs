using Newtonsoft.Json;
using System.Collections.Generic;

namespace RentalSystem
{
    class RentRecord
    {
        [JsonProperty(PropertyName = "totalSize")]
        public int totalSize { get; set; }

        [JsonProperty(PropertyName = "done")]
        public bool done { get; set; }

        [JsonProperty(PropertyName = "records")]
        public List<Rent> records { get; set; }
    }
}
