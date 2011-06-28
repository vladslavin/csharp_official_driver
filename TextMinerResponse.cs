using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strider.Client.TextMiner.Client
{
    public class TextMinerResponse
    {
        private int articleId;
        private string source;
        private string author;
        private string title;
        private Uri url;
        private string summary;
        private string timeStamp;
        private string processedIn;
        private string languageCode;
        private List<string> tagList = null;
        private Dictionary<string, string> categoryDict = null;

        public int ArticleId
        {
            get { return articleId; }
            set { articleId = value; }
        }

        public string Source
        {
            get { return source; }
            set { source = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public Uri Url
        {
            get { return url; }
            set { url = value; }
        }

        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        public string Timestamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }

        public string ProcessedIn
        {
            get { return processedIn; }
            set { processedIn = value; }
        }

        public string LanguageCode
        {
            get { return languageCode; }
            set { languageCode = value; }
        }

        public List<string> TagList
        {
            get { return tagList; }
            set { tagList = value; }
        }

        public Dictionary<string, string> CategoryDict
        {
            get { return categoryDict; }
            set { categoryDict = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Requested artcle id: " + ArticleId);
            sb.AppendLine("Source: " + Source);
            sb.AppendLine("Author: " + Author);
            sb.AppendLine("Title: " + Title);
            sb.AppendLine("URL: " + Url);
            sb.AppendLine("Summary: " + Summary);
            sb.AppendLine("TimeStamp: " + timeStamp);
            sb.AppendLine("Processed In: " + processedIn);
            
            if (tagList != null && tagList.Count > 0)
            {
                sb.Append("Tags: ");
                foreach (string tag in tagList)
                {
                    sb.Append(" " + tag + "\n");
                }
            }

            if (categoryDict != null && categoryDict.Count > 0)
            {
                sb.Append("Categories: ");
                foreach (var cat in categoryDict)
                {
                    sb.Append(" " + cat.Key + ":" + cat.Value + "\n");
                }
            }

            return sb.ToString();
        }
    }
}