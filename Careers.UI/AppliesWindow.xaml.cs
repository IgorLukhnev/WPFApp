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
        public AppliesWindow()
        {
            InitializeComponent();
            
        }

        private void viewExp_Click(object sender, RoutedEventArgs e)
        {
            var applyUserExperience = new ApplyUserExperience();
            applyUserExperience.Show();
        }
    }
}
