using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Net;
using System.Xml.Linq;
using System.IO;

namespace Strider.Client.TextMiner.Client
{
    public class ClientService : StriderService
    {
        private string endPoint;

        public ClientService(string _endPoint)
        {
            this.endPoint = _endPoint;
        }

        public Client RequestApiKey(string organization, string email, string person)
        {

            Console.WriteLine("Accessing " + this.endPoint);

            StringBuilder postData = new StringBuilder();
            postData.Append("organization=");
            postData.Append(organization);
            postData.Append("&email=");
            postData.Append(email);
            postData.Append("&name=");
            postData.Append(person);

            string response = Post(endPoint, "application/x-www-form-urlencoded", postData.ToString());
            var xml_res = XElement.Parse(response);
            var clients =
                from e in xml_res.Elements("client")
                select new Client
                {
                    StatusCode = (int)e.Element("status"),
                    Message = (string)e.Element("message"),
                    ApiKey = (string)e.Element("apikey"),
                    Timestamp = (string)e.Element("timestamp")
                };

            Client client = (Client)clients.ToArray().GetValue(0);
            client.Email = email;
            client.Organization = organization;
            client.Person = person;

            return client;
        }
    }
}