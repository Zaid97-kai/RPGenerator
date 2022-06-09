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
    /// Логика взаимодействия для AddPMWindow.xaml
    /// </summary>
    public partial class AddPMWindow : System.Windows.Window
    {
        public AddPMWindow()
        {
            InitializeComponent();
            RefreshSpecialty();
        }
        private void RefreshSpecialty()
        {
            CbPMSpecialty.Items.Clear();
            foreach (Specialty u in _db.GetContext().Specialty)
            {
                CbPMSpecialty.Items.Add(u);
            }
        }

        private void BtnAddPM_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Proffessional_Module proffessional_Module = new Proffessional_Module()
                {
                    Code = TbPMCode.Text,
                    Name = TbPMName.Text,
                    Id_Specialty = ((Specialty)CbPMSpecialty.SelectedItem).Id
                };
                _db.GetContext().Proffessional_Module.Add(proffessional_Module);
                _db.GetContext().SaveChanges();
                MessageBox.Show("Вы успешно добавили профессиональный модуль!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }
    }
}
