using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Careers.Core.Model {
    public class User {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SoftSkills { get; set; }
        public string HardSkills { get; set; }
        
        public List<Education> Educations { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; }
        public List<Apply> Applies { get; set; }
    }
}
