using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace PwCProject
{
    /// <summary>
    /// The class contains the method to read the json configuration from the file.
    /// </summary>
    public class ConfigSettings
    {
        //static String configSettingsPath = @"C:\Users\khushdeep.gupta\source\repos\pwcProject\pwcProject\Config\\JSONConfigFile.json";

          static string configSettingsPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
           + Path.DirectorySeparatorChar + "Config" + Path.DirectorySeparatorChar + "JSONConfigFile.json";
        /// <summary>
        /// This method reads the application configurtation data from JSONConfigFile and returns the configuration instance. 
        /// </summary>
        /// <returns>IConfiguration</returns>
        public static IConfiguration InitConfig()
        {
            JsonConfig conf = new JsonConfig();
            var config = new ConfigurationBuilder().AddJsonFile(configSettingsPath).Build();
            config.Bind(conf);
            return config;
        }
        private class JsonConfig
        {
            private Configuration Configuration { get; set; }
        }
        private class Configuration
        {
            private string BrowserName { get; set; }
            private string URL { get; set; }
            private string Filepath { get; set; }
        }
    }
}
