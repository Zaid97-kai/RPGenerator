using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using _db = RPTest.Models.DBModel;

namespace RPTest.Classes
{
    /*
    /// <summary>
    /// Временная дисциплина (со сгенерированными типами
    /// </summary>
    [Serializable]
    /*public class TemporaryDiscipline
    {
        public string Name;
        public string form;
        public int NumberSemestr;
        public List<Models.Knowledge> knowledges = new List<Models.Knowledge>();
        public List<Models.Skills> skills = new List<Models.Skills>();
        public List<Models.Competencies> competencies = new List<Models.Competencies>();
        //public Models.Kind_Of_Discipline kind;
        public Models.Proffessional_Module module;
        public Models.AcademicPlan academicPlan;
        /// <summary>
        /// Конструктор по умолчанию TemporaryDiscipline
        /// </summary>
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
            //this.kind = _db.GetContext().Kind_Of_Discipline.ToList().Where(k => k.Name == temporaryDisciplineText.kind).FirstOrDefault();
            this.module = _db.GetContext().Proffessional_Module.ToList().Where(m => m.Code == temporaryDisciplineText.module).FirstOrDefault();
            this.academicPlan = _db.GetContext().AcademicPlan.ToList().Where(a => a.PlanName == temporaryDisciplineText.academicPlan).FirstOrDefault();
            if (temporaryDisciplineText.knowledges.Count != 0)
            {
                foreach (string knowledge in temporaryDisciplineText.knowledges)
                {
                    this.knowledges.Add(new Models.Knowledge() { Name = knowledge});
                    //this.knowledges.AddRange(_db.GetContext().Knowledge.ToList().Where(k => k.Name == knowledge).ToList());
                }
            }
            if (temporaryDisciplineText.skills.Count != 0)
            {
                foreach (string skill in temporaryDisciplineText.skills)
                {
                    this.skills.Add(new Models.Skills() { Name = skill});
                    //this.skills.AddRange(_db.GetContext().Skills.ToList().Where(s => s.Name == skill).ToList());
                }
            }
            if (temporaryDisciplineText.competencies.Count != 0)
            {
                foreach (string competence in temporaryDisciplineText.competencies)
                {
                    this.competencies.AddRange(_db.GetContext().Competencies.ToList().Where(c => c.CompetenciesName == competence).ToList());
                }
            }*
        }
    }
    /// <summary>
    /// Временная дисциплина (со встроенными типами)
    /// </summary>
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
    }*/
}
