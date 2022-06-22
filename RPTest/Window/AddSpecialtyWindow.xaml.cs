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
    /// Логика взаимодействия для AddSpecialtyWindow.xaml
    /// </summary>
    public partial class AddSpecialtyWindow : System.Windows.Window
    {
        public AddSpecialtyWindow()
        {
            InitializeComponent();
        }

        private void BtnAddSpecialty_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Specialty specialty = new Specialty()
                {
                    Name = TbSpecialtyName.Text,
                    Code = TbSpecialtyCode.Text,
                    Qualification = TbSpecialtyQualification.Text,

                };
                _db.GetContext().Specialty.Add(specialty);
                _db.GetContext().SaveChanges();
                MessageBox.Show("Вы успешно добавили компетенцию!");
                TbSpecialtyName.Text = "";
                TbSpecialtyCode.Text = "";
                TbSpecialtyQualification.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }
    }
}
