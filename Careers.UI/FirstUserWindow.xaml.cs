using Careers.Core;
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
        public FirstUserWindow()
        {
            InitializeComponent();
        }

        public FirstUserWindow(Repository repo)
        {
            textBlockGreeting.Text = $"There are {repo.Vacancies.Count} vacancies to apply, {repo.CurrentUser.Name}";
            userInfo.Click += UserInfo_Click;
            userApplies.Click += UserApplies_Click;
            checkBoxSpecializeVacancies.Checked += CheckBoxSpecializeVacancies_Checked;
        }
        private void UserApplies_Click(object sender, RoutedEventArgs e)
        {
            var userApplies = new UserAppliesInfo();
            userApplies.Show();
        }

        private void CheckBoxSpecializeVacancies_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void UserInfo_Click(object sender, RoutedEventArgs e)
        {
            var userInfoWindow = new UserInfoWiindow();
            userInfoWindow.Show();
        }
    }
}
