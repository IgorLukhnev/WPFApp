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
            userUniversity.ItemsSource = LocalFiles.LoadUniversities();
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
            var degree = (Degree)Enum.GetValues(typeof(Degree)).GetValue(userDegree.SelectedIndex);
            var university = repo.Universities[userUniversity.SelectedIndex];
            var specialization = userSpecialization.Text;
            var graduateDate = userGraduateDate.SelectedDate;
            var softSkills = userSoftSkills.Text;
            var hardSkills = userHardSkills.Text;
            var startExp = userStartWorkExp.SelectedDate;
            var endExp = userEndWorkExp.SelectedDate;
            var company = userCompanyExp.Text;
            var description = userDescriptionExp.Text;
            repo.CreateNewUser(name, surname, email, birthDate, nickname, password, university, degree,
                specialization, graduateDate, softSkills, hardSkills, startExp, endExp, company, description);
            Console.WriteLine(repo.CurrentUser.Username);
            repo.SaveConfig();
            var userWindow = new FirstUserWindow(repo);
            userWindow.Show();
            this.Close();
        }
    }
}
