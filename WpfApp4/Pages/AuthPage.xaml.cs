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

namespace WpfApp4.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        User user = new User();
        public AuthPage()
        {
            InitializeComponent();
        }
        public bool Auth(string login, string password)
        {
            if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            else
            {
                var busy = Core.Context.User.FirstOrDefault(x => x.Login == login);
                if (busy == null)
                {
                    return false;
                }
                else
                {
                    if (busy.Password == password)
                    {
                        user = busy;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
         
            if (Auth(Login.Text, Password.Password))
            {
                MessageBox.Show("Добро пожаловать!");
                NavigationService.Navigate(new CatalogPage(user));
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void EnterReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrPage());
        }

        private void EnterGosti_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatalogPage());
        }
    }
}
