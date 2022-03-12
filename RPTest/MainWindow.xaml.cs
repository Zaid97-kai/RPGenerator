using Microsoft.Office.Interop.Word;
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
using Word = Microsoft.Office.Interop.Word;

namespace RPTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
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
            document.SaveAs2(@"C:\Users\Артур\Desktop\Курсач\doc1.docx");
            document.Close();
        }
        /// <summary>
        /// Добавление первого раздела (ОБЩАЯ ХАРАКТЕРИСТИКА РАБОЧЕЙ ПРОГРАММЫ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ)
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private static void InsertChapterFirst(Word.Document document)
        {
            InsertSimpleRangeBoldCenterAlignment(document, "1. ОБЩАЯ ХАРАКТЕРИСТИКА РАБОЧЕЙ ПРОГРАММЫ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ" + "\n" + "НАЗВАНИЕ МОДУЛЯ" + "\n" + "1.1. Область применения программы");
            InsertSimpleRangeSelectedAlignment(document, "Программа профессионального модуля является частью основной профессиональной образовательной программы по специальности СПО: " + "СПЕЦИАЛЬНОСТЬ", Word.WdParagraphAlignment.wdAlignParagraphThaiJustify);
            InsertSimpleRangeBoldCenterAlignment(document, "1.2. Цели и задачи учебной дисциплины – требования к результатам освоения профессионального модуля");
            InsertSimpleRangeSelectedAlignment(document, "В результате изучения профессионального модуля студент должен освоить основной вид деятельности " + "«НАЗВАНИЕ ПМ» " + "и соответствующие ему общие компетенции и профессиональные компетенции:", Word.WdParagraphAlignment.wdAlignParagraphThaiJustify);
            
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
            InsertSimpleRangeSelectedAlignment(document, "Всего часов - " + "КОЛВО"  + "\n" + "Из них на освоение МДК - " + "КОЛВО" + "\n" + "На практики, в том числе учебную - " + "KOLVO" + "\n" + "и производственную – " + "KOLVO" + "\n" + "самостоятельная работа – " + "KOLVO", Word.WdParagraphAlignment.wdAlignParagraphLeft);


            InsertPageBreak(document);
            //InsertSectionBreak(document);
        }
        /// <summary>
        /// Добавление второго раздела (СТРУКТУРА И СОДЕРЖАНИЕ УЧЕБНОЙ ДИСЦИПЛИНЫ)
        /// </summary>
        /// <param name = "document" > Ссылка на редактируемый документ</param>///
        private static void InsertChapterSecond(Word.Document document)
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
        private static void InsertChapterThird(Word.Document document)
        {
            InsertSimpleRangeBoldCenterAlignment(document, "3. УСЛОВИЯ РЕАЛИЗАЦИИ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ" + "\n" + "3.1. Для реализации программы профессионального модуля должны быть предусмотрены следующие специальные помещения:");
            InsertSimpleRangeSelectedAlignment(document, "1. Аудитория для занятий лекционного типа оснащенная необходимым оборудованием:" + "\n" + "2. Лаборатория программного обеспечения компьютерных сетей, программирования и баз данных для занятий лабораторного типа, оснащенная необходимым оборудованием и программным обеспечением:" + "\n" + "Программное обеспечение общего и профессионального назначения, в том числе включающее в себя следующее ПО:", WdParagraphAlignment.wdAlignParagraphJustify);
            InsertPageBreak(document);

            InsertSimpleRangeBoldCenterAlignment(document, "3.2. Информационное обеспечение обучения" + "\n" + "Основные источники:");
            InsertSimpleRangeSelectedAlignment(document, "ИСТОЧНИКИ", WdParagraphAlignment.wdAlignParagraphJustify);
            InsertPageBreak(document);

            InsertSimpleRangeBoldCenterAlignment(document, "Дополнительные источники:");
            InsertSimpleRangeSelectedAlignment(document, "ИСТОЧНИКИ", WdParagraphAlignment.wdAlignParagraphJustify);
            InsertPageBreak(document);

        }
        /// <summary>
        /// Добавление четвертого раздела (КОНТРОЛЬ И ОЦЕНКА РЕЗУЛЬТАТОВ ОСВОЕНИЯ ПРОФЕССИОНАЛЬНОГО МОДУЛЯ)
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private static void InsertChapterFourth(Word.Document document)
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
        private static void InsertGeneralCompetetionTable(Word.Document document)
        {
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, 2, 2);
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
        }

        /// <summary>
        /// Добавление таблицы профессиональных компетенций
        /// </summary>
        /// <param name="document">Загружаемый документ</param>
        private static void InsertProfessionalCompetetionTable(Word.Document document)
        {
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, 2, 2);
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
        }

        private static void InsertKnowledgeTable(Word.Document document)
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
        }
        /// <summary>
        /// Добавление таблицы нагрузок
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private static void InsertStructurePMTable(Word.Document document)
        {
            //Word.Document document1 = document;
            //document1.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, 4, 9);

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
            cellRange.Font.Size = 14;
            cellRange.Text = "Коды профессиональных общих компетенций";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Наименования разделов профессионального модуля";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 3).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Суммарный объем нагрузки, час.";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 5).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Самостоятельная работа";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(1, 4).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Занятия во взаимодействии с преподавателем, час.";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(2, 4).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Обучение по МДК, в час.";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(2, 5).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Практики";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(3, 4).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "всего, часов";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(3, 5).Range;

            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Лабораторных и практических занятий";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(3, 6).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Курсовых работ (проектов)";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            cellRange = approvalTable.Cell(3, 7).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "учебная, часов";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(3, 8).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "производственная, часов";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;


        }


        public static void InsertTematicPlanTable(Word.Document document)
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

            cellRange = approvalTable.Cell(11   , 1).Range;
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
        private static void InsertMarksTable(Document document)
        {
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, 3, 3);
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

            cellRange = approvalTable.Cell(3, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "ПК";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(3, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Оценки";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(3, 3).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Методы оценки";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
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


            Word.Range cellRange;

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
        private static void InsertSecondPage(Word.Document document)
        {
            InsertSimpleRangeSelectedAlignment(document, "Составлена в соответствии с требованиями основной профессиональной образовательной программы ФГОС СПО по специальности " + "НАЗВАНИЕ СПЕЦИАЛЬНОСТИ " + "и в соответствии с учебным планом специальности " + "КОД СПЕЦИАЛЬНОСТИ " + "утвержденным ученым советом КНИТУ – КАИ «__» ________ 20__г. протокол №__." + "\n", Word.WdParagraphAlignment.wdAlignParagraphThaiJustify);
            InsertSimpleRangeSelectedAlignment(document, "Рабочую программу учебной дисциплины разработал(а):", Word.WdParagraphAlignment.wdAlignParagraphJustify);
            InsertSimpleRangeSelectedAlignment(document, "\n" + "Преподаватель СПО ИКТЗИ " + "ФИО ПРЕПОДАВАТЕЛЯ" + "\n", Word.WdParagraphAlignment.wdAlignParagraphThaiJustify);
            InsertApprovalTable(document);
            InsertPageBreak(document);
        }
        /// <summary>
        /// Добавление титульного листа
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private static void InsertTitlePage(Word.Document document)
        {
            InsertSimpleRangeBoldCenterAlignment(document, "федеральное государственное бюджетное образовательное учреждение высшего образования «Казанский национальный исследовательский технический университет им. А.Н.Туполева - КАИ» (КНИТУ - КАИ)" + "\n");
            InsertSimpleRangeCenterAlignment(document, "Институт компьютерных технологий и защиты информации" + "\n\n" + "Отделение СПО ИКТЗИ «Колледж информационных технологий»" + "\n");
            InsertSimpleRangeSelectedAlignment(document, "УТВЕРЖДАЮ" + "\n" + "Проректор по ОДиВР" + "\n" + "______________А.А.Лопатин" + "\n" + "_____________________2022 г." + "\n" + "Регистрационный номер _______" + "\n\n\n", Word.WdParagraphAlignment.wdAlignParagraphRight);
            InsertSimpleRangeBoldCenterAlignment(document, "РАБОЧАЯ ПРОГРАММА" + "\n" + "профессионального модуля" + "\n");
            InsertSimpleRangeCenterAlignment(document, "дисциплины " + "КОД ДИСЦИПЛИНЫ" + "\n" + "для специальности " + "КОД СПЕЦИАЛЬНОСТИ" + "\n\n" + "Квалификация: НАЗВАНИЕ КВАЛИФИКАЦИИ" + "\n\n\n\n\n\n");
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

    }
}
