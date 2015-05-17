using Newtonsoft.Json;

namespace RentalSystem
{
    class Tenant
    {
        [JsonProperty(PropertyName = "attributes")]
        public Attribute attributes { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Address_id__c")]
        public string Address_id__c { get; set; }

        [JsonProperty(PropertyName = "First_name__c")]
        public string First_name__c { get; set; }
        
        [JsonProperty(PropertyName = "Middle_name__c")]
        public string Middle_name__c { get; set; }

        [JsonProperty(PropertyName = "Last_name__c")]
        public string Last_name__c { get; set; }
    }
}
