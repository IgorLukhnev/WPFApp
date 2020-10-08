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
    /// Логика взаимодействия для ExperienceEditor.xaml
    /// </summary>
    public partial class ExperienceEditor : Window {
        public ExperienceEditor()
        {
            InitializeComponent();
            addExperience.Click += AddExperience_Click;
        }

        private void AddExperience_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
