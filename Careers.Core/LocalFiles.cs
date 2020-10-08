using Careers.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Careers.Core {
    public class LocalFiles {
        public string UniversitiesLocation { get; set; }
        public List<University> Universities { get; set; }
        public LocalFiles()
        {
            UniversitiesLocation = "C:\\Users\\Пользователь\\source\repos\\CareerManager\\Careers.Core\bin\\Debug";
        }
    }
}
