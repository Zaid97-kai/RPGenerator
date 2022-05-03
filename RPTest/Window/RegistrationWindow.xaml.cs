using RPTest.Classes;
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

namespace RPTest.Window
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : System.Windows.Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            OpenAuthorizationWindow();
        }

        private void OpenAuthorizationWindow()
        {
            Window.AuthorizationWindow authorizationWindow = new Window.AuthorizationWindow();
            authorizationWindow.Show();
            this.Hide();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Auth auth = new Auth();
                string flag = auth.Registration(TxtLog.Text, TxtPassword.Text, TxtEmail.Text);
                if (flag == "true")
                {
                    OpenAuthorizationWindow();
                }
                if (flag == "false")
                {
                    MessageBox.Show("Пользователь уже существует!");
                }
                if (flag == "empty")
                {
                    MessageBox.Show("Вы не ввели данные");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
