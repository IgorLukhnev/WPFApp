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
    /// Логика взаимодействия для EducationEditor.xaml
    /// </summary>
    public partial class EducationEditor : Window {
        private Repository repo;
        public EducationEditor()
        {
            InitializeComponent();
        }
        public EducationEditor(Repository repo)
        {
            InitializeComponent();
            this.repo = repo;
            userUniversity.ItemsSource = repo.Universities;
            addNewEducation.Click += AddNewEducation_Click;
        }

        private void AddNewEducation_Click(object sender, RoutedEventArgs e)
        {
            var testDegree = userDegree.SelectedIndex;
            var university = (string)userUniversity.SelectedItem;
            var specialization = userSpecialization.Text;
            var graduateDate = userGraduateDate.SelectedDate;
            if (Education.Validate(university, testDegree, specialization, graduateDate))
            {
                var degree = (Degree)Enum.GetValues(typeof(Degree)).GetValue(userDegree.SelectedIndex);
                var education = new Education
                {
                    Degree = degree,
                    University = university,
                    Program = specialization,
                    GraduateDate = (DateTime)graduateDate
                };
                repo.AddNewEducation(education);
                repo.SaveConfig();
                this.Close();
            }
            else
            {
                textIncorrectData.Text = "Введены неправильные данные";
            }
        }
    }
}
