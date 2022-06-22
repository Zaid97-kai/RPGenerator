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
    /// Логика взаимодействия для AddSkillWindow.xaml
    /// </summary>
    public partial class AddSkillWindow : System.Windows.Window
    {
        public AddSkillWindow()
        {
            InitializeComponent();
            RefreshDiscipline();
        }
        private void RefreshDiscipline()
        {

            CbSkillDiscipline.Items.Clear();
            foreach (Models.Discipline u in _db.GetContext().Discipline)
            {

                CbSkillDiscipline.Items.Add(u);
            }
        }

        private void BtnAddSkill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if( RbSkillExp.IsChecked == true || RbSkillSkill.IsChecked == true || RbSkillKnoweledge.IsChecked == true)
                {
                    if (RbSkillExp.IsChecked == true)
                    {
                        ExpPractice expPractice = new ExpPractice()
                        {
                            Name = TbSkillName.Text,
                            Id_Discipline = ((Discipline)CbSkillDiscipline.SelectedItem).Id
                        };
                        _db.GetContext().ExpPractice.Add(expPractice);
                    }
                    if (RbSkillSkill.IsChecked == true)
                    {
                        Skills skills = new Skills()
                        {
                            Name = TbSkillName.Text,
                            Id_Discipline = ((Discipline)CbSkillDiscipline.SelectedItem).Id
                        };
                        _db.GetContext().Skills.Add(skills);
                    }
                    if (RbSkillKnoweledge.IsChecked == true)
                    {
                        Knowledge knowledge = new Knowledge()
                        {
                            Name = TbSkillName.Text,
                            Id_Discipline = ((Discipline)CbSkillDiscipline.SelectedItem).Id
                        };
                        _db.GetContext().Knowledge.Add(knowledge);
                    }
                    _db.GetContext().SaveChanges();
                    MessageBox.Show("Успешно добавлено!");
                    TbSkillName.Text = "";
                    CbSkillDiscipline.SelectedItem = null;
                    RbSkillExp.IsChecked = false;
                    RbSkillKnoweledge.IsChecked = false;
                    RbSkillSkill.IsChecked = false;
                }
                else
                {
                    MessageBox.Show("Выберите тип занятия");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }
    }
}
