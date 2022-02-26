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
        private Classes.Topic _topic;
        public AddTopicWindow(Classes.Topic topic)
        {
            InitializeComponent();
            _topic = topic;
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
                _topic.Topics.Add(new Classes.TrainingTopic() { TopicName = TbTrainingTopicDescription.Text, TypeTrainingTopic = "Теория", Hours = Convert.ToInt32(TbTrainingHours.Text), Id = Convert.ToInt32(TbTrainingTopicName.Text), Competencies = new List<string>() { "ОК 1", "ОК 2" } });
                DgHoursTheoreticalTraining.ItemsSource = _topic.Topics;
                DgHoursTheoreticalTraining.Items.Refresh();
            }
        }

        private void DgHoursTheoreticalTraining_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
