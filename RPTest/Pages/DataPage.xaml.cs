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
            RefreshDiscipline();
            RefreshCompetencies();
            RefreshChapter();
            RefreshContent();
            RefreshSpecialty();
        }

        private void RefreshSpecialty()
        {
            CbSpecialtyCode.Items.Clear();
            foreach(Specialty u in _db.GetContext().Specialty)
            {
                CbSpecialtyCode.Items.Add(u);
            }
        }
        private void RefreshCompetencies()
        {
            CbGeneralCompetCode.Items.Clear();
           // CbDisciplineGeneralCompet.Items.Clear();
            foreach (Models.GeneralCompetencies u in _db.GetContext().GeneralCompetencies)
            {
                CbGeneralCompetCode.Items.Add(u);
                //CbDisciplineGeneralCompet.Items.Add(u);
            }
            CbCompetCode.Items.Clear();
            //CbDisciplineProfCompet.Items.Clear();
            foreach (Models.ProfessionalCompetencies u in _db.GetContext().ProfessionalCompetencies)
            {
                CbCompetCode.Items.Add(u);
               // CbDisciplineProfCompet.Items.Add(u);
            }
        }
        private void RefreshDiscipline()
        {
            CbChapterDiscipline.Items.Clear();
            //CbDiscipline.Items.Clear();
            foreach (Models.Discipline u in _db.GetContext().Discipline)
            {
                CbChapterDiscipline.Items.Add(u);
                //CbDiscipline.Items.Add(u);
            }
        }

        private void RefreshContent()
        {
            CbContentDescription.Items.Clear();
            foreach (Models.Content u in _db.GetContext().Content)
            {
                CbContentDescription.Items.Add(u);
            }
        }
        private void RefreshChapter()
        {
            CbChapterName.Items.Clear();
            CbContentChapter.Items.Clear();
            foreach (Chapter u in _db.GetContext().Chapter)
            {
                CbChapterName.Items.Add(u);
                CbContentChapter.Items.Add(u);
            }
        }

        private void BtnAddSkills_Click(object sender, RoutedEventArgs e)
        {
            Window.SkillsAdd skillsAdd = new Window.SkillsAdd();
            skillsAdd.ShowDialog();
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
            try
            {
                Chapter chapter = _db.GetContext().Chapter.FirstOrDefault(p => p.Name == ((Chapter)CbChapterName.SelectedItem).Name);
                _db.GetContext().Chapter.Remove(chapter);
                _db.GetContext().SaveChanges();
                RefreshChapter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }

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
                RefreshChapter();
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
            try
            {
                Content content = _db.GetContext().Content.FirstOrDefault(p => p.Name == ((Content)CbContentDescription.SelectedItem).Name);
                _db.GetContext().Content.Remove(content);
                _db.GetContext().SaveChanges();
                RefreshContent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void BtnSaveContent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Content content = _db.GetContext().Content.FirstOrDefault(p => p.Name == ((Content)CbContentDescription.SelectedItem).Name);
                content.Name = TbContent.Text;
                content.Id_Chapter = ((Chapter)CbContentChapter.SelectedItem).Id;
                content.Hourly_Load = Convert.ToInt32(TbContentLoad.Text);
                if (RbContentPR.IsChecked == true)
                    content.Type = "Содержание";
                if (RbContentLR.IsChecked == true)
                    content.Type = "Лабораторная работа";
                if (RbContentSR.IsChecked == true)
                    content.Type = "Самостоятельная работа";
                _db.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено!");
                RefreshContent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void BtnAddContent_Click(object sender, RoutedEventArgs e)
        {
            Window.AddContentWindow addContentWindow = new Window.AddContentWindow();
            addContentWindow.ShowDialog();
            RefreshAll();
        }

        private void CbContentDescription_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbContentDescription.SelectedItem != null)
            {
                Content content = _db.GetContext().Content.FirstOrDefault(p => p.Name == ((Content)CbContentDescription.SelectedItem).Name);
                TbContent.Text = content.Name;
                CbContentChapter.SelectedItem = _db.GetContext().Chapter.FirstOrDefault(p => p.Id == content.Id_Chapter);
                TbContentLoad.Text = Convert.ToString(content.Hourly_Load);
                if (content.Type == "Содержание")
                    RbContentPR.IsChecked = true;
                if (content.Type == "Лабораторная работа")
                    RbContentLR.IsChecked = true;
                if (content.Type == "Самостоятельная работа")
                    RbContentSR.IsChecked = true;

            }
        }

        private void CbSpecialtyCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbSpecialtyCode.SelectedItem != null)
            {
                Specialty specialty = _db.GetContext().Specialty.FirstOrDefault(p => p.Code == ((Specialty)CbSpecialtyCode.SelectedItem).Code);
                TbSpecialtyID.Text = Convert.ToString(specialty.Id);
                TbSpecialtyName.Text = specialty.Name;
                TbSpecialtyCode.Text = specialty.Code;
                TbSpecialtyQualification.Text = specialty.Qualification;
            }
        }

        private void BtnAddSpecialty_Click(object sender, RoutedEventArgs e)
        {
            Window.AddSpecialtyWindow addSpecialtyWindow = new Window.AddSpecialtyWindow();
            addSpecialtyWindow.ShowDialog();
            RefreshAll();
        }

        private void BtnDeleteSpecialty_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Specialty specialty = _db.GetContext().Specialty.FirstOrDefault(p => p.Id == ((Specialty)CbSpecialtyCode.SelectedItem).Id);
                _db.GetContext().Specialty.Remove(specialty);
                _db.GetContext().SaveChanges();
                RefreshSpecialty();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void BtnSaveSpecialty_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Specialty specialty = _db.GetContext().Specialty.FirstOrDefault(p => p.Id == ((Specialty)CbSpecialtyCode.SelectedItem).Id);
                specialty.Name = TbSpecialtyName.Text;
                specialty.Code = TbSpecialtyCode.Text;
                specialty.Qualification = TbSpecialtyQualification.Text;
                _db.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено!");
                RefreshSpecialty();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        /*private void CbDiscipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == ((Discipline)CbDiscipline.SelectedItem).Id);
            List<Discipline_Competencies> discipline_Competencies = new List<Discipline_Competencies>();
            List<GeneralCompetencies> generalCompetencies = new List<GeneralCompetencies>();
            foreach (Discipline_Competencies u in _db.GetContext().Discipline_Competencies)
            {
                if (u.Id_Discipline == discipline.Id)
                {
                    discipline_Competencies.Add(u);

                }
            }
            foreach(Discipline_Competencies u in discipline_Competencies)
            {
                generalCompetencies.Add(generalCompetencies.FirstOrDefault(p => p.Id == u.Id_Competencies));
                LbDisciplineGeneralCompet.Items.Add(generalCompetencies);
            }
            LbDisciplineGeneralCompet.ItemsSource = generalCompetencies;
        }

        private void BtnAddDisciplineGeneralCompet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GeneralCompetencies generalCompetencies = _db.GetContext().GeneralCompetencies.FirstOrDefault(p => p.Id == ((GeneralCompetencies)CbDisciplineGeneralCompet.SelectedItem).Id);
                Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == ((Discipline)CbDiscipline.SelectedItem).Id);
                Discipline_Competencies discipline_Competencies = new Discipline_Competencies();
                discipline_Competencies.Id_Competencies = generalCompetencies.Id;
                discipline_Competencies.Id_Discipline = discipline.Id;
                _db.GetContext().Discipline_Competencies.Add(discipline_Competencies);
                _db.GetContext().SaveChanges();
                LbDisciplineGeneralCompet.Items.Add(generalCompetencies);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }

        }

        private void BtnAddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            Window.AddDisciplineCompet addDisciplineCompet = new Window.AddDisciplineCompet();
            addDisciplineCompet.ShowDialog();
            RefreshAll();
        }*/
    }
}
