using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPTest.Classes
{
    /// <summary>
    /// Рабочая программа
    /// </summary>
    public partial class WorkProgram
    {
        /// <summary>
        /// Наименование дисциплины
        /// </summary>
        public string NameProfessonalModule { get; set; }
        /// <summary>
        /// Специальность
        /// </summary>
        public string Specialization { get; set; }
        /// <summary>
        /// Дата утверждения
        /// </summary>
        public string DateApproval { get; set; }
        /// <summary>
        /// Номер протокола
        /// </summary>
        public int ProtocolNumber { get; set; }
        public string Qualification { get; set; }
        /// <summary>
        /// Преподаватель-разработчик рабочей программы
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// Тип дисциплины
        /// </summary>
        public string TypeDiscipline { get; set; }
        /// <summary>
        /// Список компетенций
        /// </summary>
        public List<Competencies> Competencies { get; set; }
        public List<ExpPractices> ExpPractices { get; set; }
        public List<Skills> Skills { get; set; }
        public List<Knowledges> Knowledges { get; set; }
        /// <summary>
        /// Профф.компетенции
        /// </summary>
        public List<ProfCompetencies> ProfCompetencies { get; set; }
        public List <Disciplines> Disciplines { get; set; }
        public List<Auditories> Auditories { get; set; }
        public List<Softwares> Softwares { get; set; }
        public List<Equipments> Equipments { get; set; }
        public List<Sources> Sources { get; set; }
        /// <summary>
        /// Часы на теоретическое обучение
        /// </summary>

        public WorkProgram()
        {
            Competencies = new List<Competencies>();
            ProfCompetencies = new List<ProfCompetencies>();
            ExpPractices = new List<ExpPractices>();
            Skills = new List<Skills>();
            Knowledges = new List<Knowledges>();
            Disciplines = new List<Disciplines>();
            Auditories = new List<Auditories>();
            Equipments = new List<Equipments>();
            Softwares = new List<Softwares>();
            Sources = new List<Sources>();
        }
    }
    /// <summary>
    /// Тема
    /// </summary>
    public class Topic
    {
        public int NumberTopic { get; set; }
        public string TopicName { get; set; }
    }
    public class Auditories
    {
        public string Auditory { get; set; }
        public string Equipment { get; set; }
        public string Software { get; set; }
    }
    public class Equipments
    {
        public string Equipment { get; set; }
    }
    public class Softwares
    {
        public string Software { get; set; }
    }


    public class Competencies
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class ProfCompetencies
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class ExpPractices
    {
        public string ExpPractice { get; set; }
        

    }
    public class Skills
    {
        public string Skill { get; set; }
    }
    public class Knowledges
    {
        public string Knowledge { get; set; }
    }
    public class Disciplines
    {
        public string Discipline { get; set; }
        public List<string> Competenciees { get; set; }
    }
    public class Sources
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string PublishHouse { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public string City { get; set; }
        public string Years { get; set; }
        public string Pages { get; set; }
        public string Date { get; set; }
        public string AccessType { get; set; }
    }

}

