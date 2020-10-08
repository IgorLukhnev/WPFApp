using System;
using System.Collections.Generic;
using System.Text;

namespace Careers.Core.Model {
    public enum ApplyStatus {
        NotOperated,
        Denied,
        Accepted
    }
    public class Apply {
        public DateTime CreatedDt { get; set; }
        public User User { get; set; }
        public Vacancy Vacancy { get; set; }
        public ApplyStatus Status { get; set; }
    }
}
