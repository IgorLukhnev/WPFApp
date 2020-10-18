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
        private readonly Repository repo;
        public AppliesWindow()
        {
            InitializeComponent();
        }

        public AppliesWindow(Repository repo)
        {
            this.repo = repo;
            InitializeComponent();
            repo.OnAppliesChanged += Repo_OnAppliesChanged;
            titleForAppliesList.Text = $"Отклики на {repo.CurrentVacancy.Title}";
            AppliesList.ItemsSource = repo.CurrentVacancy.Applies;
        }

        private void Repo_OnAppliesChanged()
        {
            AppliesList.ItemsSource = null;
            AppliesList.ItemsSource = repo.CurrentVacancy.Applies;
        }

        private void ViewExp_Click(object sender, RoutedEventArgs e)
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

        private void ReturnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IsConfirm_Click(object sender, RoutedEventArgs e)
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

        private void IsDenied_Click(object sender, RoutedEventArgs e)
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
