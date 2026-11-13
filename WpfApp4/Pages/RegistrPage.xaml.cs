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
    /// Логика взаимодействия для RegistrPage.xaml
    /// </summary>
    public partial class RegistrPage : Page
    {
        User user = new User();
        public RegistrPage()
        {
            InitializeComponent();
        }
        public bool Registration(string fio, string login, string password, string proverka)
        {
            if ((String.IsNullOrWhiteSpace(login)) || (String.IsNullOrWhiteSpace(password)) || (String.IsNullOrWhiteSpace(fio)) || (String.IsNullOrWhiteSpace(proverka)))
            {
                MessageBox.Show("Пожалуйста заполните все поля!");
                return false;
                
            }
            if (password != proverka)
            {
                MessageBox.Show("Пароли не совпадают!");
                return false;
            }

            var busy = Core.Context.User.FirstOrDefault(x => x.Login == login);
            if (busy != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует!");
                return false;
            }
            else {
                User newUser = new User()
                {
                    Login = login, Password = password, FIO = fio};
                try
                {
                    Core.Context.User.Add(newUser);
                    Core.Context.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно!");
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении! " + ex.Message);
                    return false;
                }
            }
        }
    }
}
