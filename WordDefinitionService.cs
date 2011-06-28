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
    public class WordDefinitionService : StriderService
    {
        private string endPoint;

        public WordDefinitionService(string _endPoint)
        {
            this.endPoint = _endPoint;
        }

        public WordDefinitions GetWordDefinitions(string word)
        {

            string response = Get(this.endPoint + word);

            WordDefinitions dto = new WordDefinitions();
            List<string> defList = new List<string>();

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

            var element = xml_res.Element("definitions");
            var definitions = new string[] { };
            if (element == null)
            {
                return null;
            }

            definitions = xml_res.Element("definitions").Elements("definition").Select(ox => ox.Value.Trim()).ToArray();
            if (definitions.Count() == 0)
            {
                return null;
            }

            dto = new WordDefinitions();
            defList = new List<string>();
            dto.Word = requestedWord;
            for (int i = 0; i < definitions.Length; i++)
            {
                defList.Add(definitions[i]);
            }
            dto.definitions = defList;


            return dto;
        }
    }
}