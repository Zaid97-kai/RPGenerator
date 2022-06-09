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
    /// Логика взаимодействия для AddDIsciplineWindow.xaml
    /// </summary>
    public partial class AddDIsciplineWindow : System.Windows.Window
    {
        public AddDIsciplineWindow()
        {
            InitializeComponent();
        }

        private void BtnAddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Discipline discipline = new Discipline()
                {
                    Name = TbDisName.Text
                };
                _db.GetContext().Discipline.Add(discipline);
                _db.GetContext().SaveChanges();
                MessageBox.Show("Вы успешно добавили дисциплину!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }
    }
}
