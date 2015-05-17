using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;

namespace RentalSystem
{
    // this class concerns about getting the oauth token, access token and refresh token
    class Database_Com_Manager
    {
        // variables
        public string message;
        private XmlDocument xmldoc;
        protected char dq = '"'; // double quote
        private string Oauthendpoint;
        protected string Username;
        protected string Password;
        protected string Consumerkey;
        protected string Consumersecret;
        protected string BaseURI;
        protected string Restendpoint;
        protected string Accesstoken;
        protected string APIversion;
        protected WebRequest webrequest;
        protected WebResponse webresponse;
        protected StreamWriter streamwriter;
        protected StreamReader streamreader;
        protected DataTable dt;
        protected int RowCount;
        protected string jsondata;

        public Database_Com_Manager()
        {
            // load xml data
            xmldoc = new XmlDocument();
            xmldoc.Load("Database_Com_Secret.xml");
            APIversion = xmldoc.DocumentElement.SelectSingleNode("/Credential/APivs").InnerText.Replace("\r\n", "").Trim();
            Accesstoken = xmldoc.DocumentElement.SelectSingleNode("/Credential/Atoken").InnerText.Replace("\r\n", "").Trim();
            // Fill up fields
            Username = "vince_lui@ymail.com";
            Password = "bluedragon1IpsOC3QcM64AXB1XklqGChAi";
            Consumerkey = "3MVG9Y6d_Btp4xp7rkQdvqu8EX9ek2yD_Zjzki4iFSMywYY.7HGHobYvNAGz.CM6DOVQdPmkrzO6XYoXWuaYb";
            Consumersecret = "8973951286469917659";
            BaseURI = "https://fun-energy-4301.database.com";
            Oauthendpoint = "/services/oauth2/token";
            Restendpoint = "/services/data";
            message = "";

            // get access token here
            generateAccestoken();
            // saves the access token here
            xmldoc.DocumentElement.SelectSingleNode("/Credential/Atoken").InnerText = Accesstoken;
            xmldoc.Save("Database_Com_Secret.xml");
            
        }

        private void generateAccestoken()
        {
            try
            {
                // send request using method POST
                webrequest = WebRequest.Create(new Uri(BaseURI + Oauthendpoint));
                webrequest.Method = WebRequestMethods.Http.Post;
                webrequest.ContentType = "application/x-www-form-urlencoded";
                // get request stream and use stream writer to place form data to resend the request
                streamwriter = new StreamWriter(webrequest.GetRequestStream());
                streamwriter.Write("grant_type=password" +
                                  "&client_id=" + Consumerkey +
                                  "&client_secret=" + Consumersecret +
                                  "&username=" + Username +
                                  "&password=" + Password);
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            finally
            {
                streamwriter.Close();
            }
            try
            {
                // retrieve the response
                webresponse = webrequest.GetResponse();
                // read the response and place it into the stream reader
                streamreader = new StreamReader(webresponse.GetResponseStream());
                // get the access token part
                Accesstoken = streamreader.ReadToEnd().Split(',')[4].Split(':')[1].ToString().Replace("\"", "").Replace("}", "");
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

        public DataTable getDt()
        {
            RowCount = dt.Rows.Count;
            return dt;
        }

        public int getTotalRow()
        {
            return RowCount;
        }
    }
}
