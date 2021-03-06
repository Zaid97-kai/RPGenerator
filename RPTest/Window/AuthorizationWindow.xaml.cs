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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : System.Windows.Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }
        
        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            Window.StateWindow stateWindow = new Window.StateWindow();
            stateWindow.Show();
            this.Hide();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Window.RegistrationWindow registrationWindow = new Window.RegistrationWindow();
            registrationWindow.ShowDialog();
            this.Hide();
        }
    }
}
