using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Careers.Core.Model {
    public class User {
        private static int currentId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SoftSkills { get; set; }
        public string HardSkills { get; set; }
        //public List<int> ApplyIds { get; set; } = new List<int>();
        //public List<int> EduIds { get; set; } = new List<int>();
        //public List<int> ExpIds { get; set; } = new List<int>();
        public List<Education> Educations { get; set; } = new List<Education>();
        public List<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
        public List<Apply> Applies { get; set; } = new List<Apply>();

        //public void ToSave()
        //{
        //    if (Applies != null)
        //    {
        //        foreach (var apply in Applies)
        //        {
        //            ApplyIds.Add(apply.Id);
        //        }
        //    }
        //}

        //public void Recover(List<Apply> applies)
        //{
        //    foreach (var id in ApplyIds)
        //    {
        //        Applies.Add(applies.FirstOrDefault(apply => apply.Id == id));
        //    }
        //}
        //public User(string name, string surname, string email, DateTime? birthDate, string username, string password,
        //    string softSkills, string hardSkills)
        //{
        //    Id = currentId++;
        //    Name = name;
        //    Surname = surname;
        //    Email = email;
        //    BirthDate = birthDate != null ? (DateTime)birthDate : new DateTime(1900, 1, 1);
        //    Username = username;
        //    Password = password;
        //    SoftSkills = softSkills;
        //    HardSkills = hardSkills;
        //}
        public User(string name, string surname, string email, DateTime? birthDate, string username, string password,
            string softSkills, string hardSkills, string university, Degree degree, string program, DateTime? graduateDate,
            string company, DateTime? startExp, DateTime? stopExp, string description)
        {
            Id = currentId++;
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate != null ? (DateTime)birthDate : new DateTime(1900, 1, 1);
            Username = username;
            Password = password;
            SoftSkills = softSkills;
            HardSkills = hardSkills;
            Educations = new List<Education> {
                    new Education {
                        University = university,
                        Degree = degree,
                        Program = program,
                        GraduateDate = graduateDate == null ? DateTime.Now : (DateTime) graduateDate
                    }
                };
            WorkExperiences = new List<WorkExperience>
                {
                    new WorkExperience()
                    {
                        Company = company,
                        StartDate = startExp == null ? DateTime.Now : (DateTime)startExp,
                        EndDate = stopExp,
                        Description = description
                    }
                };
            Applies = new List<Apply>();
        }

        static public bool Validate(string name, string surname, string email, DateTime? birthDate, string username)
        {
            return !string.IsNullOrEmpty(name) & !string.IsNullOrEmpty(surname) & birthDate.HasValue &
                !string.IsNullOrEmpty(email) & !string.IsNullOrEmpty(username);
        }
    }
}
