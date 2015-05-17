using Newtonsoft.Json;
using System.Collections.Generic;

namespace RentalSystem
{
    class TenantRecord
    {
        [JsonProperty(PropertyName = "totalSize")]
        public int totalSize { get; set; }

        [JsonProperty(PropertyName = "done")]
        public bool done { get; set; }

        [JsonProperty(PropertyName = "records")]
        public List<Tenant> records { get; set; }
    }
}
