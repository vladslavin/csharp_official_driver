using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strider.Client.TextMiner.Client
{
    public class WordDefinitions
    {
        private string word;
        private List<string> definitionList;

        public string Word
        {
            get { return word; }
            set { word = value; }
        }

        public List<string> definitions
        {
            get { return definitionList; }
            set { definitionList = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Requested word: " + Word);
            if (definitionList != null && definitionList.Count > 0)
            {
                sb.Append("Synonyms: ");
                foreach (string definition in definitionList)
                {
                    sb.Append(" " + definition + "\n");
                }
            }

            return sb.ToString();
        }
    }
}