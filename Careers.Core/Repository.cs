using Careers.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Careers.Core {
    public class Repository {
        public event Action OnVacanciesChanged;
        public event Action OnAppliesChanged;
        public event Action OnExperienceChanged;
        public event Action OnEducationChanged;
        public User CurrentUser { get; set; }
        public List<string> Universities { get; set; }
        public List<User> Users { get; set; }
        public List<Recruter> Recruters { get; set; }
        public List<Vacancy> Vacancies { get; set; }
        public List<Apply> Applies { get; set; } = new List<Apply>();
        public Recruter CurrentHR { get; set; }
        public Vacancy CurrentVacancy { get; set; }
        public Apply CurrentApply { get; set; }
        public WorkExperience CurrentExperience { get; set; }

        public Repository()
        {
            Universities = LocalFiles.LoadUniversities();
            Users = LocalFiles.LoadList<User>("users.json");
            Recruters = LocalFiles.LoadList<Recruter>("recruters.json");
            //Vacancies = LocalFiles.LoadList<Vacancy>("vacancies.json");
            LoadVacancies();
            LoadApplies();
            Recover();
            //foreach (var user in Users)
            //    user.ApplyIds.Clear();
            //foreach (var rec in Recruters)
            //    rec.VacIds.Clear();
            //foreach (var vac in Vacancies)
            //    vac.applyIds.Clear();
        }

        public bool IsLoginFree(string username)
        {
            return Users.Select(u => u.Username).Contains(username) || Recruters.Select(u => u.Username).Contains(username);
        }

        private void LoadApplies()
        {
            Applies = new List<Apply>();
            foreach (var user in Users)
            {
                Applies.AddRange(user.Applies);
            }
        }

        public void AddNewVacancy(Vacancy vacancy)
        {
            CurrentHR.Vacancies.Add(vacancy);
            Vacancies.Add(vacancy);
            OnVacanciesChanged?.Invoke();
        }

        public void AddNewApply(Apply apply)
        {
            apply.Recover(Users, Vacancies);
            apply.Vacancy.Applies.Add(apply);
            Applies.Add(apply);
            SaveConfig();
            OnVacanciesChanged?.Invoke();
        }
        public void AddNewEducation(Education education)
        {
            CurrentUser.Educations.Add(education);
            OnEducationChanged?.Invoke();
        }

        public void AddNewExperience(WorkExperience experience)
        {
            CurrentUser.WorkExperiences.Add(experience);
            OnExperienceChanged?.Invoke();
        }

        public void UpdateExperience(DateTime startExp, string company, DateTime? endExp, string description)
        {
            var exp = Users.FirstOrDefault(u => u == CurrentUser).WorkExperiences.FirstOrDefault(ex => ex == CurrentExperience);
            exp.Company = company;
            exp.StartDate = startExp;
            exp.EndDate = endExp;
            exp.Description = description;
            OnExperienceChanged?.Invoke();
        }

        private void LoadVacancies()
        {
            Vacancies = new List<Vacancy>();
            foreach (var user in Recruters)
            {
                Vacancies.AddRange(user.Vacancies);
            }
        }

        public void DeleteVacancy(Vacancy vacancy)
        {
            foreach (var apply in vacancy.Applies)
            {
                Users.FirstOrDefault(u=>u.Id==apply.UserId).Applies.Remove(apply);
                Applies.Remove(apply);
            }
            Vacancies.Remove(vacancy);
            Recruters.FirstOrDefault(r=>r==CurrentHR).Vacancies.Remove(vacancy);
            OnAppliesChanged?.Invoke();
            OnVacanciesChanged?.Invoke();
            SaveConfig();
        }

        public void Recover()
        {
            //foreach (var user in Users)
            //    user.Recover(Applies);
            //foreach (var hr in Recruters)
            //    hr.Recover(Vacancies);
            //foreach (var vacancy in Vacancies)
            //    vacancy.Recover(Applies, Recruters);
            foreach (var user in Users)
                user.Applies.Clear();
            //foreach (var hr in Recruters)
            //    hr.Vacancies.Clear();
            foreach (var vac in Vacancies)
                vac.Applies.Clear();
            foreach (var apply in Applies)
                apply.Recover(Users, Vacancies);
            foreach (var vac in Vacancies)
                vac.Recover(Recruters);
        }

        
        public void CreateNewUser(string name, string surname, string email, DateTime? birthDate, string username,
            string password, string university, Degree degree, string program, DateTime? graduateDate,
            string softSkills, string hardSkills, DateTime? startExp, DateTime? stopExp, string company, string description)
        {
            CurrentUser = new User(name, surname, email, birthDate, username, password, softSkills, hardSkills, university, degree,
                program, graduateDate, company, startExp, stopExp, description);
            Users.Add(CurrentUser);
        }

        public void CreateNewRecruter(string name, string surname, DateTime? birthDate, string company, string username, string password)
        {
            CurrentHR = new Recruter(name, surname, company, birthDate == null ? new DateTime(1900, 1, 1) : (DateTime)birthDate, username, password);
            Recruters.Add(CurrentHR);
        }
        //private void PrepareDataToSave()
        //{
        //    //foreach (var user in Users)
        //    //    user.ToSave();
        //    //foreach (var hr in Recruters)
        //    //    hr.ToSave();
        //    foreach (var vacancy in Vacancies)
        //        vacancy.ToSave();
        //}
        public void SaveConfig()
        {
            //PrepareDataToSave();
            if (LocalFiles.SaveList(Users, "users.json") && LocalFiles.SaveList(Vacancies, "vacancies.json") &&
                LocalFiles.SaveList(Recruters, "recruters.json") && LocalFiles.SaveList(Applies, "applies.json"))
            {
                Console.WriteLine("Successfull saving!");
            }
            else
                Console.WriteLine("Somethenig went wrong!");
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
