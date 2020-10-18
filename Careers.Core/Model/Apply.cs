using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Careers.Core.Model {
    public enum ApplyStatus {
        NotOperated,
        Denied,
        Accepted
    }
    public class Apply {
        private static int currentId = 1;
        public int Id { get; set; }
        public DateTime CreatedDt { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public Vacancy Vacancy { get; set; }
        public int VacancyId { get; set; }
        public ApplyStatus Status { get; set; }


        public Apply(User user, Vacancy vacancy, int userId, int vacancyId)
        {
            Id = currentId++;
            CreatedDt = DateTime.Now;
            User = user;
            UserId = userId;
            Vacancy = vacancy;
            VacancyId = vacancyId;
            Status = ApplyStatus.NotOperated;
        }
        public void Recover(List<User> users, List<Vacancy> vacancies)
        {
            User = users.FirstOrDefault(u => u.Id == UserId);
            Vacancy = vacancies.FirstOrDefault(v => v.Id == VacancyId);
            User.Applies.Add(this);
            Vacancy.Applies.Add(this);
        }
    }
}
