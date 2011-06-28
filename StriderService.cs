using System;
using System.Runtime.Serialization;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Strider.Client.TextMiner.Client
{
    public class StriderService : IStriderService
    {
        public string Get(string endPoint)
        {
            string reponseAsString = "";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(endPoint);
                request.Method = "GET";
                request.UserAgent = "StriderDI TextMiner client";
                request.ContentType = "application/x-www-form-urlencoded";

                var response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    reponseAsString += "ERROR: " + response.StatusCode;
                }
                else
                {
                    reponseAsString += new StreamReader(response.GetResponseStream()).ReadToEnd();
                }                
            }
            catch (Exception ex)
            {
                reponseAsString += "ERROR: " + ex.Message;
            }

            return reponseAsString;
        }

        public string Post(string endPoint, string contentType, string postData)
        {
            WebRequest request = WebRequest.Create(endPoint);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData.ToCharArray(), 0, postData.Length);
            request.ContentType = contentType;
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string clientServiceResponse = reader.ReadToEnd();
            Console.WriteLine(clientServiceResponse);
            reader.Close();
            responseStream.Close();
            response.Close();

            return clientServiceResponse;
        }
    }    
}       