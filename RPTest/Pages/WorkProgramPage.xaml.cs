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
    /// Логика взаимодействия для WorkProgramPage.xaml
    /// </summary>
    public partial class WorkProgramPage : Page
    {
        private List<string> _specialtyCodes = new List<string>() { "09.02.06 Сетевое и системное администрирование", "09.02.07 Информационные системы и программирование", "10.02.05 Обеспечение информационной безопасности автоматизированных систем" };
        public WorkProgramPage()
        {
            InitializeComponent();
            CbCode.ItemsSource = _specialtyCodes;
        }

        private void CbCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        }

        private void BtnDeleteKnowledge_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddSkill_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteSkill_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbCompetenciesName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAddCompetencies_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteCompetencies_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
