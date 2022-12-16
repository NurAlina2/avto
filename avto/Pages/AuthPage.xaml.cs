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
using System.Data.Entity.Migrations.Model;
using System.Data.Entity;

namespace avto.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();

        }
        

       

        private void RegistBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Nav("Регистрация", new RegistPage()));

        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Password.Trim();
            if (login.Length == 0 && password.Length == 0)
            {
                MessageBox.Show("Пусто. Пожалуйста, заполните поля!");
            }
            else
            {
                Navigation.AuthUser = DbConnect.db.User.ToList().Find(x => x.Login == login && x.Password == password);
                if (Navigation.AuthUser == null)
                {
                    MessageBox.Show("Такого пользователя не существует!");
                }
                else
                {
                    Navigation.isAuth = true;
                    Navigation.NextPage(new Nav("Кинотеатр", new PageMenu()));
                }
            }

        }
    }
    }

