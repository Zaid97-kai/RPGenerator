using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        private string FilePath;
        private Classes.WorkProgram _workProgram;
        private BinaryFormatter _formatter = new BinaryFormatter();
        /// <summary>
        /// Конструктор класса StateWindow
        /// </summary>
        public StateWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        /// <summary>
        /// Генерация содержимого фрейма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            return;
        }
        /// <summary>
        /// Добавление дисциплины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MIAddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.AddDisciplinePage());
        }
        /// <summary>
        /// Закрытие программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        /// <summary>
        /// Создание рабочей программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.WorkProgramPage());
        }
        /// <summary>
        /// Редактирование рабочей программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditProgramItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
            }
            if (FilePath != null)
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Open))
                {
                    _workProgram = _formatter.Deserialize(fs) as Classes.WorkProgram;
                }
            }
            MainFrame.Navigate(new Pages.WorkProgramPage(_workProgram));
        }
    }
}
