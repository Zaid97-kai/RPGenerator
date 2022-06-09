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
            RefreshPM();
        }

        private void RefreshPM()
        {
            CbPMCode.Items.Clear();
            foreach(Proffessional_Module u in _db.GetContext().Proffessional_Module)
            {
                CbPMCode.Items.Add(u);
            }
        }
        private void RefreshSpecialty()
        {
            CbSpecialtyCode.Items.Clear();
            CbPMSpecialty.Items.Clear();
            foreach(Specialty u in _db.GetContext().Specialty)
            {
                CbSpecialtyCode.Items.Add(u);
                CbPMSpecialty.Items.Add(u);
            }
        }

        private void RefreshSkills()
        {
            CbSkillsName.Items.Clear();
            CbSkillsName.SelectedItem = null;
            foreach(Skills u in _db.GetContext().Skills)
            {
                CbSkillsName.Items.Add(u);
            }
        }

        private void RefreshExpPractice()
        {
            CbSkillsName.Items.Clear();
            CbSkillsName.SelectedItem = null;

            foreach (ExpPractice u in _db.GetContext().ExpPractice)
            {
                CbSkillsName.Items.Add(u);
            }
        }
        private void RefreshKnowledge()
        {
            CbSkillsName.Items.Clear();
            CbSkillsName.SelectedItem = null;
            foreach (Knowledge u in _db.GetContext().Knowledge)
            {
                CbSkillsName.Items.Add(u);
            }
        }
        private void RefreshLbCompetencies()
        {
            Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == ((Discipline)CbDiscipline.SelectedItem).Id);
            List<Discipline_Competencies> discipline_Competencies = new List<Discipline_Competencies>();
            List<Discipline_ProfCompet> discipline_ProfCompet = new List<Discipline_ProfCompet>();
            List<ProfessionalCompetencies> professionalCompetencies = new List<ProfessionalCompetencies>();
            List<GeneralCompetencies> generalCompetencies = new List<GeneralCompetencies>();
            foreach (Discipline_Competencies u in _db.GetContext().Discipline_Competencies)
            {
                if (u.Id_Discipline == discipline.Id)
                {
                    discipline_Competencies.Add(u);
                }
            }
            foreach (Discipline_Competencies u in discipline_Competencies)
            {
                generalCompetencies.Add(_db.GetContext().GeneralCompetencies.FirstOrDefault(p => p.Id == u.Id_Competencies));
            }
            LbDisciplineGeneralCompet.ItemsSource = generalCompetencies;

            foreach (Discipline_ProfCompet u in _db.GetContext().Discipline_ProfCompet)
            {
                if (u.Id_Discipline == discipline.Id)
                {
                    discipline_ProfCompet.Add(u);
                }
            }
            foreach (Discipline_ProfCompet u in discipline_ProfCompet)
            {
                professionalCompetencies.Add(_db.GetContext().ProfessionalCompetencies.FirstOrDefault(p => p.Id == u.Id_Competencies));
            }
            LbDisciplineProfCompet.ItemsSource = professionalCompetencies;
        }
        private void RefreshCompetencies()
        {
            CbGeneralCompetCode.Items.Clear();
           CbDisciplineGeneralCompet.Items.Clear();
            foreach (Models.GeneralCompetencies u in _db.GetContext().GeneralCompetencies)
            {
                CbGeneralCompetCode.Items.Add(u);
                CbDisciplineGeneralCompet.Items.Add(u);
            }
            CbCompetCode.Items.Clear();
            CbDisciplineProfCompet.Items.Clear();
            foreach (Models.ProfessionalCompetencies u in _db.GetContext().ProfessionalCompetencies)
            {
                CbCompetCode.Items.Add(u);
               CbDisciplineProfCompet.Items.Add(u);
            }
        }
        private void RefreshDiscipline()
        {
            CbChapterDiscipline.Items.Clear();
            CbDiscipline.Items.Clear();
            CbDisciplineName.Items.Clear();
            CbSkillDiscipline.Items.Clear();
            foreach (Models.Discipline u in _db.GetContext().Discipline)
            {
                CbChapterDiscipline.Items.Add(u);
                CbDiscipline.Items.Add(u);
                CbDisciplineName.Items.Add(u);
                CbSkillDiscipline.Items.Add(u);
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
                    content.Type = "Практическая работа";
                if (RbContentLections.IsChecked == true)
                    content.Type = "Содержание";
                if (RbContentLR.IsChecked == true)
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
                if (content.Type == "Практическая работа")
                    RbContentPR.IsChecked = true;
                if (RbContentLections.IsChecked == true)
                    content.Type = "Содержание";
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


        private void CbDiscipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                RefreshLbCompetencies();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void BtnAddDisciplineGeneralCompet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LbDisciplineGeneralCompet.SelectedItem != null)
                {
                    GeneralCompetencies generalCompetencies = _db.GetContext().GeneralCompetencies.FirstOrDefault(p => p.Id == ((GeneralCompetencies)LbDisciplineGeneralCompet.SelectedItem).Id);
                    Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == ((Discipline)CbDiscipline.SelectedItem).Id);
                    Discipline_Competencies discipline_Competencies = _db.GetContext().Discipline_Competencies.FirstOrDefault(p => p.Id_Competencies == generalCompetencies.Id && p.Id_Discipline == discipline.Id);
                    _db.GetContext().Discipline_Competencies.Remove(discipline_Competencies);
                    _db.GetContext().SaveChanges();
                }
                if (LbDisciplineProfCompet.SelectedItem != null)
                {
                    ProfessionalCompetencies professionalCompetencies = _db.GetContext().ProfessionalCompetencies.FirstOrDefault(p => p.Id == ((ProfessionalCompetencies)LbDisciplineProfCompet.SelectedItem).Id);
                    Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == ((Discipline)CbDiscipline.SelectedItem).Id);
                    Discipline_ProfCompet discipline_ProfCompet = _db.GetContext().Discipline_ProfCompet.FirstOrDefault(p => p.Id_Competencies == professionalCompetencies.Id && p.Id_Discipline == discipline.Id);
                    _db.GetContext().Discipline_ProfCompet.Remove(discipline_ProfCompet);
                    _db.GetContext().SaveChanges();
                }
                    RefreshLbCompetencies();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }

        }


        private void BtnAddCompetencies_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CbDisciplineGeneralCompet.SelectedItem != null)
                {
                    GeneralCompetencies generalCompetencies = _db.GetContext().GeneralCompetencies.FirstOrDefault(p => p.Id == ((GeneralCompetencies)CbDisciplineGeneralCompet.SelectedItem).Id);
                    Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == ((Discipline)CbDiscipline.SelectedItem).Id);
                    Discipline_Competencies discipline_Competencies = new Discipline_Competencies();
                    discipline_Competencies.Id_Competencies = generalCompetencies.Id;
                    discipline_Competencies.Id_Discipline = discipline.Id;
                    _db.GetContext().Discipline_Competencies.Add(discipline_Competencies);
                    _db.GetContext().SaveChanges();
                    CbDisciplineGeneralCompet.SelectedItem = null;
                }
                if (CbDisciplineProfCompet.SelectedItem != null)
                {
                    ProfessionalCompetencies professionalCompetencies = _db.GetContext().ProfessionalCompetencies.FirstOrDefault(p => p.Id == ((ProfessionalCompetencies)CbDisciplineProfCompet.SelectedItem).Id);
                    Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == ((Discipline)CbDiscipline.SelectedItem).Id);
                    Discipline_ProfCompet discipline_ProfCompet = new Discipline_ProfCompet();
                    discipline_ProfCompet.Id_Competencies = professionalCompetencies.Id;
                    discipline_ProfCompet.Id_Discipline = discipline.Id;
                    _db.GetContext().Discipline_ProfCompet.Add(discipline_ProfCompet);
                    _db.GetContext().SaveChanges();
                    CbDisciplineProfCompet.SelectedItem = null;
                }
                RefreshLbCompetencies();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void LbDisciplineGeneralCompet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LbDisciplineProfCompet.SelectedIndex = -1 ;
        }

        private void LbDisciplineProfCompet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LbDisciplineGeneralCompet.SelectedIndex = -1;
        }

        private void CbDisciplineName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CbDisciplineName.SelectedItem != null)
                {
                    Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == ((Discipline)CbDisciplineName.SelectedItem).Id);
                    TbDisName.Text = discipline.Name;
                    TbDisID.Text = Convert.ToString(discipline.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void BtnAddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            Window.AddDIsciplineWindow addDIsciplineWindow = new Window.AddDIsciplineWindow();
            addDIsciplineWindow.ShowDialog();
            RefreshAll();
        }

        private void BtnSaveDiscipline_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == ((Discipline)CbDisciplineName.SelectedItem).Id);
                discipline.Name = TbDisName.Text;
                discipline.Id = Convert.ToInt32(TbDisID.Text);
                _db.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено!");
                RefreshDiscipline();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void BtnDeleteDiscipline_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == ((Discipline)CbDisciplineName.SelectedItem).Id);
                _db.GetContext().Discipline.Remove(discipline);
                _db.GetContext().SaveChanges();
                RefreshDiscipline();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void BtnAddPM_Click(object sender, RoutedEventArgs e)
        {
            Window.AddPMWindow addPMWindow = new Window.AddPMWindow();
            addPMWindow.ShowDialog();
            RefreshAll();
        }

        private void CbPMCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CbPMCode.SelectedItem != null)
                {
                    Proffessional_Module proffessional_Module = _db.GetContext().Proffessional_Module.FirstOrDefault(p => p.Id == ((Proffessional_Module)CbPMCode.SelectedItem).Id);
                    TbPMCode.Text = proffessional_Module.Code;
                    TbPMName.Text = proffessional_Module.Name;
                    TbPMID.Text = Convert.ToString(proffessional_Module.Id);
                    CbPMSpecialty.SelectedItem = _db.GetContext().Specialty.FirstOrDefault(p => p.Id == proffessional_Module.Id_Specialty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void BtnDeletePM_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Proffessional_Module proffessional_Module = _db.GetContext().Proffessional_Module.FirstOrDefault(p => p.Id == ((Proffessional_Module)CbPMCode.SelectedItem).Id);
                _db.GetContext().Proffessional_Module.Remove(proffessional_Module);
                _db.GetContext().SaveChanges();
                RefreshPM();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void BtnSavePM_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Proffessional_Module proffessional_Module = _db.GetContext().Proffessional_Module.FirstOrDefault(p => p.Id == ((Proffessional_Module)CbPMCode.SelectedItem).Id);
                proffessional_Module.Code = TbPMCode.Text;
                proffessional_Module.Name = TbPMName.Text;
                proffessional_Module.Id = Convert.ToInt32(TbPMID.Text);
                proffessional_Module.Id_Specialty = ((Specialty)CbPMSpecialty.SelectedItem).Id;
                _db.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено!");
                RefreshPM();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void CbSkillsName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(CbSkillsName.SelectedItem != null)
                {
                    if (RbSkillExp.IsChecked == true)
                    {
                        ExpPractice expPractice = _db.GetContext().ExpPractice.FirstOrDefault(p => p.id == ((ExpPractice)CbSkillsName.SelectedItem).id);
                        TbSkillName.Text = expPractice.Name;
                        CbSkillDiscipline.SelectedItem = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == expPractice.Id_Discipline);
                    }
                    if (RbSkillSkill.IsChecked == true)
                    {
                        Skills skills = _db.GetContext().Skills.FirstOrDefault(p => p.Id == ((Skills)CbSkillsName.SelectedItem).Id);
                        TbSkillName.Text = skills.Name;
                        CbSkillDiscipline.SelectedItem = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == skills.Id_Discipline);
                    }
                    if (RbSkillKnoweledge.IsChecked == true)
                    {
                        Knowledge knowledge = _db.GetContext().Knowledge.FirstOrDefault(p => p.Id == ((Knowledge)CbSkillsName.SelectedItem).Id);
                        TbSkillName.Text = knowledge.Name;
                        CbSkillDiscipline.SelectedItem = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == knowledge.Id_Discipline);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }


        }

        private void BtnAddSkills_Click_1(object sender, RoutedEventArgs e)
        {
            Window.AddSkillWindow addSkillWindow = new Window.AddSkillWindow();
            addSkillWindow.ShowDialog();
            RefreshExpPractice();
            RefreshSkills();
            RefreshKnowledge();
            CbSkillsName.Items.Clear();
        }

        private void BtnDeleteSkill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CbSkillsName.SelectedItem != null)
                {

                    if (RbSkillExp.IsChecked == true)
                    {
                        ExpPractice expPractice = _db.GetContext().ExpPractice.FirstOrDefault(p => p.id == ((ExpPractice)CbSkillsName.SelectedItem).id);
                        _db.GetContext().ExpPractice.Remove(expPractice);
                    }
                    if (RbSkillSkill.IsChecked == true)
                    {
                        Skills skills = _db.GetContext().Skills.FirstOrDefault(p => p.Id == ((Skills)CbSkillsName.SelectedItem).Id);
                        _db.GetContext().Skills.Remove(skills);
                    }
                    if (RbSkillKnoweledge.IsChecked == true)
                    {
                        Knowledge knowledge = _db.GetContext().Knowledge.FirstOrDefault(p => p.Id == ((Knowledge)CbSkillsName.SelectedItem).Id);
                        _db.GetContext().Knowledge.Remove(knowledge);
                    }
                    _db.GetContext().SaveChanges();
                    RefreshExpPractice();
                    RefreshSkills();
                    RefreshKnowledge();
                    CbSkillsName.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void BtnAddSkill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CbSkillsName.SelectedItem != null)
                {
                    if (RbSkillExp.IsChecked == true)
                    {
                        ExpPractice expPractice = _db.GetContext().ExpPractice.FirstOrDefault(p => p.id == ((ExpPractice)CbSkillsName.SelectedItem).id);
                        expPractice.Name = TbSkillName.Text;
                        expPractice.Id_Discipline = ((Discipline)CbSkillDiscipline.SelectedItem).Id;
                    }
                    if (RbSkillSkill.IsChecked == true)
                    {
                        Skills skills = _db.GetContext().Skills.FirstOrDefault(p => p.Id == ((Skills)CbSkillsName.SelectedItem).Id);
                        skills.Name = TbSkillName.Text;
                        skills.Id_Discipline = ((Discipline)CbSkillDiscipline.SelectedItem).Id;
                    }
                    if (RbSkillKnoweledge.IsChecked == true)
                    {
                        Knowledge knowledge = _db.GetContext().Knowledge.FirstOrDefault(p => p.Id == ((Knowledge)CbSkillsName.SelectedItem).Id);
                        knowledge.Name = TbSkillName.Text;
                        knowledge.Id_Discipline = ((Discipline)CbSkillDiscipline.SelectedItem).Id;
                    }
                    _db.GetContext().SaveChanges();
                    MessageBox.Show("Успешно сохранено!");
                    
                    RefreshExpPractice();
                    RefreshSkills();
                    RefreshKnowledge();
                    CbSkillsName.Items.Clear();

                    RbSkillSkill.IsChecked = false;
                    RbSkillKnoweledge.IsChecked = false;
                    RbSkillExp.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

        private void RbSkillExp_Checked(object sender, RoutedEventArgs e)
        {
            CbPMSpecialty.Items.Clear();
            RbSkillSkill.IsChecked = false;
            RbSkillKnoweledge.IsChecked = false;
            RefreshExpPractice();

        }

        private void RbSkillSkill_Checked(object sender, RoutedEventArgs e)
        {
            CbPMSpecialty.Items.Clear();
            RbSkillExp.IsChecked = false;
            RbSkillKnoweledge.IsChecked = false;
            RefreshSkills();

        }

        private void RbSkillKnoweledge_Checked(object sender, RoutedEventArgs e)
        {
            CbPMSpecialty.Items.Clear();
            RbSkillSkill.IsChecked = false;
            RbSkillExp.IsChecked = false;
            RefreshKnowledge();

        }
    }
}
