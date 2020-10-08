using System;
using System.Collections.Generic;
using System.Text;

namespace Careers.Core.Model {
    public class WorkExperience {
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }
}
