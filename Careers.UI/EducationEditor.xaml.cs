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
        public EducationEditor()
        {
            InitializeComponent();
            addNewEducation.Click += AddNewEducation_Click;
        }

        private void AddNewEducation_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
