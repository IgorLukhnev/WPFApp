using Careers.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Careers.Core {
    public class LocalFiles {
        public string UniversitiesLocation { get; set; }
        public List<University> Universities { get; set; }
        public LocalFiles()
        {
            UniversitiesLocation = ".\\Careers.Core\bin\\Debug";
        }
        public void LoadUniversities()
        {
            try
            {
                using (StreamReader sr = new StreamReader(UniversitiesLocation))
                {
                    string line;
                    Universities = new List<University>();
                    while ((line = sr.ReadLine()) != null)
                    {
                        var info = line.Split(',');
                        University newUniversity = new University
                        {
                            Country = info[0],
                            Name = info[1]
                        };
                        Universities.Add(newUniversity);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
