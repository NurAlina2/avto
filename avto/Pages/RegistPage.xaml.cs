using avto.Components;
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

namespace avto.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistPage.xaml
    /// </summary>
    public partial class RegistPage : Page
    {
        public RegistPage()
        {
            InitializeComponent();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Password.Trim();
            if (login.Length > 0 && password.Length > 0)
            {
                DbConnect.db.User.Add(new User
                {
                    Login = login,
                    Password = password
                });
                DbConnect.db.SaveChanges();
                MessageBox.Show("Вы зарегистрированы!");

            }
            else
            {
                MessageBox.Show("Пусто! Заполните поля.");
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
