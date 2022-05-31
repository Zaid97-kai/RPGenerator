using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
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
using _db = RPTest.Models.DBModel;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;



namespace RPTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkProgramPage.xaml
    /// </summary>
    public partial class WorkProgramPage : System.Windows.Controls.Page
    {
        private Classes.WorkProgram _workProgram;

        private List<string> _auditory = new List<string>() { "Аудитория для занятий лекционного типа должна быть оснащена:", "Аудитория для занятий лабораторными работами должна быть оснащена" };
        //private List<string> _specialtyCodes = new List<string>() { "09.02.06 Сетевое и системное администрирование", "09.02.07 Информационные системы и программирование", "10.02.05 Обеспечение информационной безопасности автоматизированных систем" };
        //private BinaryFormatter _formatter = new BinaryFormatter();
        /// <summary>
        /// Конструктор класса WorkProgramPage
        /// </summary>
        public WorkProgramPage()
        {
            InitializeComponent();
            _workProgram = new Classes.WorkProgram();
            CbCode.ItemsSource = _db.GetContext().Specialty.ToList();
        }
        /// <summary>
        /// Выбор кода специальности из выпадающего списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Models.Proffessional_Module proffessional_Module in _db.GetContext().Proffessional_Module.ToList())
            {
                if (proffessional_Module.Id_Specialty == ((Models.Specialty)CbCode.SelectedItem).Id)
                {
                    CbNamePM.ItemsSource = proffessional_Module.Specialty.Proffessional_Module.ToList();
                    QualName.Text = proffessional_Module.Specialty.Qualification;
                }
            }
            _workProgram.Specialization = ((Models.Specialty)CbCode.SelectedItem).Code;
            TbSpecialtyApprovalSheet.Text = _workProgram.Specialization;
            _workProgram.Qualification = QualName.Text;

        }

        private void CbNamePM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _workProgram.NameProfessonalModule = ((Models.Proffessional_Module)CbNamePM.SelectedItem).Name;
        }

        private void TbAuthor_TextChanged(object sender, TextChangedEventArgs e)
        {
            _workProgram.TeacherName = TbAuthor.Text;
        }


        private void BtnAddComp_Click(object sender, RoutedEventArgs e)
        {
            Classes.Competencies competencies = new Classes.Competencies() { Code = TbCodeComp.Text, Description = TbDescComp.Text };
            _workProgram.Competencies.Add(competencies);
            DgCompCode.ItemsSource = _workProgram.Competencies;
            DgCompDesc.ItemsSource = _workProgram.Competencies;
            DgCompCode.Items.Refresh();
            DgCompDesc.Items.Refresh();



        }

        private void BtnDelComp_Click(object sender, RoutedEventArgs e)
        {
            _workProgram.Competencies.Remove(DgCompCode.SelectedItem as Classes.Competencies);
            DgCompCode.Items.Refresh();
        }

        private void BtnDelProfComp_Click(object sender, RoutedEventArgs e)
        {
            _workProgram.ProfCompetencies.Remove(DgProfCompCode.SelectedItem as Classes.ProfCompetencies);
            DgProfCompCode.Items.Refresh();
        }

        private void BtnAddProfComp_Click(object sender, RoutedEventArgs e)
        {
            Classes.ProfCompetencies profCompetencies = new Classes.ProfCompetencies() { Code = TbProfCodeComp.Text, Description = TbProfDescComp.Text };
            _workProgram.ProfCompetencies.Add(profCompetencies);
            DgProfCompCode.ItemsSource = _workProgram.ProfCompetencies;
            DgProfCompDesc.ItemsSource = _workProgram.ProfCompetencies;
            DgProfCompCode.Items.Refresh();
            DgProfCompDesc.Items.Refresh();
        }

        private void BtnAddExpPractice_Click(object sender, RoutedEventArgs e)
        {

            Classes.ExpPractices expPractices = new Classes.ExpPractices() { ExpPractice = TbExpPractice.Text };
            _workProgram.ExpPractices.Add(expPractices);
            LbExpPractice.ItemsSource = _workProgram.ExpPractices;
            LbExpPractice.Items.Refresh();
        }

        private void BtnDeleteExpPractice_Click(object sender, RoutedEventArgs e)
        {
            _workProgram.ExpPractices.Remove(LbExpPractice.SelectedItem as Classes.ExpPractices);
            LbExpPractice.Items.Refresh();
        }

        private void BtnAddSkill_Click(object sender, RoutedEventArgs e)
        {
            Classes.Skills skills = new Classes.Skills() { Skill = TbSkill.Text };
            _workProgram.Skills.Add(skills);
            LbSkill.ItemsSource = _workProgram.Skills;
            LbSkill.Items.Refresh();
        }

        private void BtnDeleteSkill_Click(object sender, RoutedEventArgs e)
        {
            _workProgram.Skills.Remove(LbSkill.SelectedItem as Classes.Skills);
            LbSkill.Items.Refresh();
        }

        private void BtnAddKnowledge_Click(object sender, RoutedEventArgs e)
        {
            Classes.Knowledges knowledges = new Classes.Knowledges() { Knowledge = TbKnowledge.Text };
            _workProgram.Knowledges.Add(knowledges);
            LbKnowledge.ItemsSource = _workProgram.Knowledges;
            LbKnowledge.Items.Refresh();
        }

        private void BtnDeleteKnowledge_Click(object sender, RoutedEventArgs e)
        {
            _workProgram.Knowledges.Remove(LbKnowledge.SelectedItem as Classes.Knowledges);
            LbKnowledge.Items.Refresh();
        }

        private void BtnAddDis_Click(object sender, RoutedEventArgs e)
        {
            Classes.Disciplines disciplines = new Classes.Disciplines() { Discipline = TbDis.Text };
            _workProgram.Disciplines.Add(disciplines);
            LbDis.ItemsSource = _workProgram.Disciplines;
            LbDis.Items.Refresh();

        }

        private void BtnDeleteDis_Click(object sender, RoutedEventArgs e)
        {
            _workProgram.Disciplines.Remove(LbDis.SelectedItem as Classes.Disciplines);
            LbDis.Items.Refresh();
        }


        private void BtDeleteSource_Click(object sender, RoutedEventArgs e)
        {
            _workProgram.Sources.Remove(CbSource.SelectedItem as Classes.Sources);
            CbSource.Items.Refresh();
        }

        private void BtAddSource_Click(object sender, RoutedEventArgs e)
        {
            Classes.Sources sources = new Classes.Sources() { Author = TbAuthor.Text, Name = TbName.Text, PublishHouse = TbPublishHouse.Text, Type = TbType.Text, URL = TbURL.Text, City = TbCity.Text, Years = TbYears.Text, Pages = TbPages.Text, Date = TbDate.Text, AccessType = TbAccessType.Text };
            _workProgram.Sources.Add(sources);
            MessageBox.Show(Convert.ToString(_workProgram.Sources.Count));
            CbSource.ItemsSource = _workProgram.Sources;
            CbSource.Items.Refresh();
        }

        /// <summary>
        /// Добавление первого раздела (ОБЩАЯ ХАРАКТЕРИСТИКА РАБОЧЕЙ ПРОГРАММЫ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ)
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private void InsertChapterFirst(Word.Document document)
        {
            InsertSimpleRangeBoldCenterAlignment(document, "1. ОБЩАЯ ХАРАКТЕРИСТИКА РАБОЧЕЙ ПРОГРАММЫ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ" + "\n" + _workProgram.NameProfessonalModule + "\n" + "1.1. Область применения программы");
            InsertSimpleRangeSelectedAlignment(document, "Программа профессионального модуля является частью основной профессиональной образовательной программы по специальности СПО: " + _workProgram.Specialization, Word.WdParagraphAlignment.wdAlignParagraphThaiJustify);
            InsertSimpleRangeBoldCenterAlignment(document, "1.2. Цели и задачи учебной дисциплины – требования к результатам освоения профессионального модуля");
            InsertSimpleRangeSelectedAlignment(document, "В результате изучения профессионального модуля студент должен освоить основной вид деятельности " + _workProgram.NameProfessonalModule + " и соответствующие ему общие компетенции и профессиональные компетенции:", Word.WdParagraphAlignment.wdAlignParagraphThaiJustify);

            InsertSimpleRangeBoldCenterAlignment(document, "1.2.1. Перечень общих компетенций");
            InsertSimpleTableRightAligment(document, "Таблица 1.");
            InsertGeneralCompetetionTable(document);
            InsertPageBreak(document);

            InsertSimpleRangeBoldCenterAlignment(document, "\n" + "1.2.2. Перечень профессиональных компетенций");
            InsertSimpleTableRightAligment(document, "Таблица 2.");
            InsertProfessionalCompetetionTable(document);

            InsertSimpleRangeBoldCenterAlignment(document, "\n" + "В результате освоения профессионального модуля студент должен:");
            InsertSimpleTableRightAligment(document, "Таблица 3.");
            InsertKnowledgeTable(document);

            InsertSimpleRangeBoldCenterAlignment(document, "1.3 Количество часов, отводимое на освоение профессионального модуля");
            InsertSimpleRangeSelectedAlignment(document, "Всего часов - " + "" + "\n" + "Из них на освоение МДК - " + "" + "\n" + "На практики, в том числе учебную - " + "" + "\n" + "и производственную – " + "" + "\n" + "самостоятельная работа – " + "", Word.WdParagraphAlignment.wdAlignParagraphLeft);


            InsertPageBreak(document);
            //InsertSectionBreak(document);
        }
        /// <summary>
        /// Добавление второго раздела (СТРУКТУРА И СОДЕРЖАНИЕ УЧЕБНОЙ ДИСЦИПЛИНЫ)
        /// </summary>
        /// <param name = "document" > Ссылка на редактируемый документ</param>///
        private void InsertChapterSecond(Word.Document document)
        {
            InsertSimpleRangeBoldCenterAlignment(document, "2. СТРУКТУРА И СОДЕРЖАНИЕ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ" + "\n" + "2.1. Структура профессионального модуля");
            InsertSimpleTableRightAligment(document, "Таблица 4.");
            InsertStructurePMTable(document);
            //InsertSectionBreak(document);
            InsertPageBreak(document);

            InsertSimpleRangeBoldCenterAlignment(document, "2.2. Тематический план и содержание профессионального модуля (ПМ)");
            InsertSimpleTableRightAligment(document, "Таблица 5.");
            InsertTematicPlanTable(document);
            //InsertSectionBreak(document);
            InsertPageBreak(document);
        }

        /// <summary>
        /// Добавление третьего раздела (УСЛОВИЯ РЕАЛИЗАЦИИ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ)
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private void InsertChapterThird(Word.Document document)
        {
            InsertSimpleRangeBoldCenterAlignment(document, "3. УСЛОВИЯ РЕАЛИЗАЦИИ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ" + "\n" + "3.1. Для реализации программы профессионального модуля должны быть предусмотрены следующие специальные помещения:");
            InsertSimpleRangeSelectedAlignment(document, "1. Аудитория для занятий лекционного типа оснащенная необходимым оборудованием:" + "\n" + "2. Лаборатория программного обеспечения компьютерных сетей, программирования и баз данных для занятий лабораторного типа, оснащенная необходимым оборудованием и программным обеспечением:" + "\n" + "Программное обеспечение общего и профессионального назначения, в том числе включающее в себя следующее ПО:", WdParagraphAlignment.wdAlignParagraphJustify);
            InsertPageBreak(document);

            InsertSimpleRangeBoldCenterAlignment(document, "3.2. Информационное обеспечение обучения" + "\n" + "Основные источники:");
            for (int i = 0; i <_workProgram.Sources.Count; i++)
            {
                InsertSimpleRangeSelectedAlignment(document,  _workProgram.Sources[i].Author + " " + _workProgram.Sources[i].Name + " - " + _workProgram.Sources[i].PublishHouse + " , " + _workProgram.Sources[i].Years + ". - " + _workProgram.Sources[i].Pages + " с. - Текст: " + _workProgram.Sources[i].Type + " // " + _workProgram.Sources[i].URL + "(дата обращения: " + _workProgram.Sources[i].Date + "). - Режим доступа : " + _workProgram.Sources[i].AccessType, WdParagraphAlignment.wdAlignParagraphJustify);
            }
            
            InsertPageBreak(document);

            /*InsertSimpleRangeBoldCenterAlignment(document, "Дополнительные источники:");
            InsertSimpleRangeSelectedAlignment(document, "ИСТОЧНИКИ", WdParagraphAlignment.wdAlignParagraphJustify);
            InsertPageBreak(document);*/

        }

        /// <summary>
        /// Добавление четвертого раздела (КОНТРОЛЬ И ОЦЕНКА РЕЗУЛЬТАТОВ ОСВОЕНИЯ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ)
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private void InsertChapterFourth(Word.Document document)
        {
            InsertSimpleRangeBoldCenterAlignment(document, "4. КОНТРОЛЬ И ОЦЕНКА РЕЗУЛЬТАТОВ ОСВОЕНИЯ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ");
            InsertSimpleRangeSelectedAlignment(document, "Контроль и оценка результатов освоения учебной дисциплины осуществляется преподавателем в процессе практических занятий и лабораторных работ, тестирования, а также выполнения обучающимися индивидуальных заданий, проектов, исследований.", WdParagraphAlignment.wdAlignParagraphJustify);
            InsertSimpleTableRightAligment(document, "Таблица 6.");
            InsertMarksTable(document);
            InsertPageBreak(document);
        }
        /// <summary>
        /// Добавление пятого раздела (Лист утверждения рабочей программы профессионального модуля на учебный год)
        /// </summary>
        /// <param name="document"></param>
        private static void InsertChapterFifth(Document document)
        {
            InsertSimpleRangeBoldCenterAlignment(document, "Лист утверждения рабочей программы профессионального модуля на учебный год");
            InsertSimpleRangeSelectedAlignment(document, "Рабочая программа учебной дисциплины утверждена на ведение учебного процесса в учебном году:", WdParagraphAlignment.wdAlignParagraphJustify);
            InsertYearsTable(document);
            InsertPageBreak(document);

            InsertSimpleRangeBoldCenterAlignment(document, "Лист регистрации изменений и дополнений");
            InsertChangesTable(document);
            InsertPageBreak(document);
        }

        /// <summary>
        /// Добавление таблицы общих компетенций
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private void InsertGeneralCompetetionTable(Word.Document document)
        {
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, _workProgram.Competencies.Count + 1, 2);
            approvalTable.Borders.InsideLineStyle = approvalTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            approvalTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = approvalTable.Cell(1, 1).Range;
            cellRange.Columns.Width = 100;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Код";
            cellRange.Font.Bold = 1;
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Font.Bold = 1;
            cellRange.Text = "Наименование общих компетенций";
            cellRange.Columns.Width = 350;
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            

            for(int i=0; i<_workProgram.Competencies.Count; i++)
            {
                cellRange = approvalTable.Cell(i+2, 1).Range;
                cellRange.Columns.Width = 100;
                cellRange.Font.Name = "Times New Roman";
                cellRange.Font.Size = 14;
                cellRange.Text = _workProgram.Competencies[i].Code;
                cellRange.Font.Bold = 1;
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                cellRange = approvalTable.Cell(i+2, 2).Range;
                cellRange.Font.Name = "Times New Roman";
                cellRange.Font.Size = 14;
                cellRange.Font.Bold = 1;
                cellRange.Text = _workProgram.Competencies[i].Description;
                cellRange.Columns.Width = 350;
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
        }

        /// <summary>
        /// Добавление таблицы профессиональных компетенций
        /// </summary>
        /// <param name="document">Загружаемый документ</param>
        private void InsertProfessionalCompetetionTable(Word.Document document)
        {
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, _workProgram.Competencies.Count + 1, 2);
            approvalTable.Borders.InsideLineStyle = approvalTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            approvalTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = approvalTable.Cell(1, 1).Range;
            cellRange.Columns.Width = 100;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Код";
            cellRange.Font.Bold = 1;
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Font.Bold = 1;
            cellRange.Text = "Наименование видов деятельности и профессиональных компетенций";
            cellRange.Columns.Width = 350;
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < _workProgram.ProfCompetencies.Count; i++)
            {
                cellRange = approvalTable.Cell(i + 2, 1).Range;
                cellRange.Columns.Width = 100;
                cellRange.Font.Name = "Times New Roman";
                cellRange.Font.Size = 14;
                cellRange.Text = _workProgram.ProfCompetencies[i].Code;
                cellRange.Font.Bold = 1;
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                cellRange = approvalTable.Cell(i + 2, 2).Range;
                cellRange.Font.Name = "Times New Roman";
                cellRange.Font.Size = 14;
                cellRange.Font.Bold = 1;
                cellRange.Text = _workProgram.ProfCompetencies[i].Description;
                cellRange.Columns.Width = 350;
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
        }

        private void InsertKnowledgeTable(Word.Document document)
        {
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, 3, 2);
            approvalTable.Borders.InsideLineStyle = approvalTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            approvalTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = approvalTable.Cell(1, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Иметь практический опыт";
            cellRange.Font.Bold = 1;
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(2, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Font.Bold = 1;
            cellRange.Text = "уметь";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(3, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Font.Bold = 1;
            cellRange.Text = "знать";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(1, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            foreach (Classes.ExpPractices u in _workProgram.ExpPractices)
            {
                cellRange.Text += u.ExpPractice;
            }
            cellRange.Font.Bold = 1;
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(2, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            foreach (Classes.Skills u in _workProgram.Skills)
            {
                cellRange.Text += u.Skill;
            }
            cellRange.Font.Bold = 1;
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(3, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            foreach (Classes.Knowledges u in _workProgram.Knowledges)
            {
                cellRange.Text += u.Knowledge;
            }
            cellRange.Font.Bold = 1;
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        }
        /// <summary>
        /// Добавление таблицы нагрузок
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private void InsertStructurePMTable(Word.Document document)
        {
            //Word.Document document1 = document;
            //document1.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, _workProgram.Disciplines.Count+4, 9);

            approvalTable.Cell(1, 1).Merge(approvalTable.Cell(3, 1));
            approvalTable.Cell(1, 2).Merge(approvalTable.Cell(3, 2));
            approvalTable.Cell(1, 9).Merge(approvalTable.Cell(3, 9));
            approvalTable.Cell(1, 3).Merge(approvalTable.Cell(3, 3));
            approvalTable.Cell(1, 4).Merge(approvalTable.Cell(1, 8));
            approvalTable.Cell(2, 4).Merge(approvalTable.Cell(2, 6));
            approvalTable.Cell(2, 5).Merge(approvalTable.Cell(2, 6));




            approvalTable.Borders.InsideLineStyle = approvalTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            approvalTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;


            cellRange = approvalTable.Cell(1, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 12;
            cellRange.Text = "Коды профессиональных общих компетенций";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 12;
            cellRange.Text = "Наименования разделов профессионального модуля";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 3).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 12;
            cellRange.Text = "Суммарный объем нагрузки, час.";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 5).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 12;
            cellRange.Text = "Самостоятельная работа";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(1, 4).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 12;
            cellRange.Text = "Занятия во взаимодействии с преподавателем, час.";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(2, 4).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 12;
            cellRange.Text = "Обучение по МДК, в час.";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(2, 5).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 12;
            cellRange.Text = "Практики";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(3, 4).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 12;
            cellRange.Text = "всего, часов";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(3, 5).Range;

            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 12;
            cellRange.Text = "Лабораторных и практических занятий";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(3, 6).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 12;
            cellRange.Text = "Курсовых работ (проектов)";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(3, 7).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "учебная, часов";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(3, 8).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 12;
            cellRange.Text = "производственная, часов";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            
            for (int i = 0; i < _workProgram.Disciplines.Count; i++)
            {
                cellRange = approvalTable.Cell(i + 4, 2).Range;
                cellRange.Columns.Width = 100;
                cellRange.Font.Name = "Times New Roman";
                cellRange.Font.Size = 12;
                cellRange.Text = "Раздел " + Convert.ToString(i+1) +"\n" + _workProgram.Disciplines[i].Discipline;
                cellRange.Font.Bold = 1;
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }

        }


        public void InsertTematicPlanTable(Word.Document document)
        {
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, 11, 3);
            approvalTable.Cell(3, 1).Merge(approvalTable.Cell(3, 3));
            approvalTable.Cell(4, 1).Merge(approvalTable.Cell(7, 1));
            approvalTable.Cell(8, 1).Merge(approvalTable.Cell(8, 2));
            approvalTable.Cell(9, 1).Merge(approvalTable.Cell(9, 2));
            approvalTable.Cell(10, 1).Merge(approvalTable.Cell(10, 2));
            approvalTable.Cell(11, 1).Merge(approvalTable.Cell(11, 2));

            approvalTable.Borders.InsideLineStyle = approvalTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            approvalTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = approvalTable.Cell(1, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Наименование разделов профессионального модуля (ПМ), междисциплинарных курсов (МДК) и тем";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Содержание учебного материала, лабораторных работ и практических занятий, самостоятельной работы обучающихся, курсовой работы(проект)";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 3).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Объем часов";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(2, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "1";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(2, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "2";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(2, 3).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "3";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(4, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Тема 1.1.";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(4, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Содержание";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(4, 3).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(8, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Промежуточная аттестация (другая форма контроля)";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(8, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(9, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Всего";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(9, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(10, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Практики";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(10, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(11, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Всего";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(10, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

        }

        /// <summary>
        /// Добавление систем оценивания для компетенций
        /// </summary>
        /// <param name="document"></param>
        private void InsertMarksTable(Document document)
        {
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, _workProgram.ProfCompetencies.Count + _workProgram.Competencies.Count+1, 3);
            approvalTable.Cell(2, 1).Merge(approvalTable.Cell(2, 3));

            approvalTable.Borders.InsideLineStyle = approvalTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            approvalTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = approvalTable.Cell(1, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Код и наименование профессиональных и общих компетенций, формируемых в рамках модуля";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Критерии оценки";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 3).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Методы оценки";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(2, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Раздел 1. ";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for(int i = 0; i<_workProgram.Competencies.Count; i++)
            {
                cellRange = approvalTable.Cell(i+3, 1).Range;
                cellRange.Font.Name = "Times New Roman";
                cellRange.Font.Size = 14;
                cellRange.Text = _workProgram.Competencies[i].Code;
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
            for (int i = 0; i < _workProgram.ProfCompetencies.Count; i++)
            {
                cellRange = approvalTable.Cell((i + 3) + _workProgram.Competencies.Count, 1).Range;
                cellRange.Font.Name = "Times New Roman";
                cellRange.Font.Size = 14;
                cellRange.Text = _workProgram.ProfCompetencies[i].Code;
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }

        }

        private static void InsertYearsTable(Document document)
        {
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, 5, 2);

            approvalTable.Borders.InsideLineStyle = approvalTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            approvalTable.Borders.InsideLineWidth = approvalTable.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth225pt;
            approvalTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;


            Word.Range cellRange;

            cellRange = approvalTable.Cell(1, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "Учебный год";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Bold = 1;
            cellRange.Text = "«Одобрена»" + "\n" + "Председатель УМК отделения СПО";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(2, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "20__ / 20__";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(3, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "20__ / 20__";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(4, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "20__ / 20__";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(5, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "20__ / 20__";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        }

        private static void InsertChangesTable(Document document)
        {
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, 7, 6);

            approvalTable.Borders.InsideLineStyle = approvalTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            approvalTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;


            Microsoft.Office.Interop.Word.Range cellRange;

            cellRange = approvalTable.Cell(1, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "№ изменения";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Дата внесения изменения, проведения ревизии";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(1, 3).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Номера листов";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 4).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Документ, на основании которого внесено изменение";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(1, 5).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Краткое содержание изменения";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 6).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Ф.И.О. подпись";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(2, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "1";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(2, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "2";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(2, 3).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "3";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(2, 4).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "4";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(2, 5).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "5";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(2, 6).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "6";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        }

        /// <summary>
        /// Добавление страницы с содержанием
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private static void InsertThirdPage(Word.Document document)
        {
            InsertSimpleRangeBoldCenterAlignment(document, "СОДЕРЖАНИЕ" + "\n");
            InsertSimpleRangeSelectedAlignment(document, "1. ОБЩАЯ ХАРАКТЕРИСТИКА РАБОЧЕЙ ПРОГРАММЫ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ" + "\n" + "2. СТРУКТУРА И СОДЕРЖАНИЕ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ" + "\n" + "3. УСЛОВИЯ РЕАЛИЗАЦИИ ПРОГРАММЫ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ" + "\n" + "4. КОНТРОЛЬ И ОЦЕНКА РЕЗУЛЬТАТОВ ОСВОЕНИЯ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ" + "\n", Word.WdParagraphAlignment.wdAlignParagraphLeft);
            InsertPageBreak(document);
        }
        /// <summary>
        /// Добавление второй страницы
        /// </summary>
        /// <param name="document"Ссылка на редактируемый документ</param>
        private void InsertSecondPage(Word.Document document)
        {
            InsertSimpleRangeSelectedAlignment(document, "Составлена в соответствии с требованиями основной профессиональной образовательной программы ФГОС СПО по специальности " + _workProgram.Specialization + " и в соответствии с учебным планом специальности " + _workProgram.Specialization + "    утвержденным ученым советом КНИТУ – КАИ «__» ________ 20__г. протокол №__." + "\n", Word.WdParagraphAlignment.wdAlignParagraphThaiJustify);
            InsertSimpleRangeSelectedAlignment(document, "Рабочую программу учебной дисциплины разработал(а):", Word.WdParagraphAlignment.wdAlignParagraphJustify);
            InsertSimpleRangeSelectedAlignment(document, "\n" + "Преподаватель СПО ИКТЗИ " + _workProgram.TeacherName + "\n", Word.WdParagraphAlignment.wdAlignParagraphThaiJustify);
            InsertApprovalTable(document);
            InsertPageBreak(document);
        }
        /// <summary>
        /// Добавление титульного листа
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private void InsertTitlePage(Word.Document document)
        {
            InsertSimpleRangeBoldCenterAlignment(document, "федеральное государственное бюджетное образовательное учреждение высшего образования «Казанский национальный исследовательский технический университет им. А.Н.Туполева - КАИ» (КНИТУ - КАИ)" + "\n");
            InsertSimpleRangeCenterAlignment(document, "Институт компьютерных технологий и защиты информации" + "\n\n" + "Отделение СПО ИКТЗИ «Колледж информационных технологий»" + "\n");
            InsertSimpleRangeSelectedAlignment(document, "УТВЕРЖДАЮ" + "\n" + "Проректор по ОДиВР" + "\n" + "______________А.А.Лопатин" + "\n" + "_____________________2022 г." + "\n" + "Регистрационный номер _______" + "\n\n\n", Word.WdParagraphAlignment.wdAlignParagraphRight);
            InsertSimpleRangeBoldCenterAlignment(document, "РАБОЧАЯ ПРОГРАММА" + "\n" + "профессионального модуля" + "\n");
            InsertSimpleRangeCenterAlignment(document, "дисциплины " + _workProgram.NameProfessonalModule + "\n" + "для специальности " + _workProgram.Specialization + "\n\n" + "Квалификация: "+ _workProgram.Qualification + "\n\n\n\n\n\n");
            InsertSimpleRangeCenterAlignment(document, "Казань " + "2022");
        }
        /// <summary>
        /// Добавление таблицы согласования
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private static void InsertApprovalTable(Word.Document document)
        {
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, 5, 5);
            approvalTable.Borders.InsideLineStyle = approvalTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            approvalTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = approvalTable.Cell(1, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Согласование";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(2, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "ОДОБРЕНА";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(3, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "ОДОБРЕНА";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(4, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "СОГЛАСОВАНА";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(5, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "СОГЛАСОВАНА";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(1, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Наименования подразделения";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(2, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Рецензент (Эксперт)";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(3, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "ПЦК отделения СПО";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(4, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Научно-техническая библиотека";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(5, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "УМУ";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(1, 3).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Дата";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(1, 4).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "№ протокола";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(1, 5).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Подпись";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(2, 5).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "\n__________  директор СПО ИКТЗИ";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(3, 5).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "\n___________ председатель цикловой комиссии";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(4, 5).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "\n___________ Директор/зам.директора НТБ";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(5, 5).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "\n___________ Начальник УМУ";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        }
        /// <summary>
        /// Добавление разрыва страницы
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private static void InsertPageBreak(Word.Document document)
        {
            Word.Paragraph paragraph = document.Paragraphs.Add();
            Word.Range range = paragraph.Range;
            range.InsertBreak(Word.WdBreakType.wdPageBreak);

        }
        private static void InsertSectionBreak(Document document)
        {
            Word.Paragraph paragraph = document.Paragraphs.Add();
            Word.Range range = paragraph.Range;
            range.InsertBreak(WdBreakType.wdSectionBreakNextPage);
        }
        /// <summary>
        /// Добавление параграфа текста (жирное начертание, выравнивание по центру)
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        /// <param name="insertedText">Вставляемый текст</param>
        private static void InsertSimpleRangeBoldCenterAlignment(Word.Document document, string insertedText)
        {
            Word.Paragraph paragraph = document.Paragraphs.Add();
            Word.Range range = paragraph.Range;
            range.Font.Color = Word.WdColor.wdColorBlack;
            range.Bold = 1;
            range.Font.Size = 14;
            range.Font.Name = "Times New Roman";
            range.Text = insertedText;
            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            range.InsertParagraphAfter();
        }
        /// <summary>
        /// Добавление параграфа текста (обычное начертание, выравнивание по центру)
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        /// <param name="insertedText">Вставляемый текст</param>
        private static void InsertSimpleRangeCenterAlignment(Word.Document document, string insertedText)
        {
            Word.Paragraph paragraph = document.Paragraphs.Add();
            //paragraph.LineSpacing = 1.5f;
            Word.Range range = paragraph.Range;
            range.Font.Color = Word.WdColor.wdColorBlack;
            range.Font.Size = 14;
            range.Font.Name = "Times New Roman";
            range.Text = insertedText;
            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            range.InsertParagraphAfter();
        }
        /// <summary>
        /// Добавление параграфа текста с выбранным выравниванием
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        /// <param name="insertedText">Вставляемый текст</param>
        /// <param name="wdParagraphAlignment">Формат выравнивания</param>
        private static void InsertSimpleRangeSelectedAlignment(Word.Document document, string insertedText, Word.WdParagraphAlignment wdParagraphAlignment)
        {
            Word.Paragraph paragraph = document.Paragraphs.Add();
            Word.Range range = paragraph.Range;
            range.Font.Color = Word.WdColor.wdColorBlack;
            range.Font.Size = 14;
            range.Font.Name = "Times New Roman";
            range.Text = insertedText;
            range.ParagraphFormat.Alignment = wdParagraphAlignment;
            // range.ParagraphFormat.Space15();
            range.InsertParagraphAfter();
        }

        /// <summary>
        /// Добавление табличной надписи справа
        /// </summary>
        /// <param name="document"></param>Ссылка на редактируемый документ
        /// <param name="insertedText"></param>Вставляемый текст
        private static void InsertSimpleTableRightAligment(Word.Document document, string insertedText)
        {
            Word.Paragraph paragraph = document.Paragraphs.Add();
            Word.Range range = paragraph.Range;
            range.Font.Color = Word.WdColor.wdColorBlack;
            range.Font.Size = 14;
            range.Font.Name = "Times New Roman";
            range.Text = insertedText;
            range.Italic = 1;
            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            range.InsertParagraphAfter();

        }

        private void FinallyButton_Click(object sender, RoutedEventArgs e)
        {
            var application = new Word.Application();
            Word.Document document = new Word.Document();

            InsertTitlePage(document);
            InsertSecondPage(document);
            InsertThirdPage(document);
            InsertChapterFirst(document);
            InsertChapterSecond(document);
            InsertChapterThird(document);
            InsertChapterFourth(document);
            InsertChapterFifth(document);

            application.Visible = true;
            document.SaveAs2(@"C:\Users\Artur\Desktop\Курсач\doc2.docx");
            document.Close();
        }
    }
}

