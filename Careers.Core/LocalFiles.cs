using Careers.Core.Model;
using Newtonsoft.Json;
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
            var test = new List<University>();
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
                        test.Add(new University {
                        Name = info[1],
                        Country = info[0]});
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

        static public bool SaveList<T> (List<T> data, string filename)
        {
            try
            {
                using (var sw = new StreamWriter(filename))
                {
                    using (var jsonWriter = new JsonTextWriter(sw))
                    {
                        var serializer = new JsonSerializer()
                        {
                            Formatting = Formatting.Indented
                        };
                        serializer.Serialize(jsonWriter, data);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        static public void SaveConfig(Repository repo)
        {
            if (SaveList(repo.Users, "users.json") && SaveList(repo.Vacancies, "vacancies.json") &&
                SaveList(repo.Recruters, "recruters.json") && SaveList(repo.Applies, "applies.json"))
            {
                Console.WriteLine("Successfull saving!");
            }
            else
                Console.WriteLine("Somethenig went wrong!");
        }

        static public List<T> LoadList<T>(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (var sr = new StreamReader(File.OpenRead(fileName)))
                {
                    using (var jsonReader = new JsonTextReader(sr))
                    {
                        var serializer = new JsonSerializer();
                        return (List<T>)serializer.Deserialize<List<T>>(jsonReader);
                    }
                }
            }
            else
                return new List<T>();
        }

    //    static public bool SaveUserConfig(string filename, List<User> data)
    //    {
    //        try
    //        {
    //            using (StreamWriter fs = new StreamWriter(filename))
    //            {
    //                foreach (var item in data)
    //                {
    //                    item.ToSave();
    //                }
                    
    //                var ser = new JsonSerializer();
    //                using (JsonTextWriter writer = new JsonTextWriter(fs))
    //                {
    //                    ser.Serialize(writer, data);
    //                }
    //            }
    //            return true;
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            return false;
    //        }
    //    }
    //    static public List<User> LoadUserConfig()
    //    {
    //        string location = "users.json";
    //        try
    //        {
    //            using (StreamReader fs = new StreamReader(location))
    //            {
    //                var ser = new JsonSerializer();
    //                using (JsonReader reader = new JsonTextReader(fs))
    //                    return (List<User>)ser.Deserialize(reader, typeof(List<User>));
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            return new List<User>();
    //        }
    //    }
    //    static public bool SaveHRConfig(string filename, List<Recruter> data)
    //    {
    //        try
    //        {
    //            using (StreamWriter fs = new StreamWriter(filename))
    //            {
    //                foreach (var item in data)
    //                {
    //                    item.ToSave();
    //                }

    //                var ser = new JsonSerializer();
    //                using (JsonTextWriter writer = new JsonTextWriter(fs))
    //                {
    //                    ser.Serialize(writer, data);
    //                }
    //            }
    //            return true;
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            return false;
    //        }
    //    }
    //    static public List<Recruter> LoadHRConfig()
    //    {
    //        string location = "recruters.json";
    //        try
    //        {
    //            using (FileStream fs = new FileStream(location, FileMode.OpenOrCreate))
    //            {
    //                var ser = new DataContractJsonSerializer(typeof(List<Recruter>));
    //                return (List<Recruter>)ser.ReadObject(fs);
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            return new List<Recruter>();
    //        }
    //    }
    }
}
