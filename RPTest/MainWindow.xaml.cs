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
    public partial class MainWindow : Window
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

            application.Visible = true;
            document.SaveAs2(@"C:\Users\zzmin\source\repos\RPTest\RPTest\doc1.docx");
            document.Close();
        }
        /// <summary>
        /// Добавление первого раздела (ОБЩАЯ ХАРАКТЕРИСТИКА РАБОЧЕЙ ПРОГРАММЫ УЧЕБНОЙ ДИСЦИПЛИНЫ)
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private static void InsertChapterFirst(Word.Document document)
        {
            InsertSimpleRangeBoldCenterAlignment(document, "1. ОБЩАЯ ХАРАКТЕРИСТИКА РАБОЧЕЙ ПРОГРАММЫ УЧЕБНОЙ ДИСЦИПЛИНЫ" + "\n" + "1.1. Место дисциплины в структуре программы подготовки специалистов среднего звена");
            InsertSimpleRangeSelectedAlignment(document, "Рабочая программа учебной дисциплины является частью программы подготовки специалистов среднего звена в соответствии с ФГОС СПО по специальности: " + "09.02.07 Информационные системы и программирование" + ". Дисциплина входит в " + "математический и общий естественнонаучный учебный цикл" + ".", Word.WdParagraphAlignment.wdAlignParagraphThaiJustify);
            InsertSimpleRangeBoldCenterAlignment(document, "1.2. Цели и планируемые результаты освоения");
            InsertCompetetionTable(document);
            InsertPageBreak(document);
        }
        /// <summary>
        /// Добавление таблицы компетенций
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private static void InsertCompetetionTable(Word.Document document)
        {
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table approvalTable = document.Tables.Add(tableRange, 2, 3);
            approvalTable.Borders.InsideLineStyle = approvalTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            approvalTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = approvalTable.Cell(1, 1).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Text = "Код";
            cellRange.Font.Bold = 1;
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 2).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Font.Bold = 1;
            cellRange.Text = "Умения";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            cellRange = approvalTable.Cell(1, 3).Range;
            cellRange.Font.Name = "Times New Roman";
            cellRange.Font.Size = 14;
            cellRange.Font.Bold = 1;
            cellRange.Text = "Знания";
            cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        }
        /// <summary>
        /// Добавление страницы с содержанием
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        private static void InsertThirdPage(Word.Document document)
        {
            InsertSimpleRangeBoldCenterAlignment(document, "СОДЕРЖАНИЕ" + "\n");
            InsertSimpleRangeSelectedAlignment(document, "1. Общая характеристика рабочей программы учебной дисциплины \n 2. Структура и примерное содержание учебной дисциплины \n 3. Условия реализации учебной дисциплины \n 4. Контроль и оценка результатов освоения учебной дисциплины \n 5. Возможности использования программы для других специальностей \n", Word.WdParagraphAlignment.wdAlignParagraphLeft);
            InsertPageBreak(document);
        }
        /// <summary>
        /// Добавление второй страницы
        /// </summary>
        /// <param name="document"Ссылка на редактируемый документ</param>
        private static void InsertSecondPage(Word.Document document)
        {
            InsertSimpleRangeSelectedAlignment(document, "Составлена в соответствии с требованиями основной профессиональной образовательной программы ФГОС СПО по специальности " + "09.02.07 Информационные системы и программирование " + "и в соответствии с учебным планом специальности " + "09.02.07 " + "утвержденным ученым советом КНИТУ – КАИ __________________________________________." + "\n", Word.WdParagraphAlignment.wdAlignParagraphThaiJustify);
            InsertSimpleRangeSelectedAlignment(document, "Рабочую программу учебной дисциплины разработал:", Word.WdParagraphAlignment.wdAlignParagraphLeft);
            InsertSimpleRangeSelectedAlignment(document, "Преподаватель СПО ИКТЗИ   " + "Валиева Г.Р." + "\n", Word.WdParagraphAlignment.wdAlignParagraphThaiJustify);
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
            InsertSimpleRangeSelectedAlignment(document, "УТВЕРЖДАЮ" + "\n" + "Проректор по ОДиВР" + "\n" + "______________А.А.Лопатин" + "\n" + "_____________________2020 г." + "\n" + "Регистрационный номер _______" + "\n\n\n", Word.WdParagraphAlignment.wdAlignParagraphRight);
            InsertSimpleRangeBoldCenterAlignment(document, "РАБОЧАЯ ПРОГРАММА" + "\n" + "дисциплины" + "\n");
            InsertSimpleRangeCenterAlignment(document, "КОД ДИСЦИПЛИНА" + "\n\n" + "для специальности 09.02.07 «Информационные системы и программирование»" + "\n\n" + "Квалификация выпускника: " + "программист" + "\n\n\n");
            InsertSimpleRangeCenterAlignment(document, "2020 " + "год");
            InsertPageBreak(document);
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
            cellRange.Text = "\n___________  директор СПО ИКТЗИ";
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
            range.InsertParagraphAfter();
        }
    }
}
