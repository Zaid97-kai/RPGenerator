using RPTest.Models;
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
using _db = RPTest.Models.DBModel;

namespace RPTest.Window
{
    /// <summary>
    /// Логика взаимодействия для AddTopicWindow.xaml
    /// </summary>
    public partial class AddTopicWindow : System.Windows.Window
    {
        public AddTopicWindow()
        {
            InitializeComponent();
            RefreshCbDiscipline();
        }

        private void RefreshCbDiscipline()
        {
            CbChapterDiscipline.Items.Clear();
            foreach (Discipline u in _db.GetContext().Discipline)
            {
                CbChapterDiscipline.Items.Add(u);
            }
        }
        private void BtnAddTopic_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Chapter chapter = new Chapter()
                {
                    Name = TbChapterName.Text,
                    Id_Discipline = ((Discipline)CbChapterDiscipline.SelectedItem).Id
                };
                _db.GetContext().Chapter.Add(chapter);
                _db.GetContext().SaveChanges();
                MessageBox.Show("Вы успешно добавили тему!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }
    }
}
