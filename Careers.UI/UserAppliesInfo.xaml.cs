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
    /// Логика взаимодействия для UserAppliesInfo.xaml
    /// </summary>
    public partial class UserAppliesInfo : Window {
        public UserAppliesInfo()
        {
            InitializeComponent();
        }

        public UserAppliesInfo(User user)
        {
            InitializeComponent();
            listBoxUserApplies.ItemsSource = user.Applies;
            backToUser.Click += BackToUser_Click;
        }

        private void BackToUser_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
