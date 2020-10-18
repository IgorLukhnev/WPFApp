using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Careers.Core.Model {
    public class Recruter {
        private static int currentId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
        //public List<int> VacIds { get; set; } = new List<int>();

        public Recruter(string name, string surname, string company, DateTime birthDate, string username, string password)
        {
            Id = currentId++;
            Name = name;
            Surname = surname;
            Company = company;
            BirthDate = birthDate;
            Username = username;
            Password = password;
        }
        static public bool Validate(string name, string surname, string company, DateTime? birthDate, string username)
        {
            return !string.IsNullOrEmpty(name) & !string.IsNullOrEmpty(surname) & birthDate.HasValue &
                !string.IsNullOrEmpty(company) & !string.IsNullOrEmpty(username);
        }

        //public void ToSave()
        //{
        //    foreach (var vacancy in Vacancies)
        //    {
        //        VacIds.Add(vacancy.Id);
        //    }
        //}
        //public void Recover(List<Vacancy> vacancies)
        //{
        //    foreach (var id in VacIds)
        //    {
        //        Vacancies.Add(vacancies.FirstOrDefault(v => v.Id == id));
        //    }
        //}
    }
}
