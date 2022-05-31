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
    /// Логика взаимодействия для AddCompetencionWindow.xaml
    /// </summary>
    public partial class AddCompetencionWindow : System.Windows.Window
    {
        public AddCompetencionWindow()
        {
            InitializeComponent();
        }

        private void BtnAddCompet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ChBoxCompetProffessional.IsChecked == true)
                {
                    ProfessionalCompetencies professionalCompetencies = new ProfessionalCompetencies()
                    {
                        Code = TbCompetCode.Text,
                        Description = TbCompetDescription.Text,
                        EvaluationCriteria = TbCompetEvaluation.Text,
                        AssessmentMethods = TbCompetMethods.Text
                  
                    };
                    _db.GetContext().ProfessionalCompetencies.Add(professionalCompetencies);
                    _db.GetContext().SaveChanges();
                    MessageBox.Show("Вы успешно добавили компетенцию!");
                }
                else
                {
                    GeneralCompetencies generalCompetencies = new GeneralCompetencies()
                    {
                        Code = TbCompetCode.Text,
                        Description = TbCompetDescription.Text,
                        EvaluationCriteria = TbCompetEvaluation.Text,
                        AssessmentMethods = TbCompetMethods.Text
                    };
                    _db.GetContext().GeneralCompetencies.Add(generalCompetencies);
                    _db.GetContext().SaveChanges();
                    MessageBox.Show("Вы успешно добавили компетенцию!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }
    }
}
