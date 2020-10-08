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
        public UserInfoWiindow()
        {
            InitializeComponent();
            editEduc.Click += editEduc_Click;
            editWorkExp.Click += EditWorkExp_Click;
            
        }

        private void EditWorkExp_Click(object sender, RoutedEventArgs e)
        {
            var experienceEdit = new ExperienceEditor();
            experienceEdit.Show();
        }

        private void editEduc_Click(object sender, RoutedEventArgs e)
        {
            var educationEdit = new EducationEditor();
            educationEdit.Show();
        }
    }
}
