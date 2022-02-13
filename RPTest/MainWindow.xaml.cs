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

            InsertSimpleRangeBoldCenterAlignment(document, "федеральное государственное бюджетное образовательное учреждение высшего образования «Казанский национальный исследовательский технический университет им. А.Н.Туполева - КАИ» (КНИТУ - КАИ)" + "\n");

            InsertSimpleRangeCenterAlignment(document, "Институт компьютерных технологий и защиты информации" + "\n\n" + "Отделение СПО ИКТЗИ «Колледж информационных технологий»" + "\n");

            InsertSimpleRangeRightAlignment(document, "УТВЕРЖДАЮ" + "\n" + "Проректор по ОДиВР" + "\n" + "______________А.А.Лопатин" + "\n" + "_____________________2020 г." + "\n" + "Регистрационный номер _______" + "\n\n\n");

            InsertSimpleRangeBoldCenterAlignment(document, "РАБОЧАЯ ПРОГРАММА" + "\n" + "дисциплины" + "\n");

            InsertSimpleRangeCenterAlignment(document, "КОД ДИСЦИПЛИНА" + "\n\n" + "для специальности 09.02.07 «Информационные системы и программирование»" + "\n\n" + "Квалификация выпускника: " + "программист" + "\n\n\n");

            InsertSimpleRangeCenterAlignment(document, "2020 " + "год");
            InsertPageBreak(document);

            InsertSimpleRangeDistributeAlignment(document, "Составлена в соответствии с требованиями основной профессиональной образовательной программы ФГОС СПО по специальности " + "09.02.07 Информационные системы и программирование " + "и в соответствии с учебным планом специальности " + "09.02.07 " + "утвержденным ученым советом КНИТУ – КАИ __________________________________________.");

            application.Visible = true;
            document.SaveAs2(@"C:\Users\zzmin\source\repos\RPTest\RPTest\doc1.docx");
            document.Close();
        }
        /// <summary>
        /// Добавление разрыва страницы
        /// </summary>
        /// <param name="document"></param>
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
        /// Добавление параграфа текста (обычное начертание, выравнивание по правому краю)
        /// </summary>
        /// <param name="document">Ссылка на редактируемый документ</param>
        /// <param name="insertedText">Вставляемый текст</param>
        private static void InsertSimpleRangeRightAlignment(Word.Document document, string insertedText)
        {
            Word.Paragraph paragraph = document.Paragraphs.Add();
            Word.Range range = paragraph.Range;
            range.Font.Color = Word.WdColor.wdColorBlack;
            range.Font.Size = 14;
            range.Font.Name = "Times New Roman";
            range.Text = insertedText;
            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            range.InsertParagraphAfter();
        }
        /// <summary>
        /// Добавление параграфа текста (обычное начертание, выравнивание по ширине)
        /// </summary>
        /// <param name="document"></param>
        /// <param name="insertedText"></param>
        private static void InsertSimpleRangeDistributeAlignment(Word.Document document, string insertedText)
        {
            Word.Paragraph paragraph = document.Paragraphs.Add();
            Word.Range range = paragraph.Range;
            range.Font.Color = Word.WdColor.wdColorBlack;
            range.Font.Size = 14;
            range.Font.Name = "Times New Roman";
            range.Text = insertedText;
            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphThaiJustify;
            range.InsertParagraphAfter();
        }
    }
}
