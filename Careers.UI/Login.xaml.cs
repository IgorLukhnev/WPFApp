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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window {
        private Repository repo;
        public Login()
        {
            InitializeComponent();
        }
        public Login(Repository repo)
        {
            InitializeComponent();
            this.repo = repo;
            buttonLogin.Click += ButtonLogin_Click;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = userLogin.Text;
            var password = userPass.Password;
            if (repo.AuthorizeUser(login, password))
            {
                var userWindow = new FirstUserWindow(repo);
                userWindow.Show();
                this.Close();
            }
            else if (repo.AuthorizeHR(login, password))
            {
                var recruterWindow = new HRWindow();
                recruterWindow.Show();
                this.Close();
            }
            else
            {
                textIncorrectData.Text = "Incorrect username or password!";
            }
        }
    }
}
