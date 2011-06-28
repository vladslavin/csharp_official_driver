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
    public class SynonymService : StriderService
    {
        private string endPoint;

        public SynonymService(string _endPoint)
        {
            this.endPoint = _endPoint;
        }

        public Synonyms GetSynonyms(string word)
        {

            string response = Get(this.endPoint + word);

            Synonyms dto = new Synonyms();
            List<string> synList = new List<string>();

            var xml_res = XElement.Parse(response);
            string requestedWord;
            
            XElement xmlElement = xml_res.Element("word");
            if (xmlElement != null)
            {
                requestedWord = xmlElement.Value;
            }
            else
            {
                dto.Word = word;
                return dto;
            }

            var element = xml_res.Element("synonyms");
            var synonyms = new string[] { };
            if (element == null)
            {
                return null;
            }

            synonyms = xml_res.Element("synonyms").Elements("syn").Select(ox => ox.Value.Trim()).ToArray();
            if (synonyms.Count() == 0)
            {
                return null;
            }

            dto = new Synonyms();
            synList = new List<string>();
            dto.Word = requestedWord;
            for (int i = 0; i < synonyms.Length; i++)
            {
                synList.Add(synonyms[i]);
            }
            dto.synonyms = synList;


            return dto;
        }
    }
}