using System;
using System.Collections.Generic;
using System.Text;

namespace Careers.Core.Model {
    public class Recruter {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Vacancy> Vacancies { get; set; }
    }
}
