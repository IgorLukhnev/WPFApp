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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Careers.UI {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private Repository repo;
        public MainWindow()
        {
            InitializeComponent();
            buttonRegist.Click += ButtonRegister_Click;
            buttonLogin.Click += ButtonLogin_Click;
            var toWork = new Repository();
            repo = toWork;
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var registration = new Registration(repo);
            registration.Show();
            this.Close();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = new Login(repo);
            login.Show();
            this.Close();
        }

    }
}
