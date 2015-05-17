using Newtonsoft.Json;
using System.Collections.Generic;

namespace RentalSystem
{
    class Rent
    {
        [JsonProperty(PropertyName = "attributes")]
        public Attribute attributes { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Address_id__c")]
        public string Address_id__c { get; set; }

        [JsonProperty(PropertyName = "Tenant_id__c")]
        public string Tenant_id__c { get; set; }

        [JsonProperty(PropertyName = "Total_amount__c")]
        public int Total_amount__c { get; set; }

        [JsonProperty(PropertyName = "Amount_Paid__c")]
        public int Amount_Paid__c { get; set; }

        [JsonProperty(PropertyName = "Amount_Change__c")]
        public int Amount_Change__c { get; set; }

        // for date format 'yyyy-mm-ddThh:mm:ss'
        [JsonProperty(PropertyName = "Date_Due__c")]
        public string Date_Due__c { get; set; }

        [JsonProperty(PropertyName = "Date_Paid__c")]
        public string Date_Paid__c { get; set; }
    }
}
