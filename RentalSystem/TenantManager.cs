using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace RentalSystem
{
    class TenantManager: Database_Com_Manager
    {
        public void insert(string addressId, string firstName, string middleName, string lastName)
        {
            string jsondata = "{" +
                                  dq + "Address_id__c" + dq + " : " + dq + addressId + dq + ", " +
                                  dq + "First_name__c" + dq + " : " + dq + firstName + dq + ", " +
                                  dq + "Middle_name__c" + dq + " : " + dq + middleName + dq + ", " +
                                  dq + "Last_name__c" + dq + " : " + dq + lastName + dq +
                              "}";
            try
            {
                // send request using method POST
                webrequest = WebRequest.Create(new Uri(BaseURI + Restendpoint + "/" + APIversion + "/sobjects/Tenant__c/"));
                webrequest.Method = WebRequestMethods.Http.Post;
                webrequest.ContentType = "application/json";
                webrequest.Headers.Add("Authorization", "Bearer " + Accesstoken);
                // get request stream and use stream writer to place form data to resend the request
                streamwriter = new System.IO.StreamWriter(webrequest.GetRequestStream());
                streamwriter.Write(jsondata);
            }
            catch (Exception e)
            {
                this.message = e.Message;
            }
            finally
            {
                streamwriter.Close();
            }
            try
            {
                // retrieve the response
                webresponse = webrequest.GetResponse();
            }
            catch (Exception e)
            {
                message += e.Message;
            }
            finally
            {
                streamreader.Close();
            }
        }
        public void update(string firstName, string middleName, string lastName, string dataid)
        {
            // the address_id_c is removed because it cannot be updated, if you include it, the error will be 400 bad request
            string jsondata = "{" +
                                 dq + "First_name__c" + dq + " : " + dq + firstName + dq + ", " +
                                 dq + "Middle_name__c" + dq + " : " + dq + middleName + dq + ", " +
                                 dq + "Last_name__c" + dq + " : " + dq + lastName + dq +
                             "}";
            try
            {
                // send request using method POST
                webrequest = WebRequest.Create(new Uri(BaseURI + Restendpoint + "/" + APIversion + "/sobjects/Tenant__c/" + dataid));
                webrequest.Method = "PATCH";
                webrequest.ContentType = "application/json";
                webrequest.Headers.Add("Authorization", "Bearer " + Accesstoken);
                // get request stream and use stream writer to place form data to resend the request
                streamwriter = new System.IO.StreamWriter(webrequest.GetRequestStream());
                streamwriter.Write(jsondata);
            }
            catch (Exception e)
            {
                this.message = e.Message;
            }
            finally
            {
                streamwriter.Close();
            }
            try
            {
                // retrieve the response
                webresponse = webrequest.GetResponse();
            }
            catch (Exception e)
            {
                message += e.Message;
            }
            finally
            {
                streamreader.Close();
            }
        }

        public void delete(string dataid)
        {
            try
            {
                // send request using method POST
                webrequest = WebRequest.Create(new Uri(BaseURI + Restendpoint + "/" + APIversion + "/sobjects/Tenant__c/" + dataid));
                webrequest.Method = "DELETE";
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
            }
            catch (Exception e)
            {
                message += e.Message;
            }
            finally
            {

            }
        }

        public List<Tenant> select()
        {
            string query = "SELECT Id,First_name__c,Middle_name__c,Last_name__c,Address_id__c FROM Tenant__c";
            TenantRecord record = null;

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
                record = JsonConvert.DeserializeObject<TenantRecord>(jsondata);
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
