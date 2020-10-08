using System;
using System.Collections.Generic;
using System.Text;

namespace Careers.Core.Model {
    public class Vacancy {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public List<Apply> Applies { get; set; }
        public Recruter Recruter { get; set; }
    }
}
