using Careers.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Careers.Core {
    public class LocalFiles {
        static public string UniversitiesLocation { get; set; }
        static public List<string> LoadUniversities()
        {
            var result = new List<string>();
            UniversitiesLocation = "world-universities.csv";
            try
            {
                using (StreamReader sr = new StreamReader(UniversitiesLocation))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var info = line.Split(',');
                        result.Add(info[1].Replace('"', (char)0));
                    }
                    result.Sort();
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return result;
        }
        static public bool SaveUserConfig(string filename, List<User> data)
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    var ser = new DataContractJsonSerializer(data.GetType());
                    ser.WriteObject(fs, data);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        static public List<User> LoadUserConfig()
        {
            string location = "users.json";
            try
            {
                using (FileStream fs = new FileStream(location, FileMode.OpenOrCreate))
                {
                    var ser = new DataContractJsonSerializer(typeof(List<User>));
                    return (List<User>)ser.ReadObject(fs);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<User>();
            }
        }
    }
}
