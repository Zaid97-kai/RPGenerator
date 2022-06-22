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
    /// Логика взаимодействия для AddContentWindow.xaml
    /// </summary>
    public partial class AddContentWindow : System.Windows.Window
    {
        public AddContentWindow()
        {
            InitializeComponent();
            RefreshChapter();
        }
        private void RefreshChapter()
        {
            CbContentChapter.Items.Clear();
            foreach (Chapter u in _db.GetContext().Chapter)
            {
                CbContentChapter.Items.Add(u);
            }
        }
        private void BtnAddContent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(RbContentLections.IsChecked == true || RbContentLR.IsChecked == true || RbContentPR.IsChecked == true || RbContentSR.IsChecked == true )
                {
                    if (RbContentLections.IsChecked == true)
                    {
                        Content content = new Content()
                        {
                            Type = "Содержание",
                            Name = TbContent.Text,
                            Id_Chapter = ((Chapter)CbContentChapter.SelectedItem).Id,
                            Hourly_Load = Convert.ToInt32(TbContentLoad.Text)
                        };
                        _db.GetContext().Content.Add(content);
                        _db.GetContext().SaveChanges();
                    }
                    if (RbContentPR.IsChecked == true)
                    {
                        Content content = new Content()
                        {
                            Type = "Практическая работа",
                            Name = TbContent.Text,
                            Id_Chapter = ((Chapter)CbContentChapter.SelectedItem).Id,
                            Hourly_Load = Convert.ToInt32(TbContentLoad.Text)
                        };
                        _db.GetContext().Content.Add(content);
                        _db.GetContext().SaveChanges();
                    }
                    if (RbContentLR.IsChecked == true)
                    {
                        Content content = new Content()
                        {
                            Type = "Лабораторная работа",
                            Name = TbContent.Text,
                            Id_Chapter = ((Chapter)CbContentChapter.SelectedItem).Id,
                            Hourly_Load = Convert.ToInt32(TbContentLoad.Text)
                        };
                        _db.GetContext().Content.Add(content);
                        _db.GetContext().SaveChanges();
                    }
                    if (RbContentSR.IsChecked == true)
                    {
                        Content content = new Content()
                        {
                            Type = "Самостоятельная работа",
                            Name = TbContent.Text,
                            Id_Chapter = ((Chapter)CbContentChapter.SelectedItem).Id,
                            Hourly_Load = Convert.ToInt32(TbContentLoad.Text)
                        };
                        _db.GetContext().Content.Add(content);
                        _db.GetContext().SaveChanges();
                    }
                    MessageBox.Show("Вы успешно добавили контент для темы!");
                    TbContent.Text = "";
                    CbContentChapter.SelectedItem = null;
                    TbContentLoad.Text = "";
                    RbContentLections.IsChecked = false;
                    RbContentLR.IsChecked = false;
                    RbContentPR.IsChecked = false;
                    RbContentSR.IsChecked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + "\n" + ex.Message);
            }
        }
    }
}
