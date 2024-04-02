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

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();
            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле введено некорректно";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                PassBox.ToolTip = "Это поле введено некорректно";
                PassBox.Background = Brushes.DarkRed;

            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;

                User authuser = null;
                using(ApplicationContext db = new ApplicationContext())
                {
                    authuser = db.Users.Where(b => b.Login == login && b.Password == pass).FirstOrDefault();
                }

                if (authuser != null)
                {
                    MessageBox.Show("Все хорошо");
                    UserPageWingow userPageWingow = new UserPageWingow();
                    userPageWingow.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Логин или пароль неверны");
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
