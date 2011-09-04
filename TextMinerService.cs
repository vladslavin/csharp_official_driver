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
    public class TextMinerService : StriderService
    {
        private string endPoint;

        public TextMinerService(string _endPoint)
        {
            this.endPoint = _endPoint;
        }

        public TextMinerResponse Get(string apiKey, int articleId)
        {

            Console.WriteLine("Accessing " + this.endPoint + apiKey + "/" + articleId);
            string response = Get(this.endPoint + apiKey + "/" + articleId);

            TextMinerResponse dto = new TextMinerResponse();
            List<string> defList = new List<string>();

            var xml_res = XElement.Parse(response);

            XElement idElement = xml_res.Element("id");
            if (idElement != null)
            {
                articleId = Int32.Parse(idElement.Value);
            }
            else
            {
                return null;
            }

            string source = xml_res.Element("source").Value ?? "Not specified";
            string author = xml_res.Element("author").Value ?? "Not specified";
            string title = xml_res.Element("title").Value ?? "Not specified";
            Uri url = new Uri(xml_res.Element("url").Value ?? "");
            string summary = xml_res.Element("summary").Value ?? "Not specified";
            string timestamp = xml_res.Element("timestamp").Value ?? "Not specified";
            string processedIn = xml_res.Element("processed_in").Value ?? "Not specified";

            XElement languageElement = xml_res.Element("language");
            string languageCode = "en"; // default
            if (languageElement != null)
            {
                languageCode = languageElement.Value ?? "Not specified";
            }
            
            var tags = new string[] {};
            if (xml_res.Element("tags") != null)
            {
                tags = xml_res.Element("tags").Elements("tag").Select(ox => ox.Value.Trim()).ToArray();
            }

            var categories = new string[] {};
            Dictionary<string, string> categoryDict = new Dictionary<string, string>();
            if (xml_res.Element("categories") != null)
            {
                var query =
                    from category in xml_res.Descendants("category")
                    select new
                    {
                        name = (from name in category.Descendants("name")
                                select name).FirstOrDefault().Value
                        ,
                        confidence = (from confidence in category.Descendants("confidence")
                                      select confidence).FirstOrDefault().Value
                    };
                
                foreach (var y in query)
                {
                    categoryDict.Add(y.name, y.confidence);
                }
            }

            dto = new TextMinerResponse();
            List<string> tagList = new List<string>();
            dto.ArticleId = articleId;
            dto.Source = source;
            dto.Author = author;
            dto.Title = title;
            dto.Url = url;
            dto.Summary = summary;
            dto.Timestamp = timestamp;
            dto.ProcessedIn = processedIn;
            dto.LanguageCode = languageCode;

            for (int i = 0; i < tags.Length; i++)
            {
                tagList.Add(tags[i]);
            }
            dto.TagList = tagList;

            dto.CategoryDict = categoryDict;

            return dto;
        }

        public TextMinerResponse Post(string author, string title, Uri url, string text, 
                                      string keywords, string topic, string description, string apikey)
        {
            // build the XML file
            StringBuilder sb = new StringBuilder();
            sb.Append("<tagger>");
            sb.Append("<author>").Append(author).Append("</author>");
            sb.Append("<title>").Append(title).Append("</title>");
            sb.Append("<url>").Append(url.ToString()).Append("</url>");
            sb.Append("<text>").Append(text).Append("</text>");
            sb.Append("<keywords>").Append(keywords).Append("</keywords>");
            sb.Append("<topic>").Append(topic).Append("</topic>");
            sb.Append("<description>").Append(description).Append("</description>");
            sb.Append("<apikey>").Append(apikey).Append("</apikey>");
            sb.Append("</tagger>");

            Console.WriteLine("Accessing " + this.endPoint);
            string response = Post(endPoint, "application/xml", sb.ToString());

            TextMinerResponse dto = new TextMinerResponse();
            List<string> defList = new List<string>();

            var xml_res = XElement.Parse(response);

            int articleId = 0;
            XElement xmlElement = xml_res.Element("id");
            if (xmlElement != null)
            {
                articleId = Int32.Parse(xmlElement.Value);
            }
            else
            {
                return null;
            }

            string source       = xml_res.Element("source").Value ?? "Not specified";
            string internalUrl  = xml_res.Element("url").Value ?? "";
            string timestamp    = xml_res.Element("timestamp").Value ?? "Not specified";
            string processedIn  = xml_res.Element("processed_in").Value ?? "Not specified";
            string languageCode = xml_res.Element("language").Value ?? "Not specified";

            var tags = new string[] { };
            if (xml_res.Element("tags") != null)
            {
                tags = xml_res.Element("tags").Elements("tag").Select(ox => ox.Value.Trim()).ToArray();
            }

            dto = new TextMinerResponse();
            List<string> tagList = new List<string>();
            dto.ArticleId = articleId;
            dto.Source = source;
            dto.Author = author;
            dto.Title = title;
            dto.Url = new Uri(endPoint + "/" + internalUrl);
            dto.Timestamp = timestamp;
            dto.ProcessedIn = processedIn;
            dto.LanguageCode = languageCode;

            for (int i = 0; i < tags.Length; i++)
            {
                tagList.Add(tags[i]);
            }
            dto.TagList = tagList;

            return dto;
        }

    }
}