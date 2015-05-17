using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;


namespace RentalSystem
{
    class RentManager: Database_Com_Manager
    {


        public List<Rent> select()
        {
            string query = "SELECT Id,Address_id__c,Tenant_id__c,Total_amount__c,Amount_Paid__c,Amount_Change__c,Date_Due__c,Date_Paid__c FROM Rent__c";
            RentRecord record = null;

            try
            {
                // send request using method POST
                webrequest = WebRequest.Create(new Uri(BaseURI + Restendpoint + "/" + APIversion + "/query/?q=" + query));
                webrequest.Method = WebRequestMethods.Http.Get;
                webrequest.Headers.Add("Authorization", "Bearer " + Accesstoken);
            }
            catch (Exception e)
            {
                this.message = e.Message;
            }
            finally
            {

            }
            try
            {
                // retrieve the response
                webresponse = webrequest.GetResponse();
                // read the response and place it into the stream reader
                streamreader = new System.IO.StreamReader(webresponse.GetResponseStream());
                // place the json data into list
                jsondata = streamreader.ReadToEnd();
                record = JsonConvert.DeserializeObject<RentRecord>(jsondata);
            }
            catch (Exception e)
            {
                message += e.Message;
            }
            finally
            {
                streamreader.Close();
            }

            return record.records;
        }
    }
}
