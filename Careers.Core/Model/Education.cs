using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        public string University { get; set; }
        public Degree Degree { get; set; }
        public string Program { get; set; }
        public DateTime GraduateDate { get; set; }

        static public bool Validate(string university, int? degree, string program, DateTime? graduated)
        {
            return !string.IsNullOrEmpty(university) && degree != null && !string.IsNullOrEmpty(program) &&
                graduated != null;
        }
        
        //public Education(string university, Degree degree, string program, DateTime graduateDt)
        //{
        //    University = university;
        //    Degree = degree;
        //    Program = program;
        //    GraduateDate = graduateDt;
        //    Id = currentId++;
        //}
    }
}
