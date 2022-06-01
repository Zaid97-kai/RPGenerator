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
    /// Логика взаимодействия для StateWindow.xaml
    /// </summary>
    public partial class StateWindow : System.Windows.Window
    {
        public StateWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            MainFrame.Navigate(new Pages.WorkProgramPage());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }

        private void MIAddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.AddDisciplinePage());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.WorkProgramPage());
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.DataPage());
        }
    }
}
