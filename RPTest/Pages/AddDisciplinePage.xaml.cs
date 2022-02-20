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

namespace RPTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddDisciplinePage.xaml
    /// </summary>
    public partial class AddDisciplinePage : Page
    {
        private Models.DBModel _db = new Models.DBModel();
        private Classes.TemporaryDiscipline _temporaryDiscipline = new Classes.TemporaryDiscipline();
        private Classes.TemporaryDisciplineText _temporaryDisciplineText;
        private BinaryFormatter _formatter = new BinaryFormatter();
        public AddDisciplinePage()
        {
            InitializeComponent();

            CbAcademicPlan.ItemsSource = _db.AcademicPlan.ToList();
            CbTypeDiscipline.ItemsSource = _db.Kind_Of_Discipline.ToList();
            CbProffessionalModule.ItemsSource = _db.Proffessional_Module.ToList();
            CbAssessmentForm.ItemsSource = new List<string> { "Экзамен", "Зачет", "Дифференцированный зачет", "Курсовая работа", "Другая форма контроля" };
            CbNumberSemestr.ItemsSource = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8"};
            CbCompetenciesName.ItemsSource = _db.Competencies.ToList();
        }

        private void CbAcademicPlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CbAcademicPlan.SelectedIndex != -1)
            {
                CbProffessionalModule.IsEnabled = true;
                foreach (Models.Proffessional_Module proffessional_Module in _db.Proffessional_Module.ToList())
                {
                    if(proffessional_Module.AcademicPlan.PlanName == ((Models.AcademicPlan)CbAcademicPlan.SelectedItem).PlanName)
                    {
                        CbProffessionalModule.ItemsSource = proffessional_Module.AcademicPlan.Proffessional_Module.ToList();
                    }
                }
            }
            this._temporaryDiscipline.academicPlan = CbAcademicPlan.SelectedItem as Models.AcademicPlan;
        }

        private void BtnAddSkill_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteSkill_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteKnowledge_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddKnowledge_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddCompetencies_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteCompetencies_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSaveDiscipline_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("_temporaryDiscipline.dat", FileMode.OpenOrCreate))
            {
                Classes.TemporaryDisciplineText temporaryDisciplineText = new Classes.TemporaryDisciplineText(_temporaryDiscipline.knowledges, _temporaryDiscipline.skills, _temporaryDiscipline.competencies, _temporaryDiscipline.Name, _temporaryDiscipline.kind, _temporaryDiscipline.module, _temporaryDiscipline.form, _temporaryDiscipline.academicPlan, _temporaryDiscipline.NumberSemestr);
                _formatter.Serialize(fs, temporaryDisciplineText);
            }
        }

        private void BtnEditDiscipline_Click(object sender, RoutedEventArgs e)
        {
            string FilePath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
            }

            using (FileStream fs = new FileStream(FilePath, FileMode.Open))
            {
                this._temporaryDisciplineText = _formatter.Deserialize(fs) as Classes.TemporaryDisciplineText;
                _temporaryDiscipline = new Classes.TemporaryDiscipline(_temporaryDisciplineText);
                MessageBox.Show(_temporaryDiscipline.Name);
            }
        }

        private void CbCompetenciesName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TbNameDiscipline_TextChanged(object sender, TextChangedEventArgs e)
        {
            _temporaryDiscipline.Name = TbNameDiscipline.Text;
        }

        private void CbProffessionalModule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _temporaryDiscipline.module = CbProffessionalModule.SelectedItem as Models.Proffessional_Module;
        }

        private void CbTypeDiscipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _temporaryDiscipline.kind = CbTypeDiscipline.SelectedItem as Models.Kind_Of_Discipline;
        }

        private void CbAssessmentForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _temporaryDiscipline.form = Convert.ToString(CbAssessmentForm.SelectedItem);
        }

        private void CbNumberSemestr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _temporaryDiscipline.NumberSemestr = Convert.ToInt32(CbNumberSemestr.SelectedItem);
        }
    }
}
