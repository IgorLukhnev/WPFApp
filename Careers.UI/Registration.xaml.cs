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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window {
        private Repository repo;
        public Registration()
        {
            InitializeComponent();
        }
        public Registration(Repository repo)
        {
            this.repo = repo;
            InitializeComponent();
            buttonRegistration.Click += ButtonRegistration_Click;
            userUniversity.ItemsSource = repo.Universities;
            buttonEmployerRegistration.Click += ButtonEmployerRegistration_Click;
        }

        private void ButtonEmployerRegistration_Click(object sender, RoutedEventArgs e)
        {
            var name = employerName.Text;
            var surname = employerSurname.Text;
            var username = employerNickname.Text;
            var password = employerPassword.Password;
            var company = employerCompany.Text;
            var birthDate = employerBirthDate.SelectedDate;
            repo.CreateNewRecruter(name, surname, birthDate, company, username, password);
            repo.SaveConfig();
            var recruterWindow = new HRWindow(repo);
            recruterWindow.Show();
            this.Close();
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            var name = userName.Text;
            var surname = userSurname.Text;
            var birthDate = userBirthdate.SelectedDate;
            var email = userEmail.Text;
            var nickname = userNickname.Text;
            var password = userPassword.Password;
            var prefered = userPreferedJob.SelectedItems;
            //var degree = (Degree)Enum.GetValues(typeof(Degree)).GetValue(userDegree.SelectedIndex);
            //var university = (string)userUniversity.SelectedItem;
            //var specialization = userSpecialization.Text;
            //var graduateDate = userGraduateDate.SelectedDate;
            var testDegree = userDegree.SelectedIndex;
            var university = (string)userUniversity.SelectedItem;
            var specialization = userSpecialization.Text;
            var graduateDate = userGraduateDate.SelectedDate;
            var softSkills = userSoftSkills.Text;
            var hardSkills = userHardSkills.Text;
            var startExp = userStartWorkExp.SelectedDate;
            var endExp = userEndWorkExp.SelectedDate;
            var company = userCompanyExp.Text;
            var description = userDescriptionExp.Text;
            if (WorkExperience.Validate(startExp, company, endExp, description) && 
                Education.Validate(university, testDegree, specialization, graduateDate))
            {
                var degree = (Degree)Enum.GetValues(typeof(Degree)).GetValue(userDegree.SelectedIndex);
                repo.CreateNewUser(name, surname, email, birthDate, nickname, password, university, degree,
                specialization, graduateDate, softSkills, hardSkills, startExp, endExp, company, description);
                Console.WriteLine(repo.CurrentUser.Username);
                repo.SaveConfig();
                var userWindow = new FirstUserWindow(repo);
                userWindow.Show();
                this.Close();
            }
            else
            {
                textIncorrectData.Text = "Введены неправильные данные";
            }
        }
    }
}
