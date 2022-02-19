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
        private Models.DBModel _db;
        public RegistrationWindow()
        {
            InitializeComponent();
            _db = new Models.DBModel();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            OpenAuthorizationWindow();
        }

        private void OpenAuthorizationWindow()
        {
            Window.AuthorizationWindow authorizationWindow = new Window.AuthorizationWindow();
            authorizationWindow.ShowDialog();
            this.Hide();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            _db.Users.Add(new Models.Users() { Log = TxtLog.Text, Pass = TxtPassword.Text, Role = "User", Email = TxtEmail.Text });
            _db.SaveChanges();
            OpenAuthorizationWindow();
        }
    }
}
