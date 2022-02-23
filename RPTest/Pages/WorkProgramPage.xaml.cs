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
using System.Windows.Navigation;
using System.Windows.Shapes;
using _db = RPTest.Models.DBModel;

namespace RPTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkProgramPage.xaml
    /// </summary>
    public partial class WorkProgramPage : Page
    {
        private Classes.WorkProgram _workProgram;
        private Models.Discipline _discipline;
        private List<string> _specialtyCodes = new List<string>() { "09.02.06 Сетевое и системное администрирование", "09.02.07 Информационные системы и программирование", "10.02.05 Обеспечение информационной безопасности автоматизированных систем" };
        public WorkProgramPage()
        {
            InitializeComponent();
            _workProgram = new Classes.WorkProgram();
            CbCode.ItemsSource = _specialtyCodes;
            CbCompetenciesName.ItemsSource = _db.GetContext().Competencies.ToList();
            CbNameDiscipline.ItemsSource = _db.GetContext().Discipline.ToList();
        }

        private void CbCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _workProgram.Specialization = CbCode.SelectedItem.ToString();
            TbSpecialtyApprovalSheet.Text = CbCode.SelectedItem.ToString();
        }

        private void LbKnowledge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LbSkill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LbCompetencies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAddKnowledge_Click(object sender, RoutedEventArgs e)
        {
            _discipline.Knowledge.Add(new Models.Knowledge() { Discipline = _discipline, Name = TbKnowledgeName.Text });
            _db.GetContext().SaveChanges();

            UpdateLb();
        }

        private void BtnDeleteKnowledge_Click(object sender, RoutedEventArgs e)
        {
            _discipline.Knowledge.Remove(LbKnowledge.SelectedItem as Models.Knowledge);
            _db.GetContext().SaveChanges();

            UpdateLb();
        }

        private void BtnAddSkill_Click(object sender, RoutedEventArgs e)
        {
            _discipline.Skills.Add(new Models.Skills() { Name = TbSkillName.Text, Discipline = _discipline });
            _db.GetContext().SaveChanges();

            UpdateLb();
        }

        private void BtnDeleteSkill_Click(object sender, RoutedEventArgs e)
        {
            _discipline.Skills.Remove(LbSkill.SelectedItem as Models.Skills);
            _db.GetContext().SaveChanges();

            UpdateLb();
        }

        private void CbCompetenciesName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        /// <summary>
        /// Добавление компетенции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddCompetencies_Click(object sender, RoutedEventArgs e)
        {
            _discipline.Discipline_Competencies.Add(new Models.Discipline_Competencies() { Discipline = _discipline, Competencies = CbCompetenciesName.SelectedItem as Models.Competencies });
            _db.GetContext().SaveChanges();
            UpdateLb();
        }
        /// <summary>
        /// Удаление компетенции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteCompetencies_Click(object sender, RoutedEventArgs e)
        {
            _discipline.Discipline_Competencies.Remove(_discipline.Discipline_Competencies.Where(d => d.Competencies == LbCompetencies.SelectedItem as Models.Competencies).FirstOrDefault());
            _db.GetContext().SaveChanges();
            UpdateLb();
        }
        /// <summary>
        /// Добавление темы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddTopic_Click(object sender, RoutedEventArgs e)
        {
            DgThemes.ItemsSource = _workProgram.Topics;
            Classes.Topic topic = new Classes.Topic() { NumberTopic = Convert.ToInt32(TbNumberTopic.Text), TopicName = TbNameTopic.Text }; 
            _workProgram.Topics.Add(topic);

            TbNumberTopic.Text = "";
            TbNameTopic.Text = "";
        }

        private void CbNameDiscipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _discipline = (CbNameDiscipline.SelectedItem as Models.Discipline);
            _workProgram.NameDiscipline = _discipline.Name;
            UpdateLb();
        }

        private void UpdateLb()
        {
            ClearLb();
            FillLb();
        }

        private void ClearLb()
        {
            LbCompetencies.Items.Clear();
            LbKnowledge.Items.Clear();
            LbSkill.Items.Clear();
        }

        private void FillLb()
        {
            foreach (var competence in _discipline.Discipline_Competencies)
            {
                LbCompetencies.Items.Add(competence.Competencies);
            }
            foreach (var knowledge in _discipline.Knowledge)
            {
                LbKnowledge.Items.Add(knowledge);
            }
            foreach (var skill in _discipline.Skills)
            {
                LbSkill.Items.Add(skill);
            }
        }

        private void TbDateApproval_TextChanged(object sender, TextChangedEventArgs e)
        {
            _workProgram.DateApproval = TbDateApproval.Text;
        }

        private void TbNumberProtocol_TextChanged(object sender, TextChangedEventArgs e)
        {
            _workProgram.ProtocolNumber = Convert.ToInt32(TbNumberProtocol.Text);
        }

        private void TbAuthor_TextChanged(object sender, TextChangedEventArgs e)
        {
            _workProgram.TeacherName = TbAuthor.Text;
        }
    }
}
