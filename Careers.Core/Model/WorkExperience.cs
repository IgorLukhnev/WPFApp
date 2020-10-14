using System;
using System.Collections.Generic;
using System.Text;

namespace Careers.Core.Model {
    public class WorkExperience {
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }

        static public bool Validate(DateTime? startDate, string company, DateTime? endDate, string description)
        {
            return (startDate.HasValue && !string.IsNullOrEmpty(company) && !string.IsNullOrEmpty(description));
        }
    }
}
