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

namespace RPTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddDisciplinePage.xaml
    /// </summary>
    public partial class AddDisciplinePage : Page
    {
        private Models.DBModel _db = new Models.DBModel();
        public AddDisciplinePage()
        {
            InitializeComponent();

            CbAcademicPlan.ItemsSource = _db.AcademicPlan.ToList();
            CbTypeDiscipline.ItemsSource = _db.Kind_Of_Discipline.ToList();
            CbProffessionalModule.ItemsSource = _db.Proffessional_Module.ToList();
            CbAssessmentForm.ItemsSource = new List<string> { "Экзамен", "Зачет", "Дифференцированный зачет", "Курсовая работа", "Другая форма контроля" };
            CbNumberSemestr.ItemsSource = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8"};
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

        }

        private void BtnEditDiscipline_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
