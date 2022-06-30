using System;
using Newtonsoft.Json;
using System.IO;

namespace PwCProject
{
    /// <summary>
    /// The class contains the methods to read data from the json test data file. 
    /// </summary>
    public class ReadDataFromJson
    {
        public static Root jsonData { get; set; }

        /// <summary>
        /// The method deserializes the json test data provided in the json test data file. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Root</returns>
        public static Root JsonDeserialization(String filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                jsonData = JsonConvert.DeserializeObject<Root>(json);
                return jsonData;
            }
        }
        public class Root
        {
            public SearchData SearchData { get; set; }
        }
        public class SearchData
        {
            public string SearchValue { get; set; }
        }
    }
}
