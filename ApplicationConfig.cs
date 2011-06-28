using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;
using System.IO;
using System.Xml.Linq;
using System.Net;

namespace Strider.Client.TextMiner.Utils
{
    /**
     * This class reads parameteres defined in AppConfig 
     * and provides getter methods for each of the parameter.
     */
    public class ApplicationConfig
    {
        private static NameValueCollection appSettings = null;

        /**
         * Defines static constructor
         */
        static ApplicationConfig()
        {
            // Read the AppSettings section.
            appSettings = ConfigurationManager.AppSettings;
            
            // Configuration Manager is not set to Strider's default configuration file.
            if (appSettings["textMinerEndPoint"] == null)
            {
                appSettings = new NameValueCollection();
                try
                {
                    string path = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
                    var configAsFlatText = File.ReadAllText(Path.Combine(path, "App.config"));
                    ParseXmlConfiguration(configAsFlatText);
                }

                catch (Exception exc)
                {
                    // using default values here, which we can download from the server with a simple get request.
                    // ideally this should be abstracted away, but not far away ;-)
                    string remoteAppConfig = new WebClient().DownloadString("http://striderdi.com/App.config");
                    ParseXmlConfiguration(remoteAppConfig);
                    System.Diagnostics.Debug.WriteLine(exc.Message);
                }
            }
        }

        private static void ParseXmlConfiguration(string configAsFlatText)
        {
            var parsedXmlConfig = XElement.Parse(configAsFlatText);
            var endPoints = parsedXmlConfig.Element("appSettings").Elements()
                .Select(eachEndPoint => new
                {
                    Key = eachEndPoint.Attribute("key").Value,
                    Value = eachEndPoint.Attribute("value").Value
                });
            foreach (var endPoint in endPoints)
            {
                appSettings.Add(endPoint.Key, endPoint.Value);
            }
        }

        public ApplicationConfig()
        {
            
        }

        /**
         * Returns synnet endpoint defined in AppConfig.cs.
         * If appSettings is null, returns null.
         */
        public string GetSynNetEndPoint()
        {
            if (appSettings != null)
            {
                return appSettings["synNetEndPoint"];
            }
            else
            {
                return null;
            }
        }

        /**
         * Returns synnet endpoint defined in AppConfig.cs.
         * If appSettings is null, returns null.
         */
        public string GetWordDefinitionEndPoint()
        {
            if (appSettings != null)
            {
                return appSettings["wordDefinitionEndPoint"];
            }
            else
            {
                return null;
            }
        }

        /**
         * Returns synnet endpoint defined in AppConfig.cs.
         * If appSettings is null, returns null.
         */
        public string GetTextMinerEndPoint()
        {
            if (appSettings != null)
            {
                return appSettings["textMinerEndPoint"];
            }
            else
            {
                return null;
            }
        }

        /**
         * Returns client service endpoint defined in AppConfig.cs.
         * If appSettings is null, returns null.
         */
        public string GetClientServiceEndPoint()
        {
            if (appSettings != null)
            {
                return appSettings["clientServiceEndPoint"];
            }
            else
            {
                return null;
            }
        }

    }
}
