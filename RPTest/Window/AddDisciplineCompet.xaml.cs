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
    /// Логика взаимодействия для AddDisciplineCompet.xaml
    /// </summary>
    public partial class AddDisciplineCompet : System.Windows.Window
    {
        public AddDisciplineCompet()
        {
            InitializeComponent();
            RefreshCompetencies();
            RefreshDiscipline();
        }
        private void RefreshCompetencies()
        {
            CbDisciplineGeneralCompet.Items.Clear();
            foreach (Models.GeneralCompetencies u in _db.GetContext().GeneralCompetencies)
            {
                CbDisciplineGeneralCompet.Items.Add(u);
            }
            CbDisciplineProfCompet.Items.Clear();
            foreach (Models.ProfessionalCompetencies u in _db.GetContext().ProfessionalCompetencies)
            {
                CbDisciplineProfCompet.Items.Add(u);
            }
        }
        private void RefreshDiscipline()
        {
            CbDiscipline.Items.Clear();
            foreach (Models.Discipline u in _db.GetContext().Discipline)
            {

                CbDiscipline.Items.Add(u);
            }
        }
        private void BtnAddDisciplineCompet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(CbDisciplineGeneralCompet.SelectedItem  != null)
                {
                    GeneralCompetencies generalCompetencies = _db.GetContext().GeneralCompetencies.FirstOrDefault(p => p.Id == ((GeneralCompetencies)CbDisciplineGeneralCompet.SelectedItem).Id);
                    Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.Id == ((Discipline)CbDiscipline.SelectedItem).Id);
                    Discipline_Competencies discipline_Competencies = new Discipline_Competencies();
                    discipline_Competencies.Id_Competencies = generalCompetencies.Id;
                    discipline_Competencies.Id_Discipline = discipline.Id;
                    _db.GetContext().Discipline_Competencies.Add(discipline_Competencies);
                    _db.GetContext().SaveChanges();
                    LbDisciplineGeneralCompet.Items.Add(generalCompetencies);
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
                    LbDisciplineProfCompet.Items.Add(professionalCompetencies);
                    CbDisciplineProfCompet.SelectedItem = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }

    }
}
