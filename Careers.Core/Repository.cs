using Careers.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Careers.Core {
    public class Repository {
        public User CurrentUser { get; set; }
        public List<University> Universities { get; set; }
        public List<User> Users { get; set; }
        public List<Recruter> Recruters { get; set; }
        public List<Vacancy> Vacancies { get; set; }

        public Repository()
        {
            Universities = new List<University>();
            Users = new List<User>();
            Recruters = new List<Recruter>();
            Vacancies = new List<Vacancy>();
        }

        public void CreateNewUser(string name, string surname, string email, DateTime? birthDate, string username,
            string password, University university, Degree degree, string program, DateTime? graduateDate,
            string softSkills, string hardSkills, DateTime? startExp, DateTime? stopExp, string company, string description)
        {
            CurrentUser = new User
            {
                Name = name,
                Surname = surname,
                Email = email,
                BirthDate = birthDate != null ? (DateTime)birthDate : new DateTime(1900, 1, 1),
                Username = username,
                Password = password,
                SoftSkills = softSkills,
                HardSkills = hardSkills,
                Educations = new List<Education> {
                        new Education
                        {
                            University = university,
                            Degree = degree,
                            Program = program,
                            GraduateDate = (DateTime)graduateDate
                        }
                    },
                WorkExperiences = new List<WorkExperience>
                    {
                        new WorkExperience
                        {
                            Company = company,
                            StartDate = (DateTime)startExp,
                            EndDate = stopExp,
                            Description = description
                        }
                    }
            };
            Users.Add(CurrentUser);
        }
    }
}
