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
    /// Логика взаимодействия для ExperienceEditor.xaml
    /// </summary>
    public partial class ExperienceEditor : Window {
        private readonly Repository repo;
        public ExperienceEditor()
        {
            InitializeComponent();
        }
        public ExperienceEditor(Repository repo)
        {
            InitializeComponent();
            this.repo = repo;
            if (repo.CurrentExperience != null)
            {
                userStartWorkExp.SelectedDate = repo.CurrentExperience.StartDate;
                if (repo.CurrentExperience.EndDate.HasValue) userEndWorkExp.SelectedDate = repo.CurrentExperience.EndDate;
                if (!string.IsNullOrEmpty(repo.CurrentExperience.Company)) userCompanyExp.Text = repo.CurrentExperience.Company;
                if (!string.IsNullOrEmpty(repo.CurrentExperience.Description)) userDescriptionExp.Text = repo.CurrentExperience.Description;            
                        }
            addExperience.Click += AddExperience_Click;
        }

        private void AddExperience_Click(object sender, RoutedEventArgs e)
        {
            var startExp = userStartWorkExp.SelectedDate;
            var endExp = userEndWorkExp.SelectedDate;
            var company = userCompanyExp.Text;
            var description = userDescriptionExp.Text;
            if (WorkExperience.Validate(startExp, company, endExp, description))
            {
                if (repo.CurrentExperience == null)
                {
                    var experience = new WorkExperience { Company = company, Description = description, EndDate = endExp, StartDate = (DateTime)startExp };
                    repo.AddNewExperience(experience);
                }
                else
                {
                    repo.UpdateExperience((DateTime)startExp, company, endExp, description);
                    repo.CurrentExperience = null;
                } 
                repo.SaveConfig();
                this.Close();
            }
            else
            {
                textIncorrectData.Text = "Введены неправильные данные";
            }
        }
    }
}
