using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для AddDisciplinePage.xaml
    /// </summary>
    public partial class AddDisciplinePage : Page
    {
        private Classes.TemporaryDiscipline _temporaryDiscipline = new Classes.TemporaryDiscipline();
        private Classes.TemporaryDisciplineText _temporaryDisciplineText;
        private Models.Competencies _competencies;
        private Models.Knowledge _knowledge;
        private Models.Skills _skills;
        private BinaryFormatter _formatter = new BinaryFormatter();
        private List<string> _assessmentForms = new List<string> { "Экзамен", "Зачет", "Дифференцированный зачет", "Курсовая работа", "Другая форма контроля" };
        private string FilePath = "";
        /// <summary>
        /// Конструктор страницы добавления дисциплины
        /// </summary>
        public AddDisciplinePage()
        {
            InitializeComponent();

            CbAcademicPlan.ItemsSource = _db.GetContext().AcademicPlan.ToList();
            CbTypeDiscipline.ItemsSource = _db.GetContext().Kind_Of_Discipline.ToList();
            CbProffessionalModule.ItemsSource = _db.GetContext().Proffessional_Module.ToList();
            CbAssessmentForm.ItemsSource = _assessmentForms;
            CbNumberSemestr.ItemsSource = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };
            CbCompetenciesName.ItemsSource = _db.GetContext().Competencies.ToList();
        }
        /// <summary>
        /// Выбор учебного плана
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbAcademicPlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CbAcademicPlan.SelectedIndex != -1)
            {
                CbProffessionalModule.IsEnabled = true;
                foreach (Models.Proffessional_Module proffessional_Module in _db.GetContext().Proffessional_Module.ToList())
                {
                    if(proffessional_Module.AcademicPlan.PlanName == ((Models.AcademicPlan)CbAcademicPlan.SelectedItem).PlanName)
                    {
                        CbProffessionalModule.ItemsSource = proffessional_Module.AcademicPlan.Proffessional_Module.ToList();
                    }
                }
            }
            this._temporaryDiscipline.academicPlan = CbAcademicPlan.SelectedItem as Models.AcademicPlan;
        }
        /// <summary>
        /// Удаление умения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteSkill_Click(object sender, RoutedEventArgs e)
        {
            _db.GetContext().Skills.Remove(_db.GetContext().Skills.Where(s => s.Id == this._skills.Id).FirstOrDefault());
            _temporaryDiscipline.skills.Remove(this._skills);
            _db.GetContext().SaveChanges();

            UpdateAddDisciplinePage();
        }
        /// <summary>
        /// Удаление знания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteKnowledge_Click(object sender, RoutedEventArgs e)
        {
            _db.GetContext().Knowledge.Remove(_db.GetContext().Knowledge.Where(k => k.Id == this._knowledge.Id).FirstOrDefault());
            _temporaryDiscipline.knowledges.Remove(this._knowledge);
            _db.GetContext().SaveChanges();

            UpdateAddDisciplinePage();
        }
        /// <summary>
        /// Добавление умения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddSkill_Click(object sender, RoutedEventArgs e)
        {
            _temporaryDiscipline.skills.Add(new Models.Skills() { Name = TbSkillName.Text });
            _db.GetContext().Skills.Add(new Models.Skills() { Name = TbSkillName.Text, Discipline = _db.GetContext().Discipline.ToList()[0] });
            _db.GetContext().SaveChanges();

            UpdateAddDisciplinePage();
        }
        /// <summary>
        /// Добавление знания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddKnowledge_Click(object sender, RoutedEventArgs e)
        {
            _temporaryDiscipline.knowledges.Add(new Models.Knowledge() { Name = TbKnowledgeName.Text });
            _db.GetContext().Knowledge.Add(new Models.Knowledge() { Name = TbKnowledgeName.Text, Discipline = _db.GetContext().Discipline.ToList()[0] });
            _db.GetContext().SaveChanges();

            UpdateAddDisciplinePage();
        }
        /// <summary>
        /// Добавление компетенции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddCompetencies_Click(object sender, RoutedEventArgs e)
        {
            _temporaryDiscipline.competencies.Add(CbCompetenciesName.SelectedItem as Models.Competencies);
            _db.GetContext().Competencies.Add(new Models.Competencies() { CompetenciesName = (CbCompetenciesName.SelectedItem as Models.Competencies).CompetenciesName, Code = (CbCompetenciesName.SelectedItem as Models.Competencies).Code, Description = (CbCompetenciesName.SelectedItem as Models.Competencies).Description });
            _db.GetContext().SaveChanges();
            
            UpdateAddDisciplinePage();
        }
        /// <summary>
        /// Удаление компетенции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteCompetencies_Click(object sender, RoutedEventArgs e)
        {
            _db.GetContext().Competencies.Remove(_db.GetContext().Competencies.Where(c => c.Id == this._competencies.Id).FirstOrDefault());
            _temporaryDiscipline.competencies.Remove(this._competencies);
            _db.GetContext().SaveChanges();

            UpdateAddDisciplinePage();
        }
        /// <summary>
        /// Сохранение дисциплины в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveDiscipline_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName + ".dat", FileMode.OpenOrCreate))
                {
                    Classes.TemporaryDisciplineText temporaryDisciplineText = new Classes.TemporaryDisciplineText(_temporaryDiscipline.knowledges, _temporaryDiscipline.skills, _temporaryDiscipline.competencies, _temporaryDiscipline.Name, _temporaryDiscipline.kind, _temporaryDiscipline.module, _temporaryDiscipline.form, _temporaryDiscipline.academicPlan, _temporaryDiscipline.NumberSemestr);
                    _formatter.Serialize(fs, temporaryDisciplineText);
                }
            }
        }
        /// <summary>
        /// Редактирование дисциплины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditDiscipline_Click(object sender, RoutedEventArgs e)
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
                    this._temporaryDisciplineText = _formatter.Deserialize(fs) as Classes.TemporaryDisciplineText;
                    _temporaryDiscipline = new Classes.TemporaryDiscipline(_temporaryDisciplineText);
                }
            }
            UpdateAddDisciplinePage();
        }
        /// <summary>
        /// Обновление элементов страницы
        /// </summary>
        private void UpdateAddDisciplinePage()
        {
            for (int i = 0; i < _db.GetContext().AcademicPlan.ToList().Count; i++)
            {
                if (_db.GetContext().AcademicPlan.ToList()[i].PlanName == _temporaryDiscipline.academicPlan.PlanName)
                {
                    CbAcademicPlan.SelectedIndex = i;
                }
            }
            for (int i = 0; i < _db.GetContext().Kind_Of_Discipline.ToList().Count; i++)
            {
                if (_db.GetContext().Kind_Of_Discipline.ToList()[i].Name == _temporaryDiscipline.kind.Name)
                {
                    CbTypeDiscipline.SelectedIndex = i;
                }
            }
            for (int i = 0; i < _db.GetContext().Proffessional_Module.ToList().Count; i++)
            {
                if (_db.GetContext().Proffessional_Module.ToList()[i].Code == _temporaryDiscipline.module.Code)
                {
                    CbProffessionalModule.SelectedIndex = i;
                }
            }
            for (int i = 0; i < this._assessmentForms.Count; i++)
            {
                if (this._assessmentForms[i] == _temporaryDiscipline.form)
                {
                    CbAssessmentForm.SelectedIndex = i;
                }
            }
            CbNumberSemestr.SelectedIndex = _temporaryDiscipline.NumberSemestr - 1;
            TbNameDiscipline.Text = _temporaryDiscipline.Name;
            CleadLb();
            FillLb();
        }
        /// <summary>
        /// Заполнение списка компетенций, знаний и умений дисциплины
        /// </summary>
        private void FillLb()
        {
            foreach (var competence in _temporaryDiscipline.competencies)
            {
                LbCompetencies.Items.Add(competence);
            }
            foreach (var knowledge in _temporaryDiscipline.knowledges)
            {
                LbKnowledge.Items.Add(knowledge);
            }
            foreach (var skill in _temporaryDiscipline.skills)
            {
                LbSkill.Items.Add(skill);
            }
        }
        /// <summary>
        /// Очистка списка компетенций, знаний и умений дисциплины
        /// </summary>
        private void CleadLb()
        {
            LbCompetencies.Items.Clear();
            LbKnowledge.Items.Clear();
            LbSkill.Items.Clear();
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
        /// Ввод названия дисциплины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbNameDiscipline_TextChanged(object sender, TextChangedEventArgs e)
        {
            _temporaryDiscipline.Name = TbNameDiscipline.Text;
        }
        /// <summary>
        /// Выбранный элемент из списка профессиональных модулей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbProffessionalModule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _temporaryDiscipline.module = CbProffessionalModule.SelectedItem as Models.Proffessional_Module;
        }
        /// <summary>
        /// Выбранный элемент из списка типов дисциплин
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbTypeDiscipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _temporaryDiscipline.kind = CbTypeDiscipline.SelectedItem as Models.Kind_Of_Discipline;
        }
        /// <summary>
        /// Выбранный элемент из списка форм аттестации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbAssessmentForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _temporaryDiscipline.form = Convert.ToString(CbAssessmentForm.SelectedItem);
        }
        /// <summary>
        /// Выбранный элемент из списка номеров семестра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbNumberSemestr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _temporaryDiscipline.NumberSemestr = Convert.ToInt32(CbNumberSemestr.SelectedItem);
        }
        /// <summary>
        /// Выбранный элемент из списка компетенций
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbCompetencies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this._competencies = LbCompetencies.SelectedItem as Models.Competencies;
        }
        /// <summary>
        /// Выбранный элемент из списка умений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbSkill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this._skills = LbSkill.SelectedItem as Models.Skills;
        }
        /// <summary>
        /// Выбранный элемент из списка знаний
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbKnowledge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this._knowledge = LbKnowledge.SelectedItem as Models.Knowledge;
        }
    }
}
