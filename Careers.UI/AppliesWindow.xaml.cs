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
    /// Логика взаимодействия для AppliesWindow.xaml
    /// </summary>
    public partial class AppliesWindow : Window {
        private Repository repo;
        public AppliesWindow()
        {
            InitializeComponent();
        }

        public AppliesWindow(Repository repo)
        {
            this.repo = repo;
            InitializeComponent();
            titleForAppliesList.Text = $"Отклики на {repo.CurrentVacancy.Title}";
            AppliesList.ItemsSource = repo.CurrentVacancy.Applies;
        }

        private void viewExp_Click(object sender, RoutedEventArgs e)
        {
            var currentApply = AppliesList.SelectedItem;
            if (currentApply != null)
            {
                repo.CurrentApply = (Apply)currentApply;
                var applyUserExperience = new ApplyUserExperience(repo);
                applyUserExperience.Show();
            }
            else
            {
                nothingClicked.Text = "Нажмите на соответствующий отклик";
            }
        }

        private void returnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void isConfirm_Click(object sender, RoutedEventArgs e)
        {
            var currentApply = AppliesList.SelectedItem;
            if (currentApply != null)
            {
                repo.CurrentApply = (Apply)currentApply;
                repo.CurrentApply.Status = ApplyStatus.Accepted;
                repo.SaveConfig();
            }
            else
            {
                nothingClicked.Text = "Нажмите на соответствующий отклик";
            }
        }

        private void isDenied_Click(object sender, RoutedEventArgs e)
        {
            var currentApply = AppliesList.SelectedItem;
            if (currentApply != null)
            {
                repo.CurrentApply = (Apply)currentApply;
                repo.CurrentApply.Status = ApplyStatus.Denied;
                repo.SaveConfig();
            }
            else
            {
                nothingClicked.Text = "Нажмите на соответствующий отклик";
            }
        }
    }
}
