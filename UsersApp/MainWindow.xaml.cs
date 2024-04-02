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
using System.Windows.Media.Animation;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();


        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();
            string pass2 = PassBox2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();
            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле введено некорректно";
                textBoxLogin.Background = Brushes.DarkRed;
            } else if (pass.Length < 5)
            {
                PassBox.ToolTip = "Это поле введено некорректно";
                PassBox.Background = Brushes.DarkRed;

            } else if (pass != pass2)
            {
                PassBox2.ToolTip = "Пароли не совпадают";
                PassBox2.Background = Brushes.DarkRed;

            } else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Это поле введено некорректно";
                textBoxEmail.Background = Brushes.DarkRed;

            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
                PassBox2.ToolTip = "";
                PassBox2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;
                MessageBox.Show("Все хорошо");
                User User = new User(login, pass, email);

                db.Users.Add(User);
                db.SaveChanges();
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();

            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
