using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strider.Client.TextMiner.Client
{
    public class Synonyms
    {
        private string word;
        private List<string> synonymList;

        public string Word
        {
            get { return word; }
            set { word = value; }
        }

        public List<string> synonyms
        {
            get { return synonymList; }
            set { synonymList = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Requested word: " + Word);
            if (synonymList != null && synonymList.Count > 0)
            {
                sb.Append("Synonyms: ");
                foreach (string synonym in synonymList)
                {
                    sb.Append(" " + synonym);
                }
            }

            return sb.ToString();
        }
    }
}