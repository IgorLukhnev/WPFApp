using Careers.Core;
using Careers.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Careers.UI {
    /// <summary>
    /// Логика взаимодействия для VacanciesEditor.xaml
    /// </summary>
    public partial class VacanciesEditor : Window {
        private Repository repo;
        public VacanciesEditor()
        {
            InitializeComponent();
        }
        //private decimal ParseSalary()
        //{
        //    decimal result = 0;
        //    while (true)
        //        if  (decimal.TryParse(descriptionOfVacancy.Text, out result)) break;

        //    return result;
        //}
        public VacanciesEditor(Repository repo)
        {
            this.repo = repo;
            InitializeComponent();

            addNewVacancy.Click += AddNewVacancy_Click;
            
        }

        private void AddNewVacancy_Click(object sender, RoutedEventArgs e)
        {
            var title = nameOfVacancy.Text;
            var description = descriptionOfVacancy.Text;
            decimal salary = 0;
            if (decimal.TryParse(salaryOfVacancy.Text, out salary))
            {
                var vacancy = new Vacancy(title, description, salary, repo.CurrentHR, repo.CurrentHR.Id);
                //vacancy.Recover(repo.Applies, repo.Recruters);
                repo.AddNewVacancy(vacancy);
                
                repo.SaveConfig();
                this.Close();
            }
            else
            {
                incorectSalaryType.Text = "Incorrect salary!";
            }
        }
    }
}
