using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strider.Client.TextMiner.Client
{
    public class Client
    {
        private int statusCode;
        private string organization;
        private string apiKey;
        private string email;
        private string person;
        private string message;
        private string timestamp;

        public int StatusCode
        {
            get { return statusCode; }
            set { statusCode = value; }
        }

        public string Organization
        {
            get { return organization; }
            set { organization = value; }
        }

        public string ApiKey
        {
            get { return apiKey; }
            set { apiKey = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Person
        {
            get { return person; }
            set { person = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Status code: " + statusCode);
            sb.AppendLine(" Client Name: " + Organization);
            sb.AppendLine(" API Key: " + apiKey);
            sb.AppendLine(" Email: " + email);
            sb.AppendLine(" Person: " + person);
            sb.AppendLine(" Message: " + message);
            sb.AppendLine(" Timestamp: " + timestamp);
            return sb.ToString();
        }
    }
}