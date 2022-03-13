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
        private BinaryFormatter _formatter = new BinaryFormatter();
        private List<string> _specialtyCodes = new List<string>() { "09.02.06 Сетевое и системное администрирование", "09.02.07 Информационные системы и программирование", "10.02.05 Обеспечение информационной безопасности автоматизированных систем" };
        /// <summary>
        /// Конструктор класса WorkProgramPage
        /// </summary>
        public WorkProgramPage()
        {
            InitializeComponent();
            _workProgram = new Classes.WorkProgram();
            CbCode.ItemsSource = _specialtyCodes;
            CbNameDiscipline.ItemsSource = _db.GetContext().Discipline.ToList();
        }
        /// <summary>
        /// Выбор кода специальности из выпадающего списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _workProgram.Specialization = CbCode.SelectedItem.ToString();
            TbSpecialtyApprovalSheet.Text = CbCode.SelectedItem.ToString();
        }
        /// <summary>
        /// Выбор знания из списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbKnowledge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            return;
        }
        /// <summary>
        /// Выбор умения из списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbSkill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            return;
        }
        /// <summary>
        /// Выбор компетенции из списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbCompetencies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            return;
        }
        /// <summary>
        /// Добавление знания в дисциплину
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddKnowledge_Click(object sender, RoutedEventArgs e)
        {
            _discipline.Knowledge.Add(new Models.Knowledge() { Discipline = _discipline, Name = TbKnowledgeName.Text });
            _db.GetContext().SaveChanges();

            UpdateLb();
        }
        /// <summary>
        /// Удаление знания из дисциплины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteKnowledge_Click(object sender, RoutedEventArgs e)
        {
            _discipline.Knowledge.Remove(LbKnowledge.SelectedItem as Models.Knowledge);
            _db.GetContext().SaveChanges();

            UpdateLb();
        }
        /// <summary>
        /// Добавление умения в дисциплину
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddSkill_Click(object sender, RoutedEventArgs e)
        {
            _discipline.Skills.Add(new Models.Skills() { Name = TbSkillName.Text, Discipline = _discipline });
            _db.GetContext().SaveChanges();

            UpdateLb();
        }
        /// <summary>
        /// Удаление знания из дисциплины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteSkill_Click(object sender, RoutedEventArgs e)
        {
            _discipline.Skills.Remove(LbSkill.SelectedItem as Models.Skills);
            _db.GetContext().SaveChanges();

            UpdateLb();
        }
        /// <summary>
        /// Выбор компетенции из выпадающего списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbCompetenciesName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            return;
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
            Classes.Topic topic = new Classes.Topic() { NumberTopic = Convert.ToInt32(TbNumberTopic.Text), TopicName = TbNameTopic.Text }; 
            _workProgram.Topics.Add(topic);

            DgThemes.ItemsSource = _workProgram.Topics;
            DgThemes.Items.Refresh();
            TbNumberTopic.Text = "";
            TbNameTopic.Text = "";
        }
        /// <summary>
        /// Выбор дисциплины из выпадающего списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbNameDiscipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _discipline = (CbNameDiscipline.SelectedItem as Models.Discipline);
            _workProgram.NameDiscipline = _discipline.Name;
            UpdateLb();
        }
        /// <summary>
        /// Обновление списка знаний, умений и компетенций
        /// </summary>
        private void UpdateLb()
        {
            ClearLb();
            FillLb();
        }
        /// <summary>
        /// Очистка списка знаний, умений и компетенций
        /// </summary>
        private void ClearLb()
        {
            LbCompetencies.Items.Clear();
            LbKnowledge.Items.Clear();
            LbSkill.Items.Clear();
        }
        /// <summary>
        /// Заполнение списка знаний, умений и компетенций
        /// </summary>
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
        /// <summary>
        /// Инициализация поля даты утверждения рабочей программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbDateApproval_TextChanged(object sender, TextChangedEventArgs e)
        {
            _workProgram.DateApproval = TbDateApproval.Text;
        }
        /// <summary>
        /// Инициализация поля номера протокола
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbNumberProtocol_TextChanged(object sender, TextChangedEventArgs e)
        {
            _workProgram.ProtocolNumber = Convert.ToInt32(TbNumberProtocol.Text);
        }
        /// <summary>
        /// Инициализация поля автора рабочей программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbAuthor_TextChanged(object sender, TextChangedEventArgs e)
        {
            _workProgram.TeacherName = TbAuthor.Text;
        }
        /// <summary>
        /// Обработчик нажатия на клавишу Ctrl+S
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.S)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName + ".dat", FileMode.OpenOrCreate))
                    {
                        _formatter.Serialize(fs, _discipline);
                    }
                }
            }
        }
    }
}
