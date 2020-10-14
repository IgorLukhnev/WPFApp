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
    /// Логика взаимодействия для HRWindow.xaml
    /// </summary>
    public partial class HRWindow : Window {
        private Repository repo;
        public HRWindow()
        {
            InitializeComponent();
        }

        public HRWindow(Repository repo)
        {
            InitializeComponent();
            this.repo = repo;
            //foreach (var vac in repo.CurrentHR.Vacancies)
            //    vac.Recover(repo.Applies, repo.Recruters);
            textBlockGreetingHR.Text = $"Привет, {repo.CurrentHR.Name}, выложенные вами вакансии";
            repo.Recover();
            listBoxVacancies.ItemsSource = repo.CurrentHR.Vacancies;
            addNewVacancy.Click += AddNewVacancy_Click;
        }

        private void AddNewVacancy_Click(object sender, RoutedEventArgs e)
        {
            repo.OnVacanciesChanged += Repo_OnVacanciesChanged;
            var createVacancy = new VacanciesEditor(repo);
            createVacancy.Show();
        }

        private void Repo_OnVacanciesChanged()
        {
            listBoxVacancies.ItemsSource = null;
            listBoxVacancies.ItemsSource = repo.CurrentHR.Vacancies;
        }

        private void showApplies_Click(object sender, RoutedEventArgs e)
        {
            var CurrentVacancy = listBoxVacancies.SelectedItem;
            if (CurrentVacancy != null)
            {
                repo.CurrentVacancy = (Vacancy)CurrentVacancy;
                var appliesWindow = new AppliesWindow(repo);
                appliesWindow.Show();
            }
            else
            {
                nothingClicked.Text = "Click on the vacancy before";
            }
        }

        private void checkBoxAppliedVacancies_Checked(object sender, RoutedEventArgs e)
        {
            listBoxVacancies.ItemsSource = null;
            listBoxVacancies.ItemsSource = (List<Vacancy>)repo.CurrentHR.Vacancies.FindAll(v => v.Applies.Count > 0);
        }

        private void checkBoxAppliedVacancies_Unchecked(object sender, RoutedEventArgs e)
        {
            listBoxVacancies.ItemsSource = null;
            listBoxVacancies.ItemsSource = repo.CurrentHR.Vacancies;
        }
    }
}
