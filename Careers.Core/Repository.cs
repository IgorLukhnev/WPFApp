using Careers.Core.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Careers.Core {
    public class Repository {
        public User CurrentUser { get; set; }
        public List<University> Universities { get; set; }
        public List<User> Users { get; set; }
        public List<Recruter> Recruters { get; set; }
        public List<Vacancy> Vacancies { get; set; }
        public Recruter CurrentHR { get; set; }

        public Repository()
        {
            Universities = LocalFiles.LoadUniversities();
            Users = LocalFiles.LoadUserConfig();
            Recruters = LocalFiles.LoadHRConfig();
            Vacancies = new List<Vacancy>();
        }

        public void CreateNewUser(string name, string surname, string email, DateTime? birthDate, string username,
            string password, string university, Degree degree, string program, DateTime? graduateDate,
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
        public void CreateNewRecruter(string name, string surname, DateTime? birthDate, string company, string username, string password)
        {
            CurrentHR = new Recruter
            {
                Name = name,
                Surname = surname,
                BirthDate = (DateTime)birthDate,
                Company = company,
                Username = username,
                Password = password
            };
            Recruters.Add(CurrentHR);
        }
        public void SaveConfig()
        {
            LocalFiles.SaveUserConfig("users.json", Users);
            LocalFiles.SaveHRConfig("recruters.json", Recruters);
        }
        public bool AuthorizeUser(string login, string password)
        {
            CurrentUser = Users.FirstOrDefault(user => user.Username == login && user.Password == password);
            return CurrentUser != null;
        }
        public bool AuthorizeHR(string login, string password)
        {
            CurrentHR = Recruters.FirstOrDefault(hr => hr.Username == login && hr.Password == password);
            return CurrentHR != null;
        }
    }
}
