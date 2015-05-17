using Newtonsoft.Json;

namespace RentalSystem
{
    class Address
    {
        [JsonProperty(PropertyName = "attributes")]
        public Attribute attributes { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Address__c")]
        public string Address__c { get; set; }

        [JsonProperty(PropertyName = "Max_load__c")]
        public int Max_load__c { get; set; }

        [JsonProperty(PropertyName = "Type__c")]
        public string Type__c { get; set; }        
    }
}
