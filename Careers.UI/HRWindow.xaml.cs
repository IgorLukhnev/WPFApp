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
    /// Логика взаимодействия для HRWindow.xaml
    /// </summary>
    public partial class HRWindow : Window {
        private Repository repo;
        public HRWindow()
        {
            InitializeComponent();
            addNewVacancy.Click += AddNewVacancy_Click;
        }

        public HRWindow(Repository repo)
        {
            InitializeComponent();
            this.repo = repo;
        }

        private void AddNewVacancy_Click(object sender, RoutedEventArgs e)
        {
            var createVacancy = new VacanciesEditor();
            createVacancy.Show();
        }

        private void showApplies_Click(object sender, RoutedEventArgs e)
        {
            var appliesWindow = new AppliesWindow();
            appliesWindow.Show();
        }
    }
}
