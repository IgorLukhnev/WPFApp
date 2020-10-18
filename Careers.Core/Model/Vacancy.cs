using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Careers.Core.Model {
    public class Vacancy {
        private static int currentId = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public List<Apply> Applies { get; set; } = new List<Apply>();
        //public List<int> applyIds { get; set; } = new List<int>();
        [JsonIgnore]
        public Recruter Recruter { get; set; }
        public int RecId { get; set; }
        [JsonConstructor]
        public Vacancy(int id, string title, string description, decimal salary, Recruter recruter, int rid)
        {
            Id = id;
            Title = title;
            Description = description;
            Salary = salary;
            Recruter = recruter;
            RecId = rid;
            currentId = id + 1;
        }
        public Vacancy(string title, string description, decimal salary, Recruter recruter, int id)
        {
            Id = currentId++;
            Title = title;
            Description = description;
            Salary = salary;
            Recruter = recruter;
            RecId = id;
        }

        //public void ToSave()
        //{
        //    foreach (var apply in Applies)
        //    {
        //        applyIds.Add(apply.Id);
        //    }
        //}

        //public void Recover(List<User> users)
        //{
        //    foreach (var apply in Applies)
        //    {
        //        apply.User = users.FirstOrDefault(u => u.Id == apply.UserId);
        //    }
        //}

        public void Recover(List<Recruter> recruters)
        {
            //foreach (var id in applyIds)
            //{
            //    Applies.Add(applies.FirstOrDefault(a => a.Id == id));
            //}
            Recruter = recruters.FirstOrDefault(r => r.Id == RecId);
        }
    }
}
