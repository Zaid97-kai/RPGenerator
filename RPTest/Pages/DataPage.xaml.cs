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
using RPTest.Models;

namespace RPTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        public DataPage()
        {
            InitializeComponent();
            RefreshAll();
        }

        private void RefreshAll()
        {
            RefreshSkills();
            RefreshDiscipline();
            RefreshCompetencies();
            RefreshChapter();
        }
        private void BtAddSkill_Click(object sender, RoutedEventArgs e)
        {
            Models.Skills skills = new Models.Skills() { Name = TbSkillName.Text };
            _db.GetContext().Skills.Add(skills);
            _db.GetContext().SaveChanges();
            MessageBox.Show("Вы успешно добавили специальность!");
            RefreshSkills();
        }
        private void RefreshCompetencies()
        {
            CbGeneralCompetCode.Items.Clear();       
            foreach (Models.GeneralCompetencies u in _db.GetContext().GeneralCompetencies)
            {
                CbGeneralCompetCode.Items.Add(u);
            }
            CbCompetCode.Items.Clear();
            foreach (Models.ProfessionalCompetencies u in _db.GetContext().ProfessionalCompetencies)
            {
                CbCompetCode.Items.Add(u);
            }
        }
        private void RefreshSkills()
        {
            CbSkillName.Items.Clear();
            foreach (Models.Skills u in _db.GetContext().Skills)
            {
                CbSkillName.Items.Add(u);
            }
        }
        private void RefreshDiscipline()
        {
            CbChapterDiscipline.Items.Clear();
            CbDisciplineName.Items.Clear();
            foreach(Models.Discipline u in _db.GetContext().Discipline)
            {
                CbChapterDiscipline.Items.Add(u);
                CbDisciplineName.Items.Add(u);
            }
        }
        private void RefreshChapter()
        {
            CbChapterName.Items.Clear();
            foreach(Chapter u in _db.GetContext().Chapter)
            {
                CbChapterName.Items.Add(u);
            }
        }

        private void BtnAddSkills_Click(object sender, RoutedEventArgs e)
        {
            Window.SkillsAdd skillsAdd = new Window.SkillsAdd();
            skillsAdd.ShowDialog();
        }

        private void BtnSaveSkill_Click(object sender, RoutedEventArgs e)
        {

            Models.Skills skills = _db.GetContext().Skills.FirstOrDefault(p => p.Id == ((Models.Skills)CbSkillName.SelectedItem).Id);
            _db.GetContext().Skills.Remove(skills);
            _db.GetContext().SaveChanges();
            skills.Name = TbSkillName.Text;
            skills.Id_Discipline = ((Models.Discipline)CbDisciplineName.SelectedItem).Id;
            _db.GetContext().Skills.Add(skills);
            _db.GetContext().SaveChanges();
            MessageBox.Show("Успешно!");
            RefreshSkills();
        }

        private void CbSkillName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CbSkillName.SelectedItem != null)
            {
                Models.Skills skills = _db.GetContext().Skills.FirstOrDefault(p => p.Id == ((Models.Skills)CbSkillName.SelectedItem).Id);
                TbSkillId.Text = Convert.ToString(skills.Id);
                TbSkillName.Text = skills.Name;
                CbDisciplineName.SelectedItem = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == skills.Id_Discipline);
            }
            
        }

        private void BtnAddCompet_Click(object sender, RoutedEventArgs e)
        {
            Window.AddCompetencionWindow addCompetencionWindow = new Window.AddCompetencionWindow();
            addCompetencionWindow.ShowDialog();
            RefreshAll();

        }

        private void CbCompetCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CbCompetCode.SelectedItem != null)
                {
                        ProfessionalCompetencies professionalCompetencies = _db.GetContext().ProfessionalCompetencies.FirstOrDefault(p => p.Code == ((ProfessionalCompetencies)CbCompetCode.SelectedItem).Code);
                        TbCompetID.Text = Convert.ToString(professionalCompetencies.Id);
                        TbCompetCode.Text = professionalCompetencies.Code;
                        TbCompetDescription.Text = professionalCompetencies.Description;
                        TbCompetEvaluation.Text = professionalCompetencies.EvaluationCriteria;
                        TbCompetMethods.Text = professionalCompetencies.AssessmentMethods;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void BtnDeleteCompet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProfessionalCompetencies professionalCompetencies = _db.GetContext().ProfessionalCompetencies.FirstOrDefault(p => p.Code == ((ProfessionalCompetencies)CbCompetCode.SelectedItem).Code);
                _db.GetContext().ProfessionalCompetencies.Remove(professionalCompetencies);
                _db.GetContext().SaveChanges();
                RefreshCompetencies();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void BtnSaveCompet_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ProfessionalCompetencies professionalCompetencies = _db.GetContext().ProfessionalCompetencies.FirstOrDefault(p => p.Code == ((ProfessionalCompetencies)CbCompetCode.SelectedItem).Code);
                professionalCompetencies.Code = TbCompetCode.Text;
                professionalCompetencies.Description = TbCompetDescription.Text;
                professionalCompetencies.EvaluationCriteria = TbCompetEvaluation.Text;
                professionalCompetencies.AssessmentMethods = TbCompetMethods.Text;
                _db.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено!");
                RefreshCompetencies();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void BtnAddGeneralCompet_Click(object sender, RoutedEventArgs e)
        {
            Window.AddCompetencionWindow addCompetencionWindow = new Window.AddCompetencionWindow();
            addCompetencionWindow.ShowDialog();
            RefreshAll();
        }

        private void CbGeneralCompetCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CbGeneralCompetCode.SelectedItem != null)
            {
                GeneralCompetencies generalCompetencies = _db.GetContext().GeneralCompetencies.FirstOrDefault(p => p.Code == ((GeneralCompetencies)CbGeneralCompetCode.SelectedItem).Code);
                TbGeneralCompetID.Text = Convert.ToString(generalCompetencies.Id);
                TbGeneralCompetCode.Text = generalCompetencies.Code;
                TbGeneralCompetDescription.Text = generalCompetencies.Description;
                TbGeneralCompetEvaluation.Text = generalCompetencies.EvaluationCriteria;
                TbGeneralCompetMethods.Text = generalCompetencies.AssessmentMethods;
            }
            
        }

        private void BtnDeleteGeneralCompet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GeneralCompetencies generalCompetencies = _db.GetContext().GeneralCompetencies.FirstOrDefault(p => p.Code == ((GeneralCompetencies)CbGeneralCompetCode.SelectedItem).Code);
                _db.GetContext().GeneralCompetencies.Remove(generalCompetencies);
                _db.GetContext().SaveChanges();
                RefreshCompetencies();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }

        }

        private void BtnSaveGeneralCompet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GeneralCompetencies generalCompetencies = _db.GetContext().GeneralCompetencies.FirstOrDefault(p => p.Code == ((GeneralCompetencies)CbGeneralCompetCode.SelectedItem).Code);
                generalCompetencies.Code = TbGeneralCompetCode.Text;
                generalCompetencies.Description = TbGeneralCompetDescription.Text;
                generalCompetencies.EvaluationCriteria = TbGeneralCompetEvaluation.Text;
                generalCompetencies.AssessmentMethods = TbGeneralCompetMethods.Text;
                _db.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено!");
                RefreshCompetencies();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }

        }

        private void BtnAddChapter_Click(object sender, RoutedEventArgs e)
        {
            Window.AddTopicWindow addTopicWindow = new Window.AddTopicWindow();
            addTopicWindow.ShowDialog();
            RefreshAll();
        }

        private void BtnDeleteChapter_Click(object sender, RoutedEventArgs e)
        {
            Chapter chapter = _db.GetContext().Chapter.FirstOrDefault(p => p.Name == ((Chapter)CbChapterName.SelectedItem).Name);
            _db.GetContext().Chapter.Remove(chapter);
            _db.GetContext().SaveChanges();
            RefreshChapter();
        }

        private void BtnSaveChapter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Chapter chapter = _db.GetContext().Chapter.FirstOrDefault(p => p.Name == ((Chapter)CbChapterName.SelectedItem).Name);
                chapter.Name = TbChapterName.Text;
                chapter.Id_Discipline = ((Discipline)CbChapterDiscipline.SelectedItem).Id;
                _db.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено!");
                RefreshCompetencies();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void CbChapterName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbChapterName.SelectedItem != null)
            {
                Chapter chapter = _db.GetContext().Chapter.FirstOrDefault(p => p.Name == ((Chapter)CbChapterName.SelectedItem).Name);
                TbChapterName.Text = chapter.Name;
                CbChapterDiscipline.SelectedItem = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == chapter.Id_Discipline);
            }
        }

        private void BtnDeleteContent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSaveContent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddContent_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
