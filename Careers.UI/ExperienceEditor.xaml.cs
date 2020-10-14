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
        private Repository repo;
        public ExperienceEditor()
        {
            InitializeComponent();
        }
        public ExperienceEditor(Repository repo)
        {
            InitializeComponent();
            this.repo = repo;
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
                var experience = new WorkExperience { Company = company, Description = description, EndDate = endExp, StartDate = (DateTime)startExp };
                repo.AddNewExperience(experience);
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
