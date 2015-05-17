using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace RentalSystem
{
    class AddressManager: Database_Com_Manager
    {
        public void insert(string fulladdress, int max_load, string Type)
        {
            string jsondata = "{" +
                                  dq + "Address__c" + dq + " : " + dq + fulladdress + dq + ", " +
                                  dq + "Max_load__c" + dq + " : " + dq + max_load + dq + ", " +
                                  dq + "Type__c" + dq + " : " + dq + Type + dq +
                              "}";
            try
            {
                // send request using method POST
                webrequest = WebRequest.Create(new Uri(BaseURI + Restendpoint + "/" + APIversion + "/sobjects/Address__c/"));
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

        public void update(string fulladdress, int max_load, string Type, string dataid)
        {
            string jsondata = "{" +
                                  dq + "Address__c" + dq + " : " + dq + fulladdress + dq + ", " +
                                  dq + "Max_load__c" + dq + " : " + dq + max_load + dq + ", " +
                                  dq + "Type__c" + dq + " : " + dq + Type + dq +
                              "}";
            try
            {
                // send request using method POST
                webrequest = WebRequest.Create(new Uri(BaseURI + Restendpoint + "/" + APIversion + "/sobjects/Address__c/" + dataid));
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
                webrequest = WebRequest.Create(new Uri(BaseURI + Restendpoint + "/" + APIversion + "/sobjects/Address__c/" + dataid));
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

        public List<Address> select()
        {
            string query = "SELECT Id,Address__c,Max_load__c,Type__c FROM Address__c";
            AddressRecord record = null;

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
                record = JsonConvert.DeserializeObject<AddressRecord>(jsondata);
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
