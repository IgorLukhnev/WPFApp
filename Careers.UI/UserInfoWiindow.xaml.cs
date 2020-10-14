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
    /// Логика взаимодействия для UserInfoWiindow.xaml
    /// </summary>
    public partial class UserInfoWiindow : Window {
        private Repository repo;
        public UserInfoWiindow()
        {
            InitializeComponent();
        }

        public UserInfoWiindow(Repository repo)
        {
            this.repo = repo;
            InitializeComponent();
            listBoxExp.ItemsSource = repo.CurrentUser.WorkExperiences;
            listBoxEdu.ItemsSource = repo.CurrentUser.Educations;
            editEduc.Click += editEduc_Click;
            editWorkExp.Click += EditWorkExp_Click;
        }

        private void EditWorkExp_Click(object sender, RoutedEventArgs e)
        {
            var experienceEdit = new ExperienceEditor(repo);
            repo.OnExperienceChanged += Repo_OnExperienceChanged;
            experienceEdit.Show();
        }

        private void Repo_OnExperienceChanged()
        {
            listBoxExp.ItemsSource = null;
            listBoxExp.ItemsSource = repo.CurrentUser.WorkExperiences;
        }

        private void editEduc_Click(object sender, RoutedEventArgs e)
        {
            var educationEdit = new EducationEditor(repo);
            repo.OnEducationChanged += Repo_OnEducationChanged;
            educationEdit.Show();
        }

        private void Repo_OnEducationChanged()
        {
            listBoxEdu.ItemsSource = null;
            listBoxEdu.ItemsSource = repo.CurrentUser.Educations;
        }
    }
}
