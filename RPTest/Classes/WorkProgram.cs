using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPTest.Classes
{
    [Serializable]
    /// <summary>
    /// Рабочая программа
    /// </summary>
    public partial class WorkProgram
    {
        /// <summary>
        /// Конструктор класса WorkProgram
        /// </summary>
        public WorkProgram()
        {
            Topics = new List<Topic>();
        }
        /// <summary>
        /// Наименование дисциплины
        /// </summary>
        public string NameDiscipline { get; set; }
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
        public List<string> Competencies { get; set; }
        /// <summary>
        /// Список знаний
        /// </summary>
        public List<string> Knowledge { get; set; }
        /// <summary>
        /// Список умений
        /// </summary>
        public List<string> Skills { get; set; }
        /// <summary>
        /// Часы на теоретическое обучение
        /// </summary>
        public int HoursTheoreticalTraining { get; set; }
        /// <summary>
        /// Часы на практическое обучение
        /// </summary>
        public int HoursPracticalTraining { get; set; }
        /// <summary>
        /// Часы на лабораторные занятия
        /// </summary>
        public int HoursLaboratoryTraining { get; set; }
        /// <summary>
        /// Часы на курсовую работу
        /// </summary>
        public int HoursCoursework { get; set; }
        /// <summary>
        /// Часы на самостоятельную работу
        /// </summary>
        public int HoursSelfStudy { get; set; }
        /// <summary>
        /// Часы на промежуточную аттестацию
        /// </summary>
        public int HoursAttestation { get; set; }
        /// <summary>
        /// Подвал РПД
        /// </summary>
        public string Footer { get; set; }
        /// <summary>
        /// Темы РПД
        /// </summary>
        public List<Topic> Topics { get; set; }
        /// <summary>
        /// Год создания РПД
        /// </summary>
        public string Year { get; set; }
    }
    [Serializable]
    /// <summary>
    /// Тема
    /// </summary>
    public class Topic
    {
        public int NumberTopic { get; set; }
        public string TopicName { get; set; }
    }
}
