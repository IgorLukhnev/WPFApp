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
    /// Логика взаимодействия для FirstWindow.xaml
    /// </summary>
    public partial class FirstUserWindow : Window {
        private readonly Repository repo;
        public FirstUserWindow()
        {
            InitializeComponent();
        }

        public FirstUserWindow(Repository repo)
        {
            this.repo = repo;
            InitializeComponent();
            textBlockGreeting.Text = $"{repo.Vacancies.Count} доступных вакансий, {repo.CurrentUser.Name}";
            userInfo.Click += UserInfo_Click;
            userApplies.Click += UserApplies_Click;
            checkBoxSpecializeVacancies.Checked += CheckBoxSpecializeVacancies_Checked;
            listBoxVacancies.ItemsSource = repo.Vacancies;
        }
        private void UserApplies_Click(object sender, RoutedEventArgs e)
        {
            var userApplies = new UserAppliesInfo(repo.CurrentUser);
            userApplies.ShowDialog();
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            var vacancy = (Vacancy)listBoxVacancies.SelectedItem;
            if (vacancy != null)
            {
                var apply = new Apply(repo.CurrentUser, vacancy, repo.CurrentUser.Id, vacancy.Id);
                repo.AddNewApply(apply);
            }
            else
            {
                nothingClicked.Text = "Нужно выбрать вакансию сначала";
            }
        }

        private void CheckBoxSpecializeVacancies_Checked(object sender, RoutedEventArgs e)
        {
            listBoxVacancies.ItemsSource = null;
            listBoxVacancies.ItemsSource = repo.Vacancies.FindAll(v => v.Applies.FindAll(a => a.User == repo.CurrentUser).Count == 0);
        }

        private void UserInfo_Click(object sender, RoutedEventArgs e)
        {
            var userInfoWindow = new UserInfoWiindow(repo);
            userInfoWindow.Show();
        }

        private void CheckBoxSpecializeVacancies_Unchecked(object sender, RoutedEventArgs e)
        {
            listBoxVacancies.ItemsSource = null;
            listBoxVacancies.ItemsSource = repo.Vacancies;
        }
    }
}
