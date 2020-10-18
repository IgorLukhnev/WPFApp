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
    /// Логика взаимодействия для ApplyUserExperience.xaml
    /// </summary>
    public partial class ApplyUserExperience : Window {
        public ApplyUserExperience() 
        {
            InitializeComponent();
        }
        public ApplyUserExperience(Repository repo)
        {
            InitializeComponent();
            experienceOfUser.Text = $"Опыт работы пользователя {repo.CurrentApply.User.Name}";
            ExperienceList.ItemsSource = repo.CurrentApply.User.WorkExperiences;
        }
    }
}
