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

namespace RPTest.Window
{
    /// <summary>
    /// Логика взаимодействия для AddTopicWindow.xaml
    /// </summary>
    public partial class AddTopicWindow : System.Windows.Window
    {
        private Classes.WorkProgram _workProgram;
        private Classes.Topic _topic;
        public AddTopicWindow(Classes.Topic topic, Classes.WorkProgram workProgram)
        {
            InitializeComponent();
            _topic = topic;
            _workProgram = workProgram;

            DgHoursTheoreticalTraining.ItemsSource = _topic.Topics.Where(t => t.TypeTrainingTopic == "Теоретическое обучение");
            DgHoursPracticalTraining.ItemsSource = _topic.Topics.Where(t => t.TypeTrainingTopic == "Практические занятия");
            DgHoursLaboratoryTraining.ItemsSource = _topic.Topics.Where(t => t.TypeTrainingTopic == "Лабораторные работы");
            DgHoursSelfStudy.ItemsSource = _topic.Topics.Where(t => t.TypeTrainingTopic == "Самоястоятельная работа");
        }

        private void BnTrainingDeleteTopic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BnTrainingEditTopic_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void BnTrainingAddTopic_Click(object sender, RoutedEventArgs e)
        {
            if(TabTheoreticalTraining.SelectedIndex.ToString() == "0")
            {
                _topic.Topics.Add(new Classes.TrainingTopic() { TopicName = TbTrainingTopicDescription.Text, TypeTrainingTopic = "Теоретическое обучение", Hours = Convert.ToInt32(TbTrainingHours.Text), Id = Convert.ToInt32(TbTrainingTopicName.Text), Competencies = new List<string>() { "ОК 1", "ОК 2" } });
                DgHoursTheoreticalTraining.ItemsSource = _topic.Topics.Where(t => t.TypeTrainingTopic == "Теоретическое обучение");
                DgHoursTheoreticalTraining.Items.Refresh();
                return;
            }
            else if(TabTheoreticalTraining.SelectedIndex.ToString() == "1")
            {
                _topic.Topics.Add(new Classes.TrainingTopic() { TopicName = TbTrainingTopicDescription.Text, TypeTrainingTopic = "Практические занятия", Hours = Convert.ToInt32(TbTrainingHours.Text), Id = Convert.ToInt32(TbTrainingTopicName.Text), Competencies = new List<string>() { "ОК 1", "ОК 2" } });
                DgHoursPracticalTraining.ItemsSource = _topic.Topics.Where(t => t.TypeTrainingTopic == "Практические занятия");
                DgHoursPracticalTraining.Items.Refresh();
                return;
            }
            else if(TabTheoreticalTraining.SelectedIndex.ToString() == "2")
            {
                _topic.Topics.Add(new Classes.TrainingTopic() { TopicName = TbTrainingTopicDescription.Text, TypeTrainingTopic = "Лабораторные работы", Hours = Convert.ToInt32(TbTrainingHours.Text), Id = Convert.ToInt32(TbTrainingTopicName.Text), Competencies = new List<string>() { "ОК 1", "ОК 2" } });
                DgHoursLaboratoryTraining.ItemsSource = _topic.Topics.Where(t => t.TypeTrainingTopic == "Лабораторные работы");
                DgHoursLaboratoryTraining.Items.Refresh();
                return;
            }
            else if(TabTheoreticalTraining.SelectedIndex.ToString() == "3")
            {
                _topic.Topics.Add(new Classes.TrainingTopic() { TopicName = TbTrainingTopicDescription.Text, TypeTrainingTopic = "Самоястоятельная работа", Hours = Convert.ToInt32(TbTrainingHours.Text), Id = Convert.ToInt32(TbTrainingTopicName.Text), Competencies = new List<string>() { "ОК 1", "ОК 2" } });
                DgHoursSelfStudy.ItemsSource = _topic.Topics.Where(t => t.TypeTrainingTopic == "Самоястоятельная работа");
                DgHoursSelfStudy.Items.Refresh();
                return;
            }
        }

        private void DgHoursTheoreticalTraining_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Pages.WorkProgramPage._workProgram = _workProgram;
            Hide();
        }
    }
}
