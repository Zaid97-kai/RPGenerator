using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPTest.Classes
{
    [Serializable]
    internal class TemporaryDiscipline
    {
        public List<Models.Knowledge> knowledges = new List<Models.Knowledge>();
        public List<Models.Skills> skills = new List<Models.Skills>();
        public List<Models.Competencies> competencies = new List<Models.Competencies>();

        public string Name;
        public Models.Kind_Of_Discipline kind;
        public Models.Proffessional_Module module;
        public Models.Assessment_Form form;
        public Models.AcademicPlan academicPlan;
        public int NumberSemestr;

        public TemporaryDiscipline()
        {
        }
    }
}
