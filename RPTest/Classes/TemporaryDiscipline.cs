using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPTest.Classes
{
    [Serializable]
    public class TemporaryDiscipline
    {
        public string Name;
        public string form;
        public int NumberSemestr;
        public List<Models.Knowledge> knowledges = new List<Models.Knowledge>();
        public List<Models.Skills> skills = new List<Models.Skills>();
        public List<Models.Competencies> competencies = new List<Models.Competencies>();
        public Models.Kind_Of_Discipline kind;
        public Models.Proffessional_Module module;
        public Models.AcademicPlan academicPlan;
        public TemporaryDiscipline()
        {
        }
        /// <summary>
        /// Конструктор для обратного преобразования от TemporaryDisciplineText к TemporaryDiscipline
        /// </summary>
        /// <param name="temporaryDisciplineText">Временный класс Дисциплина с простейшими типами</param>
        public TemporaryDiscipline(TemporaryDisciplineText temporaryDisciplineText)
        {
            this.Name = temporaryDisciplineText.Name;
            this.form = temporaryDisciplineText.form;
            this.NumberSemestr = temporaryDisciplineText.NumberSemestr;
            this.kind = (new Models.DBModel()).Kind_Of_Discipline.ToList().Where(k => k.Name == temporaryDisciplineText.kind).FirstOrDefault();
            this.module = (new Models.DBModel()).Proffessional_Module.ToList().Where(m => m.Code == temporaryDisciplineText.module).FirstOrDefault();
            this.academicPlan = (new Models.DBModel()).AcademicPlan.ToList().Where(a => a.PlanName == temporaryDisciplineText.academicPlan).FirstOrDefault();
            if (knowledges.Count != 0)
            {
                foreach (var knowledge in temporaryDisciplineText.knowledges)
                {
                    this.knowledges = (new Models.DBModel()).Knowledge.ToList().Where(k => k.Name == knowledge).ToList();
                }
            }
            if (skills.Count != 0)
            {
                foreach (var skill in temporaryDisciplineText.skills)
                {
                    this.skills = (new Models.DBModel()).Skills.ToList().Where(s => s.Name == skill).ToList();
                }
            }
            if (competencies.Count != 0)
            {
                foreach (var competence in temporaryDisciplineText.competencies)
                {
                    this.competencies = (new Models.DBModel()).Competencies.ToList().Where(c => c.Description == competence).ToList();
                }
            }
        }
    }
    [Serializable]
    public class TemporaryDisciplineText
    {
        public List<string> knowledges = new List<string>();
        public List<string> skills = new List<string>();
        public List<string> competencies = new List<string>();

        public string Name;
        public string kind;
        public string module;
        public string form;
        public string academicPlan;
        public int NumberSemestr;
        public TemporaryDisciplineText()
        { }
        public TemporaryDisciplineText(List<Models.Knowledge> knowledges, List<Models.Skills> skills, List<Models.Competencies> competencies, string Name, Models.Kind_Of_Discipline kind, Models.Proffessional_Module module, string form, Models.AcademicPlan academicPlan, int NumberSemestr)
        {
            foreach (var knowledge in knowledges)
            {
                this.knowledges.Add(knowledge.Name);
            }
            foreach (var skill in skills)
            {
                this.skills.Add(skill.Name);
            }
            foreach (var competence in competencies)
            {
                this.competencies.Add(competence.CompetenciesName);
            }
            this.Name = Name;
            this.kind = kind.Name;
            this.module = module.Code;
            this.form = form;
            this.academicPlan = academicPlan.PlanName;
            this.NumberSemestr = NumberSemestr;
        }
    }
}
