using System;
using System.Collections.Generic;
using System.Text;

namespace Careers.Core.Model {
    public enum Degree {
        Bachelor,
        Master,
        Specialist,
        GraduateStudent,
        Doctor
    }
    public class Education {
        public University University { get; set; }
        public Degree Degree { get; set; }
        public string Program { get; set; }
        public DateTime GraduateDate { get; set; }
    }
}
